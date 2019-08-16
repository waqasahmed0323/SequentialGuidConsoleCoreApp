using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace SequentialGuidConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = 1;
            using (var context = new SequentialGuidContext())
            {

                for (int i = 0; i < 4000000; i++)
                {
                    var std = new GuidTable()
                    {
                        GuidID = new GuidUtil().NewGuid().ToString()
                    };
                    count++;
                    context.GuidTables.Add(std);
                    context.SaveChanges();
                    Console.WriteLine(count);
                }
                Console.Read();
            }
        }

        public class GuidUtil
        {
            static int _sequenced = (int)DateTime.UtcNow.Ticks;

            private static readonly System.Security.Cryptography.RNGCryptoServiceProvider _random =
            new System.Security.Cryptography.RNGCryptoServiceProvider();
            private static readonly byte[] _buffer = new byte[6];

            public Guid NewGuid()
            {
                long ticks = DateTime.UtcNow.Ticks;
                int sequenceNum = System.Threading.Interlocked.Increment(ref _sequenced);
                lock (_buffer)
                {
                    _random.GetBytes(_buffer);
                    return new Guid(
                    (int)(ticks >> 32), (short)(ticks >> 16), (short)ticks,
                    (byte)(sequenceNum >> 8), (byte)sequenceNum,
                    _buffer[0], _buffer[1], _buffer[2], _buffer[3], _buffer[4], _buffer[5]
                    );
                }
            }
        }
    }
}
