﻿using Yerbowo.Domain.Products;

namespace Yerbowo.Application.Products.GetProductDetails
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public int Stock { get; set; }
        public ProductState State { get; set; }
        public string Image { get; set; }
    }
}
