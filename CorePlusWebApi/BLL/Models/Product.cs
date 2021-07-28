using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExercise.BLL.Models
{
	public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public ProductTypeEnum Type { get; set; }
		public bool Active { get; set; }
	}

	public class Simple
	{
		public string FirstName { get; set; }
	}
}
