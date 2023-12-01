using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.SeedData
{
    public class GenerateFakeData
    {
        public static async Task SeedDataAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
			try
			{
                if (!await context.ProductBrands.AnyAsync())
                {
                    var brands = ProductBrands();
                    await context.ProductBrands.AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }

                if (!await context.ProductTypes.AnyAsync())
                {
                    var types = ProductTypes();
                    await context.ProductTypes.AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }
                if (!await context.Products.AnyAsync())
                {
                    //TODO picture url
                    var products = Products();
                    await context.Products.AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }

            }
			catch (Exception ex)
			{
                var logger = loggerFactory.CreateLogger<GenerateFakeData>();
                logger.LogError(ex, "An error occurred in Seed Data.");
			}
        }

        private static List<Product> Products()
        {
            var products = new List<Product>()
        {
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 2",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 3",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary = "Velit ea do est et et irure magna. Fugiat sit proident do irure nisi cupidatat",
                ImageUrl = "image.jpeg",
                Price = 15000,
                Title = "product 1",
                ProductBrandId = 1,
                ProductTypeId = 1,
            }
        };
            return products;
        }
        private static List<ProductBrand> ProductBrands()
        {
            var brands = new List<ProductBrand>()
        {
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate ",
                Title = "Brand1",
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate ",
                Title = "Brand2",
            }
        };
            return brands;
        }
        private static List<ProductType> ProductTypes()
        {
            var types = new List<ProductType>()
        {
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate ",
                Title = "Type1",
            },
            new()
            {
                Description =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate non voluptate. Minim irure ea tempor et mollit aute consectetur. Esse amet commodo ipsum magna. Enim non nostrud minim dolore minim deserunt consequat deserunt deserunt sint amet. Ex aliquip nisi ullamco qui.\r\n",
                Summary =
                    "Fugiat ad culpa ad dolor est tempor esse deserunt amet duis. Amet nulla esse voluptate ",
                Title = "Type2",
            }
        };
            return types;
        }

    }
}
