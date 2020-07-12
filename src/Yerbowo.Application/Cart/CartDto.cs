using System.Collections.Generic;

namespace Yerbowo.Application.Cart
{
	public class CartDto
	{
		public List<CartItemDto> Items { get; set; }
		public decimal Total { get; set; }
	}
}
