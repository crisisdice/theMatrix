namespace matrixApi.Containers
{
	public class Matrix
	{
		public int[] Entries { get; set; }
		public int Columns { get; set; }
	}

	public class MatrixMultiplicationRequest
	{
		public string Id { get; set; }
		public Matrix MatrixA { get; set; }
		public Matrix MatrixB { get; set; }
	}

	public class MatrixMultiplicationResponse
	{
		public Matrix MatrixC { get; set; }
	}
}

