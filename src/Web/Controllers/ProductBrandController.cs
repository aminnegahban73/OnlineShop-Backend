using Application.Features.ProductBrands.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using Web.Common;

namespace Web.Controllers
{
    public class ProductBrandController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get (CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllProductBrandsQuery(), cancellationToken));
        }
    }
}
