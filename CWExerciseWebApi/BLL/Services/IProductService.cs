using CWExercise.BLL.Models;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
	public interface IProductService
	{
		Task<bool> Create(Product product);

		Task<bool> Update(int id, Product product);

		Task<bool> Delete(int id);

		Task<Product> Get(int id);

		Task<ProductTableInfo> Get(ProductGetParam getParam);
	}
}
