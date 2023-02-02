using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        //var stopwatch = new Stopwatch();
        //await AsyncRainbowTableGenerator.Run(args[0].ToCharArray());
        var sb = new StringBuilder();
        await AsyncRainbowTableGeneratorRec.Run(args[0].ToCharArray(), 0, new char[9], sb);
        Console.ReadLine();
    }
}
