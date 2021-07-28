using System.ComponentModel;

namespace CWExercise.BLL.Models
{
	public enum ProductTypeEnum
	{
		[Description("Books")]
		Books = 1,
		[Description("Electronics")]
		Electronics = 2,
		[Description("Food")]
		Food = 3,
		[Description("Furniture")]
		Furniture = 4,
		[Description("Toys")]
		Toys = 5
	}
}
