using CWExercise.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
    public interface IProductService
    {
        Task<int> Create(Product product);

        Task<int> Update(int id, Product product);

        Task<int> Delete(int id);

        Task<Product> Get(int id);

        Task<List<Product>> GetAll();
    }
}
