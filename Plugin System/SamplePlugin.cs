namespace Plugin_System
{
    /// <summary>
    /// Example plugin
    /// </summary>
    public class SamplePlugin : PluginBase
    {
        public override string Name => "Sample Plugin";

        public override void Execute()
        {
            Console.WriteLine($"{Name} is executing.");
        }
    }

    /// <summary>
    /// Example plugin that subscribes to the built in shutdown event
    /// </summary>
    public class ExamplePlugin : PluginBase
    {
        public override string Name => "Example Plugin";

        public override void Execute()
        {
            Console.WriteLine($"{Name} is executing.");
        }

        public override void Initialize()
        {
            base.Initialize();

            if (_eventAggregator == null)
                return;

            _eventAggregator.Subscribe<ApplicationStartedEvent>(HandleStartupEvent);
            _eventAggregator.Subscribe<ApplicationShutdownEvent>(HandleShutdownEvent);
        }

        private void HandleStartupEvent(ApplicationStartedEvent startEvent)
        {
            Console.WriteLine($"{Name} received application startup event.");
        }

        private void HandleShutdownEvent(ApplicationShutdownEvent shutdownEvent)
        {
            Console.WriteLine($"{Name} received application shutdown event.");
        }
    }
}
