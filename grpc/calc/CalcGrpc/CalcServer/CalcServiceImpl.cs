using Calc;
using Grpc.Core;
using System.Threading.Tasks;
using static Calc.CalcService;

namespace CalcServer
{
    public class CalcServiceImpl : CalcServiceBase
    {
        public override Task<CalcResult> Calc(CalcRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CalcResult() { Result = request.Number1 + request.Number2 });
        }

    }
}
