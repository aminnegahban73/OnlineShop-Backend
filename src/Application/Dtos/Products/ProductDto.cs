using Application.Dtos.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ProductDto : CommandDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public string ProductType { get; set; }   // Title
        public string ProductBrand { get; set; }  // Title
    }
}
