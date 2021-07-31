using CWExercise.BLL.Models;
using CWExerciseApi.BLL.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CWExerciseUnitTest
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
		public void CreateProduct_Success()
		{
			Product product = new Product();
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.Create(product)).ReturnsAsync(true);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Create(product).Result;
			Assert.AreEqual(true, result, "create should return true");
		}

		[TestMethod]
		public void CreateProduct_Failed()
		{
			Product product = new Product();
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.Create(product)).ReturnsAsync(false);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Create(product).Result;
			Assert.AreEqual(false, result, "create should return false");
		}

		public void DeleteProduct_Success()
		{
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.Delete(1)).ReturnsAsync(true);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Delete(1).Result;
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void DeleteProduct_Failed()
		{
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.Delete(1)).ReturnsAsync(false);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Delete(1).Result;
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Get_ReturnProduct()
		{
			Product product = new Product();
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.Get(1)).ReturnsAsync(product);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(1).Result;
			Assert.AreEqual(product, result);
		}


		[TestMethod]
		public void Get_SortProductIDAscending_ReturnAscendingOrderProducts()
		{

			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "ProductID";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { ProductID = 3 };
			Product product2 = new Product() { ProductID = 2 };
			Product product3 = new Product() { ProductID = 1 };
			var productList = new List<Product>() { product, product2, product3 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;

			Assert.AreEqual(1, result.Products[0].ProductID);
		    Assert.AreEqual(2, result.Products[1].ProductID);
			Assert.AreEqual(3, result.Products[2].ProductID);
		}

		[TestMethod]
		public void Get_SortNameAscending_ReturnAscendingNameProducts()
		{
			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Name";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { Name = "C" };
			Product product2 = new Product() { Name = "B" };
			Product product3 = new Product() { Name = "A" };
			var productList = new List<Product>() { product, product2, product3 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;

			Assert.AreEqual("A", result.Products[0].Name);
			Assert.AreEqual("B", result.Products[1].Name);
			Assert.AreEqual("C", result.Products[2].Name);
		}

		[TestMethod]
		public void Get_SortPriceAscending_ReturnAscendingPrice()
		{

			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Price";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { Price = (decimal)2.3 };
			Product product2 = new Product() { Price = (decimal)2.2 };
			Product product3 = new Product() { Price = (decimal)2.1 };
			var productList = new List<Product>() { product, product2, product3 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;

			Assert.AreEqual(2.1, (double)result.Products[0].Price);
			Assert.AreEqual(2.2, (double)result.Products[1].Price);
			Assert.AreEqual(2.3, (double)result.Products[2].Price);
		}

		[TestMethod]
		public void Get_SortTypeAscending_ReturnAscendingType()
		{
			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Type";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { Type = ProductTypeEnum.Food };
			Product product2 = new Product() { Type = ProductTypeEnum.Electronics };
			Product product3 = new Product() { Type = ProductTypeEnum.Books };
			var productList = new List<Product>() { product, product2, product3 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;


			Assert.AreEqual(ProductTypeEnum.Books, result.Products[0].Type);
			Assert.AreEqual(ProductTypeEnum.Electronics, result.Products[1].Type);
			Assert.AreEqual(ProductTypeEnum.Food, result.Products[2].Type);
		}

		[TestMethod]
		public void Get_SortActiveAscending_ReturnAscendingActive()
		{

			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Active";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { Active = true };
			Product product2 = new Product() { Active = false };
			var productList = new List<Product>() { product, product2 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;

			Assert.AreEqual(false, result.Products[0].Active);
			Assert.AreEqual(true, result.Products[1].Active);
		}


		[TestMethod]
		public void Get_SixProductsWithFivePageSize_ReturnTwoPages()
		{
			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Active";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { ProductID = 1 };
			Product product2 = new Product() { ProductID = 2 };
			Product product3 = new Product() { ProductID = 3 };
			Product product4 = new Product() { ProductID = 4 };
			Product product5 = new Product() { ProductID = 5 };
			Product product6 = new Product() { ProductID = 6 };
			var productList = new List<Product>() { product, product2, product3, product4, product5, product6 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;


			Assert.AreEqual(2, result.NumberOfPages);
		}

		[TestMethod]
		public void Get_FiveProductsWithFivePageSize_ReturnOnePage()
		{
			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 1;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "Active";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { ProductID = 1 };
			Product product2 = new Product() { ProductID = 2 };
			Product product3 = new Product() { ProductID = 3 };
			Product product4 = new Product() { ProductID = 4 };
			Product product5 = new Product() { ProductID = 5 };
			var productList = new List<Product>() { product, product2, product3, product4, product5 };

			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;


			Assert.AreEqual(1, result.NumberOfPages);
			Assert.AreEqual(5, result.Products.Count);
		}



		[TestMethod]
		public void Get_PageNumberTwo_ReturnPageTwoRow()
		{
			ProductGetParam getParam = new ProductGetParam();
			getParam.PageNumber = 2;
			getParam.PageSize = 5;
			getParam.ColumnToSort = "ProductID";
			getParam.SortDirection = SortEnum.Asc;

			Product product = new Product() { ProductID = 1 };
			Product product2 = new Product() { ProductID = 2 };
			Product product3 = new Product() { ProductID = 3 };
			Product product4 = new Product() { ProductID = 4 };
			Product product5 = new Product() { ProductID = 5 };
			Product product6 = new Product() { ProductID = 6 };
			var productList = new List<Product>() { product, product2, product3, product4, product5, product6 };
			var mockDataService = new Mock<IDataService>();
			mockDataService.Setup(o => o.GetAll()).ReturnsAsync(productList);

			ProductService service = new ProductService(mockDataService.Object);
			var result = service.Get(getParam).Result;

			Assert.AreEqual(6, result.Products[0].ProductID);
			Assert.AreEqual(1, result.Products.Count);
		}
	}

}
