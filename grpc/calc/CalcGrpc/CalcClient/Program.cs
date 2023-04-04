using Calc;
using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace CalcClient
{
    class Program
    {
        const string target = "127.0.0.1:50051";

        static void Main(string[] args)
        {
            _ = Process();

            Console.ReadKey();
        }

        public async static Task Process()
        {
            Channel channel = new Channel("localhost", 50051, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });

            var client = new CalcService.CalcServiceClient(channel);

            DoSimpleCalc(client, 2, 3);

            channel.ShutdownAsync().Wait();            
        }

        public static void DoSimpleCalc(CalcService.CalcServiceClient client, int number1, int number2)
        {
            var calcRequest = new CalcRequest()
            {
                Number1 = number1,
                Number2 = number2
            };

            var response = client.Calc(calcRequest);

            Console.WriteLine(response.Result);
        }
    }
}
