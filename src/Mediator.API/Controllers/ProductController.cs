using Mediator.Application.Interfaces.Query;
using Microsoft.AspNetCore.Mvc;
using static Mediator.Infrastructure.Features.Product.List;

namespace Mediator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public ProductController(
            IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet(Name = "ListProducts")]
        public async Task<IActionResult> ListAsync(
            CancellationToken cancellationToken)
        {
            var result = await _queryDispatcher
                .Dispatch<ProductQuery, IEnumerable<Product>>(new ProductQuery(), cancellationToken);

            return Ok(result);
        }
    }
}