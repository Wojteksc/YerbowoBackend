using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yerbowo.Application.Cart.AddCartItems;
using Yerbowo.Application.Cart.GetCartItems;
using Yerbowo.Application.Cart.RemoveCartItems;

namespace Yerbowo.Api.Controllers
{
	[ApiController]
	[Route("api/cart")]
	public class CartController : ApiControllerBase
	{
		private readonly IMediator _mediator;

		public CartController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var cartItems = await _mediator.Send(new GetCartItemsQuery());
			return Ok(cartItems);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Add(int id)
		{
			await _mediator.Send(new AddCartItemCommand(id));
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _mediator.Send(new RemoveCartItemCommand(id));
			return NoContent();
		}
	}
}
