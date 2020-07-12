using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Yerbowo.Application.Cart;
using Yerbowo.FunctionalTests.Web.Extensions;

namespace Yerbowo.FunctionalTests.Web.Controllers
{
	public class CartControllerTest : IClassFixture<WebTestFixture>
    {
		private readonly HttpClient _httpClient;

		public CartControllerTest(WebTestFixture factory)
		{
			_httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions());
		}

		[Fact]
		public async Task Add_Product_To_Cart_Should_Return_Status_Code_204()
		{
			int productId = 1;
			var response = await PostAsync(productId);

			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
		}

		[Fact]
		public async Task Remove_Product_From_Cart_Should_Return_Status_Code_204()
		{
			int productId = 2;
			var responsePost = await PostAsync(productId);
			var responseDelete = await DeleteAsync(productId);

			Assert.Equal(HttpStatusCode.NoContent, responsePost.StatusCode);
			Assert.Equal(HttpStatusCode.NoContent, responseDelete.StatusCode);
		}

		[Fact]
		public async Task Add_Two_Products_To_Cart_And_Remove_One_Product_From_Cart_Should_Return_One_Product()
		{
			int firstProduct = 3;
			await PostAsync(firstProduct);

			int secondProduct = 4;
			await PostAsync(secondProduct);

			await DeleteAsync(firstProduct);

			var cart = await GetAsync();

			Assert.Single(cart.Items);
		}

		[Fact]
		public async Task Add_Three_The_Same_Products_Should_Return_Three_Quantity()
		{
			int productId = 5;
			await PostAsync(productId);
			await PostAsync(productId);
			await PostAsync(productId);

			var cart = await GetAsync();

			Assert.Equal(3, cart.Items[0].Quantity);
		}

		[Fact]
		public async Task Add_Three_The_Same_Products_And_Delete_One_Should_Return_Two_Quantity()
		{
			int productId = 6;
			await PostAsync(productId);
			await PostAsync(productId);
			await PostAsync(productId);

			await DeleteAsync(productId);

			var cart = await GetAsync();

			Assert.Equal(2, cart.Items[0].Quantity);
		}

		private async Task<CartDto> GetAsync()
		{
			return await _httpClient.GetAsync<CartDto>("/api/cart");
		}

		private async Task<HttpResponseMessage> PostAsync(int productId)
		{
			return await _httpClient.GetAsync($"api/cart/{productId}");
		}

		private async Task<HttpResponseMessage> DeleteAsync(int productId)
		{
			return await _httpClient.DeleteAsync($"/api/cart/{productId}");
		}
	}
}
