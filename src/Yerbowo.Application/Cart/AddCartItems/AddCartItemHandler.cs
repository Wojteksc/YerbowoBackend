using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Yerbowo.Application.Extensions;
using Yerbowo.Application.Products.GetProductDetails;
using Yerbowo.Application.Settings;
using Yerbowo.Infrastructure.Data.Products;

namespace Yerbowo.Application.Cart.AddCartItems
{
	public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private ISession _session;
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public AddCartItemHandler(IHttpContextAccessor httpContextAccessor,
			IProductRepository productRepository,
			IMapper mapper)
		{
			_httpContextAccessor = httpContextAccessor;
			_session = _httpContextAccessor.HttpContext.Session;
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
		{
			
			var productDb = _mapper.Map<ProductDetailsDto>(await _productRepository.GetAsync(request.Id));
			var products = _session.GetObjectFromJson<List<CartItemDto>>(Consts.CartSessionKey);

			if (products == null)
			{
				products = new List<CartItemDto>();
				AddNewProductToCart(products, productDb);
			}
			else
			{
				int index = products.FindIndex(x => x.Product.Id == productDb.Id);

				if (index != -1)
				{
					products[index].Quantity++;
					_session.SetString(Consts.CartSessionKey, JsonConvert.SerializeObject(products));
				}
				else
				{
					AddNewProductToCart(products, productDb);
				}
			}

			return await Unit.Task;
		}

		private void AddNewProductToCart(List<CartItemDto> cart, ProductDetailsDto productDetailsDto, int quantity = 1)
		{
			cart.Add(new CartItemDto()
			{
				Product = productDetailsDto,
				Quantity = quantity
			});

			_session.SetString(Consts.CartSessionKey, JsonConvert.SerializeObject(cart));
		}
	}
}
