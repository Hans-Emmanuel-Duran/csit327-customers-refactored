using System.ComponentModel.DataAnnotations;

namespace Customers.Dto
{
	public class CreateCustomerDto
	{
		private const string _genderPattern = "^[FM]$";

		[Required]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[StringLength(100)]
		public string Address { get; set; } = string.Empty;

		[Required]
		[RegularExpression(_genderPattern, ErrorMessage = "Gender must be 'F' or 'M'")]
		public char Gender { get; set; }

		[Required]
		[Range(0, Int32.MaxValue, ErrorMessage = "Age must be a non-negative number")]
		public int Age { get; set; }
	}
}
