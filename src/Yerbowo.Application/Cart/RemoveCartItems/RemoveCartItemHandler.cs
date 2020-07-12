using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yerbowo.Application.Extensions;
using Yerbowo.Application.Settings;

namespace Yerbowo.Application.Cart.RemoveCartItems
{
	public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private ISession _session;

		public RemoveCartItemHandler(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_session = _httpContextAccessor.HttpContext.Session;
		}

		public Task<Unit> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
		{
			var products = _session.GetObjectFromJson<List<CartItemDto>>(Consts.CartSessionKey);
			int index = products.FindIndex(x => x.ProductDetailsDto.Id == request.ProductId);

			if (index != -1)
			{
				if (products[index].Quantity > 1)
				{
					products[index].Quantity--;
				}
				else
				{
					products.RemoveAt(index);
				}
			}
			_session.SetObjectAsJson(Consts.CartSessionKey, products);
			return Unit.Task;
		}
	}
}
