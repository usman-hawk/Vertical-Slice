using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Application.Users.Create;
using Ardalis.ApiEndpoints;

namespace VerticalSlice.API.Features.Users.Create
{
    public class CreateUserEndpoint : EndpointBaseAsync
    .WithRequest<CreateUserCommand>
    .WithActionResult<CreateUserResponse>
    {
        private readonly IMediator _mediator;

        public CreateUserEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/users")]
        public override async Task<ActionResult<CreateUserResponse>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
