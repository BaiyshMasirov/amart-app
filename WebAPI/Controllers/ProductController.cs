using Amart.Application.MediatR.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ProductController : BaseController
    {
        /// <summary>
        /// Action for get products by order id
        /// </summary>
        /// <param name="query">GetProductsByOrderIdQuery</param>
        /// <returns>Return list of products </returns>
        /// <returns>Return error 400 when badrequest</returns>
        [HttpGet("GetProductsByOrderId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductsByOrderId(GetProductsByOrderIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// Action for get all products
        /// </summary>
        /// <param name="query">GetProuctsQueryHandler</param>
        /// <returns>Return list of products </returns>
        /// <returns>Return error 400 when badrequest</returns>
        [HttpGet("GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts(GetProductsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}