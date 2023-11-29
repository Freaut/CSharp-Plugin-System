namespace Plugin_System
{
    public abstract class PluginBase : IPlugin
    {
        protected EventAggregator? _eventAggregator;
        public abstract string Name { get; }

        public virtual void Initialize()
        {
            Console.WriteLine($"{Name} plugin initialized.");
        }

        public abstract void Execute();

        public virtual void Shutdown()
        {
            Console.WriteLine($"{Name} plugin shutdown.");
        }

        public void SubscribeToEvents(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
    }
}