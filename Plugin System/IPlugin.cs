namespace Plugin_System
{
    public interface IPlugin
    {
        string Name { get; }
        void Initialize();
        void Execute();
        void Shutdown();
        void SubscribeToEvents(EventAggregator eventAggregator);
    }
}
