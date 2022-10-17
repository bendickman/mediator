using Mediator.Application.Interfaces.Command;
using Mediator.Application.Interfaces.Query;
using Mediator.Domain.Entities;
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
                .Dispatch<ProductListQuery, IEnumerable<Product>>(new ProductListQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpPost(Name = "CreateEdit")]
        public async Task<IActionResult> Upsert(
           Product product,
           CancellationToken cancellationToken)
        {
            var result = await _commandDispatcher
                .Dispatch<Product, ProductUpsertResponse>(product, cancellationToken);

            if (!result.isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}