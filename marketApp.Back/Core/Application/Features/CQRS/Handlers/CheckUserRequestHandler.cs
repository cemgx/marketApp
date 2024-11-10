using marketApp.Back.Core.Application.Dto;
using marketApp.Back.Core.Application.Features.CQRS.Queries;
using marketApp.Back.Core.Application.Interfaces;
using marketApp.Back.Core.Domain;
using MediatR;

namespace marketApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> userRepository;
        private readonly IRepository<AppRole> roleRepository;

        public CheckUserRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false; 
            }
            else
            {
                dto.Username = user.Username;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
