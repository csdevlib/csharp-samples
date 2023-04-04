using Shared;
using System;
namespace AdvancedTopics.Reflection
{
    public class EventsSample : ISample
    {
        public event EventHandler<int> MyEvent;

        public void Handler(object sender, int arg)
        {
            Console.WriteLine($"I just got {arg} from {sender?.GetType().Name}");
        }

        public void Run()
        {
            var demo = new EventsSample();

            var eventInfo = typeof(EventsSample).GetEvent("MyEvent");
            var handlerMethod = demo.GetType().GetMethod("Handler");

            // we need a delegate of a particular type
            var handler = Delegate.CreateDelegate(
              eventInfo.EventHandlerType,
              null, // object that is the first argument of the method the delegate represents
              handlerMethod
            );
            eventInfo.AddEventHandler(demo, handler);

            demo.MyEvent?.Invoke(null, 312);
        }
    }
}
