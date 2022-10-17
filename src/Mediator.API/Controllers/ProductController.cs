using Mediator.Application.Features.Product;
using Mediator.Application.Interfaces.Command;
using Mediator.Application.Interfaces.Query;
using Microsoft.AspNetCore.Mvc;
using static Mediator.Application.Features.Product.List;
using static Mediator.Application.Features.Product.Upsert;

namespace Mediator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ProductController(
            IQueryDispatcher queryDispatcher,
            ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet(Name = "List")]
        public async Task<IActionResult> ListAsync(
            CancellationToken cancellationToken)
        {
            var result = await _queryDispatcher
                .Dispatch<ProductListQuery, IEnumerable<ProductDto>>(new ProductListQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpPost(Name = "CreateEdit")]
        public async Task<IActionResult> Upsert(
           ProductDto product,
           CancellationToken cancellationToken)
        {
            var result = await _commandDispatcher
                .Dispatch<ProductDto, ProductUpsertResponse>(product, cancellationToken);

            if (!result.isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}