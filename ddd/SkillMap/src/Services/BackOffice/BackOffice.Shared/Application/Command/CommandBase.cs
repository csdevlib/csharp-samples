using MediatR;

namespace BackOffice.Shared.Application.Command
{
    public abstract record CommandBase : IRequest
    {
    }

    public abstract record CommandBase<TResult> : IRequest<TResult>
    {
    }
}
