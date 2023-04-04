using Calc;
using Grpc.Core;
using System;
using System.IO;

namespace CalcServer
{
    class Program
    {
        const int Port = 50051;

        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server()
                {
                    Services = {
                        CalcService.BindService(new CalcServiceImpl())
                        },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure)}
                };

                server.Start();
                Console.WriteLine("The server is listening on the port : " + Port);
                Console.ReadKey();
            }
            catch (IOException e)
            {
                Console.WriteLine("The server failed to start : " + e.Message);
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
