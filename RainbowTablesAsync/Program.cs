class Program
{
    static async Task Main(string[] args)
    {
        //var stopwatch = new Stopwatch();
        await AsyncRainbowTableGenerator.Run(args[0].ToCharArray());
        Console.ReadLine();
    }


}
