using MediatR;

namespace Yerbowo.Application.Cart.AddCartItems
{
	public class AddCartItemCommand : IRequest
    {
		public int Id { get; }

		public AddCartItemCommand(int id)
		{
			Id = id;
		}
	}
}
