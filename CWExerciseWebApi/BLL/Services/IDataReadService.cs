using CWExercise.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
    public interface IDataReadService
    {
        Task<int> Create(Product product);
        Task<int> Update(int productID, Product product);
        Task<int> Delete(int productID);
        Task<Product> Get(int productID);
        Task<List<Product>> GetAll();
    }
}
