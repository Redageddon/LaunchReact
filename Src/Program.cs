using System.Threading.Tasks;

namespace LaunchReact
{
    public static class Program
    {
        public static async Task Main()
        {
            new LaunchpadProPlayer();
            await Task.Delay(-1);
        }
    }
}