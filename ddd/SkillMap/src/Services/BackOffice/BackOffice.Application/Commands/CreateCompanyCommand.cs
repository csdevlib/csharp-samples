using BackOffice.Application.Dto;
using SkillMap.EventBus.Commands;

namespace BackOffice.Application.Commands
{
    public record CreateCompanyCommand(CreateCompanyDto company) :  AbstractCommand;
}
