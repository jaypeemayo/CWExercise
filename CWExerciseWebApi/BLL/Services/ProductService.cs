using CWExercise.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
	public class ProductService : IProductService
	{
		private readonly IDataService dataReadService;

		public ProductService(IDataService dataReadService)
		{
			this.dataReadService = dataReadService;
		}

		public async Task<bool> Create(Product product)
		{
			return await dataReadService.Create(product);
		}

		public async Task<bool> Update(int id, Product product)
		{
			return await dataReadService.Update(id, product);
		}

		public async Task<bool> Delete(int id)
		{
			return await dataReadService.Delete(id);
		}

		public async Task<Product> Get(int id)
		{
			return await dataReadService.Get(id);
		}

		public async Task<ProductTableInfo> Get(ProductGetParam getParam)
		{
			List<Product> products = await dataReadService.GetAll();

			IOrderedEnumerable<Product> sortedProducts;

			switch (getParam.ColumnToSort)
			{
				case "ProductID":
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.ProductID) : products.OrderByDescending(o => o.ProductID);
					break;
				case "Name":
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.Name) : products.OrderByDescending(o => o.Name);
					break;
				case "Price":
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.Price) : products.OrderByDescending(o => o.Price);
					break;
				case "Type":
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.Type) : products.OrderByDescending(o => o.Type);
					break;
				case "Active":
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.Active) : products.OrderByDescending(o => o.Active);
					break;
				default:
					sortedProducts = getParam.SortDirection == SortEnum.Asc ? products.OrderBy(o => o.ProductID) : products.OrderByDescending(o => o.ProductID);
					break;
			}

			var productTableInfo = new ProductTableInfo()
			{
				Products = sortedProducts.Skip(getParam.PageSize * (getParam.PageNumber - 1)).Take(getParam.PageSize).ToList(),
				NumberOfPages = (int)Math.Ceiling((double)products.Count / getParam.PageSize)
			};

			return productTableInfo;
		}
	}
}
