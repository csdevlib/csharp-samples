namespace BackOffice.GraphApi.Middlewares
{
    using BackOffice.GraphApi.Exceptions;
    using BackOffice.GraphApi.Graphql.Mutations;
    using HotChocolate.Resolvers;

    public class DomainExceptionMiddleware
    {
        private readonly FieldDelegate _next;

        public DomainExceptionMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException exception) when (SetResult(context, exception.Message)) { }
        }

        private bool SetResult(IMiddlewareContext context, string error)
        {
            Type type = context.Selection.Field.Type.NamedType().ToRuntimeType();

            if (type.IsSubclassOf(typeof(Payload)))
            {
                context.Result = (Payload)Activator.CreateInstance(type, null, error)!;

                return true;
            }

            return false;
        }
    }
}
