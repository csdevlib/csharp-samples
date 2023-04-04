using SkillMap.EventBus.Commands;

namespace BackOffice.Application.Commands
{
    public record CreateTagCommand(string Name, string Description) : AbstractCommand;
    
}
