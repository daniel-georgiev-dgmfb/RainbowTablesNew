﻿using System;
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
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("Hello World!");
            RainbowTableGenerator.RunSync(args[0].ToCharArray());
            Console.ReadLine();
        }

        
    }
}