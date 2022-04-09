using Amart.Application.MediatR.Accounts.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : BaseController
    {
        /// <summary>
        /// Action for authorize
        /// </summary>
        /// <param name="command">LoginCommand</param>
        /// <returns>Return userId if success</returns>
        /// <returns>Retur error 400 when badrequest</returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
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
    }
}