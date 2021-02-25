using System.Runtime.InteropServices;

using Microsoft.Extensions.Logging;

using matrixApi.Containers;


namespace matrixApi.Services
{
    public class ArithmeticService : IArithmeticService
    {
        private readonly ILogger<ArithmeticService> _logger;

        public ArithmeticService(ILogger<ArithmeticService> logger)
        {
            _logger = logger;
        }

        [DllImport("lib\\matrixCalc.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl,
            EntryPoint = "multiply")]
        private static extern void multiply(int[] matrixA, int[] matrixB, int aColumns, int bColumns, int cLength,
            int[] matrixC);

        private int[] Multiply(int[] matrixA, int[] matrixB, int aColumns, int bColumns)
        {
            var aEntries = string.Join(", ", matrixA);
            var bEntries = string.Join(", ", matrixB);

            _logger.LogInformation($"Multiplying [ { aEntries} ] with [ { bEntries } ]");
            
            var aRows = matrixA.Length / aColumns;

            var cLength = aRows * bColumns;

            var matrixC = new int[cLength];

            multiply(matrixA, matrixB, aColumns, bColumns, cLength, matrixC);

            return matrixC;
        }

        public ValidationResult Validate(MatrixMultiplicationRequest request)
        {
            var validationResult = new ValidationResult
            {
                Successful = true
            };
            
            var bRows = request.MatrixB.Entries.Length / request.MatrixB.Columns;

            if (request.MatrixA.Columns != bRows)
            {
                validationResult.Successful = false;
                validationResult.ValidationErrors.Add("Mismatched Matrices");
            }

            return validationResult;
        }

        public MatrixMultiplicationResponse Handle(MatrixMultiplicationRequest request)
        {
            var matrixEntries = Multiply(request.MatrixA.Entries, request.MatrixA.Entries, request.MatrixA.Columns,
                request.MatrixB.Columns);

            return new MatrixMultiplicationResponse
            {
                MatrixC = new Matrix
                {
                    Entries = matrixEntries,
                    Columns = request.MatrixB.Columns
                }
            };
        }
    }

    public interface IArithmeticService
    {
        ValidationResult Validate(MatrixMultiplicationRequest request);
        MatrixMultiplicationResponse Handle(MatrixMultiplicationRequest request);
    }
}