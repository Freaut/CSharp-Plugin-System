using Plugin_System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Plugin folder path: ");
        string? pluginpath = Console.ReadLine();
        if (string.IsNullOrEmpty(pluginpath))
        {
            Console.WriteLine("Invalid plugin path");
            return;
        }

        var eventAggregator = new EventAggregator();
        var pluginManager = new PluginManager(eventAggregator);

        pluginManager.LoadPlugins(pluginpath);
        
        // Below is an example use of loading plugins without having to compile them for debugging/testing

        // ExamplePlugin examplePlugin = new ExamplePlugin();
        // pluginManager.LoadPlugin(examplePlugin);

        foreach (var plugin in pluginManager.Plugins)
        {
            plugin.SubscribeToEvents(eventAggregator);
        }

        pluginManager.InitializeAllPlugins();

        var applicationStartedEvent = new ApplicationStartedEvent();
        eventAggregator.Publish(applicationStartedEvent);

        pluginManager.ExecuteAllPlugins();
        pluginManager.ShutdownAllPlugins();
    }
}