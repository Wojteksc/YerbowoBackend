using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Yerbowo.Application.Products;
using Yerbowo.Application.Products.CreateProducts;
using Yerbowo.FunctionalTests.Web.Extensions;

namespace Yerbowo.FunctionalTests.Web.Controllers
{
	public class ProductsControllerTest : IClassFixture<WebTestFixture>
	{
		private readonly HttpClient _httpClient;
		public ProductsControllerTest(WebTestFixture factory)
		{
			_httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions());
		}

		[Fact]
		private async Task Get_Products_By_Paging_Shoould_Return_The_Same_Quantity()
		{
			const int Quantity = 3;
			var products = await _httpClient.GetAsync<List<ProductCardDto>>($"api/products?category=yerba-mate&subcategory=klasyczne&pageNumber=1&pageSize={Quantity}");

			Assert.Equal(products.Count, Quantity);
		}
	}
}
