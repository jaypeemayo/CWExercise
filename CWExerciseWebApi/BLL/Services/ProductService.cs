using CWExercise.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{



	public class ProductService : IProductService
    {
        private readonly IDataReadService dataReadService;

        public ProductService(IDataReadService dataReadService)
        {
            this.dataReadService = dataReadService;
        }

        public async Task<int> Create(Product product)
		{
            return await dataReadService.Create(product);

        }

        public async Task<int> Update(int id, Product product)
        {
            return await dataReadService.Update(id, product);

        }

        public async Task<int> Delete(int id)
        {
            return await dataReadService.Delete(id);

        }

        public async Task<Product> Get(int id)
        {
            return await dataReadService.Get(id);

        }

        public async Task<List<Product>> GetAll()
        {
            return await dataReadService.GetAll();
        }


    }
}
