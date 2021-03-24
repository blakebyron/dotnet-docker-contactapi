using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Contact.Api.Features.Contact
{
    [ApiController]
    [Route(Constants.RouteName)]
    public class ContactController : ControllerBase
    {
        private readonly IMediator mediator;
        public ContactController(IMediator mediator)
        {
            this.mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Returns a list of feature resources
        /// </summary>
        /// <param name="query"></param>
        /// <returns>200 OK</returns>
        [HttpGet(Name = Constants.ListActionName)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<List.Result.Contact>))]
        public async Task<IActionResult> List(List.Query query)
        {
            var model = await mediator.Send(query);
            return this.Ok(model.Items);
        }

        /// <summary>
        /// Returns a list of feature resources
        /// </summary>
        /// <param name="query"></param>
        /// <returns>200 OK</returns>
        /// <returns>404 Not Found</returns>
        [HttpGet("{id}", Name = Constants.DetailActionName)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Detail.Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Detail(Detail.Query query)
        {
            var model = await mediator.Send(query);
            return model != null ? (IActionResult)Ok(model) : (IActionResult)NotFound();
        }
    }
}
