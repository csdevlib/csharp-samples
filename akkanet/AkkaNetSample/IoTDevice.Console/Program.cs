using Akka.Actor;
using IoTDevice.Console;
using IoTDevice.Library.Actors;
using IoTDevice.Library.Messages;


using (var system = ActorSystem.Create("building-iot-system"))
{
    IActorRef floorManager =
        system.ActorOf(Props.Create<FloorsManager>(), "floors-manager");

    await CreateSimulatedSensors(floorManager);

    while (true)
    {
        Console.WriteLine("Press enter to query, Q to quit");

        var cmd = Console.ReadLine();

        if (cmd.ToUpperInvariant() == "Q")
        {
            Environment.Exit(0);
        }

        await DisplayTemperatures(system);
    }
}


static async Task CreateSimulatedSensors(IActorRef floorManager)
{
    for (int simulatedSensorId = 0; simulatedSensorId < 10; simulatedSensorId++)
    {
        var newSimulatedSensor = new SimulatedSensor("basement", $"{simulatedSensorId}", floorManager);

        await newSimulatedSensor.Connect();

        var simulateNoReadingYet = simulatedSensorId == 3;

        if (!simulateNoReadingYet)
        {
            newSimulatedSensor.StartSendingSimulatedReadings();
        }
    }
}

static async Task DisplayTemperatures(ActorSystem system)
{
    var temps = await system.ActorSelection(
        "akka://building-iot-system/user/floors-manager/floor-basement")
                            .Ask<RespondAllTemperatures>(new RequestAllTemperatures(0));

    Console.CursorLeft = 0;
    Console.CursorTop = 0;

    foreach (var temp in temps.TemperatureReadings)
    {
        Console.Write($"Sensor {temp.Key} {temp.Value.GetType().Name}");

        if (temp.Value is TemperatureAvailable)
        {
            Console.Write($" {((TemperatureAvailable)temp.Value).Temperature:00.00}");
        }

        Console.WriteLine("                   ");
    }
}

