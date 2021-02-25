using System.Collections.Generic;

namespace matrixApi.Containers
{
	public class ValidationResult
	{
		public bool Successful { get; set; }
		public List<string> ValidationErrors { get; set; }
	}
}
