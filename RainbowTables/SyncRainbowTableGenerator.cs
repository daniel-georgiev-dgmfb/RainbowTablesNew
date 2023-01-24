using Kernel.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RainbowTables
{
    internal class SyncRainbowTableGenerator
    {
        public static void Run(char[] source)
        {
            Stopwatch stopwatch = new Stopwatch();
            var l = new List<string>();
            var perm = new List<string>();
            var salt = new byte[4];
            //var sb = new StringBuilder();
            var md5 = MD5.Create();
            var exceptionCount = 0;
            ulong total = 0;
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
                                                        //var d = new char[4] { source[i], source[i1], source[i2], source[i3] };
                                                        var str = new string(d);
                                                        //sb.AppendLine(str);
                                                        //var p = new string(d);
                                                        //perm.Add(sb.ToString());
                                                        var hash = HashBase.HashPassword(md5, str, out salt);
                                                        //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                                                        var base64 = System.Convert.ToBase64String(hash);
                                                        //sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, Interlocked.Increment(ref total));
                                                        Debug.WriteLine("psw: " + str + " hash: " + base64 + ". Total:" + Interlocked.Increment(ref total) + " time elapsed: " + stopwatch.Elapsed);
                                                        //Debug.WriteLine(sb.ToString());
                                                        //ConsoleOutput.Instance.WriteLine(sb.ToString(), OutputLevel.Information);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        ++exceptionCount;
                                                        Console.WriteLine("{0} - {1}. Exceptions:{2}", e.Message, total, exceptionCount);
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
