using Kernel.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace RainbowTables
{
    internal class SyncRainbowTableGenerator
    {
        public static void Run(char[] source)
        {
            var stopwatch = new Stopwatch();
            var l = new List<string>();
            var perm = new List<string>();
            var salt = new byte[4];
            var md5 = MD5.Create();
            var exceptionCount = 0;
            ulong total = 0;
            byte batchCount = 0;
            byte batchCountDisplay = 0;
            TimeSpan batchIntervalTimeStamp = TimeSpan.FromSeconds(0);

            stopwatch.Start();
            try
            {
                for (int i = 0; i < source.Length; i++)
                {
                    for (int i1 = 0; i1 < source.Length; i1++)
                    {
                        for (int i2 = 0; i2 < source.Length; i2++)
                        {
                            for (int i3 = 0; i3 < source.Length; i3++)
                            {
                                for (int i4 = 0; i4 < source.Length; i4++)
                                {
                                    for (int i5 = 0; i5 < source.Length; i5++)
                                    {
                                        for (int i6 = 0; i6 < source.Length; i6++)
                                        {
                                            for (int i7 = 0; i7 < source.Length; i7++)
                                            {
                                                for (int i8 = 0; i8 < source.Length; i8++)
                                                {
                                                    try
                                                    {
                                                        var sb = new StringBuilder();

                                                        var d = new char[9] { source[i], source[i1], source[i2], source[i3], source[i4], source[i5], source[i6], source[i7], source[i8] };
                                                        sb.Clear();
                                                        var str = new string(d);

                                                        var hash = HashBase.HashPassword(md5, str, out salt);
                                                        var base64 = System.Convert.ToBase64String(hash);
                                                        //to do work out rate per sec.
                                                        //if (stopwatch.Elapsed.Subtract(batchIntervalTimeStamp).Seconds > 10)
                                                        //{
                                                        //    batchIntervalTimeStamp = stopwatch.Elapsed;
                                                        //}
                                                        //Debug.WriteLine("psw: {0} hash:{1}. Total:{2}. Time elapsed: {3}. Rate per sec: {4}", str, base64, ++total, stopwatch.Elapsed, batchCount);
                                                        //Debug.WriteLine("psw: " + str + " hash: " + base64 + ". Total:" + ++total + " time elapsed: " + stopwatch.Elapsed);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        ++exceptionCount;
#if DEBUG
                                                        Debug.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
#else
                                                        Console.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
#endif
                                                    }
                                                };
                                            };
                                        };
                                    };
                                };
                            };
                        };
                    };
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.Elapsed);
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
            }
        }
    }
}
