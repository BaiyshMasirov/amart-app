using Amart.Application.MediatR.Orders.Commands;
using Amart.Application.MediatR.Orders.Queries.GetOrders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Order(Purchase) Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderController : BaseController
    {
        /// <summary>
        /// Action for create order
        /// </summary>
        /// <param name="command">CreateOrderCommand</param>
        /// <returns>Return succcess message </returns>
        /// <returns>Return error 400 when badrequest</returns>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);

                if (!result.Succeed)
                    return BadRequest(result);
                return Ok(result);
            }
            return BadRequest(ModelState.Values);
        }

        /// <summary>
        /// Action for create order
        /// </summary>
        /// <param name="command">CreateOrderCommand</param>
        /// <returns>Return succcess message </returns>
        /// <returns>Return error 400 when badrequest</returns>
        [HttpPost("Edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit([FromBody] EditOrderCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(command);

                if (!result.Succeed)
                    return BadRequest(result);
                return Ok(result);
            }
            return BadRequest(ModelState.Values);
        }

        /// <summary>
        /// Action for getorders
        /// </summary>
        /// <param name="query">GetOrdersQuery</param>
        /// <returns>Return pager orders </returns>
        /// <returns>Return error 400 when badrequest</returns>
        [HttpGet("GetOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOrders(GetOrdersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}