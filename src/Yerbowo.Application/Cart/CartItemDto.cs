using Yerbowo.Application.Products.GetProductDetails;

namespace Yerbowo.Application.Cart
{
	public class CartItemDto
	{
		public ProductDetailsDto ProductDetailsDto { get; set; }
		public int Quantity { get; set; }
	}
}
