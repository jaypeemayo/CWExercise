using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExercise.BLL.Models
{
	public class ProductGetParam
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public string ColumnToSort { get; set; }
		public SortEnum SortDirection { get; set; }
	}

}
