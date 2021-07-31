using System;
using System.Diagnostics;
using FASTER.core;
using Microsoft.VisualBasic.CompilerServices;
using Xunit;

namespace nx_book_tests
{
    public class UnitTest1
    {
        struct Blah
        {
            public long Number1;
            public long Number2;
            public double Number3;

            public bool Equals(Blah other)
            {
                return Number1 == other.Number1 && Number2 == other.Number2 && Number3.Equals(other.Number3);
            }

            public override bool Equals(object obj)
            {
                return obj is Blah other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Number1, Number2, Number3);
            }
            
            public static implicit operator Blah(int i)
            {
                return new() {Number1 = i};
            }

            public static bool operator ==(Blah a, Blah b)
            {
                return a.Equals(b);
            }

            public static bool operator !=(Blah a, Blah b)
            {
                return !a.Equals(b);
            }

            public static Blah operator +(Blah a, Blah b)
            {
                return new()
                {
                    Number1 = a.Number1 + b.Number1,
                    Number2 = a.Number2 + b.Number2,
                    Number3 = a.Number3 + b.Number3
                };
            }
        }
        
        [Fact]
        public void Test1()
        {
            // backing storage device
            using var log = Devices.CreateLogDevice("hlog2.log");
            using var store = new FasterKV<long, Blah>
            (
                1L << 20, // hash table size (number of 64-byte buckets)
                new LogSettings {LogDevice = log} // log settings (devices, page size, memory size, etc.)
            );

            // Create a session per sequence of interactions with FASTER
            // We use default callback functions with a custom merger:
            //   RMW merges input by adding it to value
            using var s = store.NewSession
            (
                new SimpleFunctions<long, Blah>((a, b) => a + b)
            );

            long key = 1;
            Blah value = 1, input = 10, output = 0;
  
            // Upsert and Read
            s.Upsert(ref key, ref value);
            s.Read(ref key, ref output);
            Debug.Assert(output == value);
  
            // Read-Modify-Write (add input to value)
            s.RMW(ref key, ref input);
            s.RMW(ref key, ref input);
            s.Read(ref key, ref output);
            Debug.Assert(output == value + 20);
  
            Console.WriteLine("Success!");
        }
    }
}