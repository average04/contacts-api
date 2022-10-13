using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.API.Controllers
{
    public class ContactController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost("contact")]
        public async Task<IActionResult> Create([FromBody] ContactModel body)
        {
            var request = new CreateContactRequest()
            {
                Name = body.Name,
                Numbers = body.Numbers
            };
            var response = await Mediator.Send(request);

            return Created($"{Request.Path.Value}/{response.Id}", response);
        }


        [HttpGet("contact")]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetContactsRequest();

            return Ok(await Mediator.Send(request));
        }

        [HttpGet("contact/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetContactByIdRequest() { Id = id };
            var response = await Mediator.Send(request);
            return response != null ? Ok(response) : NotFound("Id not found");
        }

        [HttpPut("contact/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var request = new UpdateContactRequest() { Id = id };
            var response = await Mediator.Send(request);
            return response ? Ok() : NotFound("Id not found");
        }

        [HttpDelete("contact/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var request = new DeleteContactRequest() { Id = id };
            var response = await Mediator.Send(request);
            return response ? Ok() : NotFound("Id not found");
        }
    }
}
