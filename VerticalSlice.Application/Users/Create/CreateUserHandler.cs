using MediatR;
using VerticalSlice.Application.Interfaces;
using VerticalSlice.Domain.Entities;

namespace VerticalSlice.Application.Users.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Business logic: Create user in the database
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password // In a real application, hash the password!
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return new CreateUserResponse
            {
                UserId = user.Id,
                UserName = user.UserName
            };
        }
    }
}
