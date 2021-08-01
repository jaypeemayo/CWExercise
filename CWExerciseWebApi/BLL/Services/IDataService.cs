using CWExercise.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
	public interface IDataService
	{
		Task<bool> Create(Product product);
		Task<bool> Update(int productID, Product product);
		Task<bool> Delete(int productID);
		Task<Product> Get(int productID);
		Task<List<Product>> GetAll();
	}
}
