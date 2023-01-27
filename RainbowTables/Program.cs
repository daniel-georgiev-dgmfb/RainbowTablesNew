using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Kernel.Cryptography;
using System.Threading;

namespace RainbowTables
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stopwatch = new Stopwatch();
            SyncRainbowTableGenerator.Run(args[0].ToCharArray());
            //await AsyncRainbowTableGenerator.Run(args[0].ToCharArray());
            Console.ReadLine();
        }

        //static async Task Main(string[] args)
        //{
        //    //var stopwatch = new Stopwatch();
        //    SyncRainbowTableGenerator.Run(args[0].ToCharArray());
        //    //await AsyncRainbowTableGenerator.Run(args[0].ToCharArray());
        //    Console.ReadLine();
        //}


    }
}
