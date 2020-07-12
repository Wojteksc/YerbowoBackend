using MediatR;

namespace Yerbowo.Application.Cart.RemoveCartItems
{
	public class RemoveCartItemCommand : IRequest
    {
		public int ProductId { get; }

		public RemoveCartItemCommand(int productId)
		{
			ProductId = productId;
		}

	}
}
