namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Core.Contracts.ICommandInterpreter command = new CommandInterpreter();
            Core.Contracts.IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
