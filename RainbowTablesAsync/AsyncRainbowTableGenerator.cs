﻿using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
internal class AsyncRainbowTableGenerator
{
    public static async Task Run(char[] source)
    {
        var l = new List<string>();
        var stopwatch = new Stopwatch();
        //var source = new char[70] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '.', '/', '~', '#', '<', '>', '?' };
        //var source = new char[16] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f' };
        var salt = new byte[4];
        var md5 = MD5.Create();
        var exceptionCount = 0;
        ulong total = 0;

        stopwatch.Start();
        Parallel.For(0, source.Length, i =>
        {
            Parallel.For(0, source.Length, i1 =>
            {
                Parallel.For(0, source.Length, i2 =>
                {
                    Parallel.For(0, source.Length, i3 =>
                    {
                        Parallel.For(0, source.Length, i4 =>
                        {
                            Parallel.For(0, source.Length, i5 =>
                            {
                                Parallel.For(0, source.Length, i6 =>
                                {
                                    Parallel.For(0, source.Length, i7 =>
                                    {
                                        try
                                        {
                                            var sb = new StringBuilder();

                                            var psw = new char[8] { source[i], source[i1], source[i2], source[i3], source[i4], source[i5], source[i6], source[i7] };
                                            var str = new string(psw);
                                            var hash = new Platform.Kernel.Cryptography.Md4Hash().ComputeHash(str);
                                            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(hash);
                                            var base64 = System.Convert.ToBase64String(plainTextBytes);
                                            sb.AppendFormat("psw - {0} - hash - {1}. Elapsed time: {2}. Generated: {3}", str, base64, stopwatch.Elapsed, Interlocked.Increment(ref total));
#if DEBUG
                                            Debug.WriteLine(sb.ToString());
#else
                                            Console.WriteLine(sb.ToString());
#endif
                                        }

                                        catch (Exception ex)
                                        {
                                            ++exceptionCount;
#if DEBUG
                                            Debug.WriteLine("{0} - {1}. Exceptions:{2}", ex.Message, total, exceptionCount);
#else
                                            Console.WriteLine("{0} - {1}. Exceptions:{2}", ex.Message, total, exceptionCount);
#endif

                                        }
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });
        stopwatch.Stop();


    }
}