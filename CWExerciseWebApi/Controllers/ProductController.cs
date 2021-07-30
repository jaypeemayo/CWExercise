﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWExercise.BLL.Models;
using CWExerciseApi.BLL;
using CWExerciseApi.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CWExerciseApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
 
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<int> PostProduct([FromBody]Product product)
        {
            return await productService.Create(product);
        }

        [HttpPut("{id}")]
        public async Task<int> PutProduct(int id, [FromBody] Product product)
		{
            return await productService.Update(id, product);
		}

        [HttpDelete("{id}")]
        public async Task<int> DeleteProduct(int id)
        {
            return await productService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await productService.Get(id);
        }

        [HttpGet("{pageNumber?}/{pageSize?}/{columnToSort?}/{sortDirection?}")]
        public async Task<ProductTableInfo> GetProduct(int pageNumber, int pageSize, string columnToSort, int sortDirection)
        {
            return await productService.Get(new ProductGetParam() { 
   
                PageNumber=pageNumber,
                PageSize = pageSize,
                ColumnToSort = columnToSort,
                SortDirection = (SortEnum)sortDirection,
            });
        }
    }
}
