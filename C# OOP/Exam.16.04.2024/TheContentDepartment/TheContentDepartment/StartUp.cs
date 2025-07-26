using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Core;
using TheContentDepartment.Models;

namespace TheContentDepartment
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
