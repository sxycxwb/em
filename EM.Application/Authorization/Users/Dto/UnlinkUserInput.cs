using Abp.Application.Services.Dto;

namespace EM.Authorization.Users.Dto
{
    public class UnlinkUserInput : IInputDto
    {
        public long UserId { get; set; }
    }
}