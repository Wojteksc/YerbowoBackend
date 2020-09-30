using Yerbowo.Application.Products.GetProductDetails;

namespace Yerbowo.Application.Cart
{
	public class CartItemDto
	{
		public ProductDetailsDto Product { get; set; }
		public int Quantity { get; set; }
	}
}
