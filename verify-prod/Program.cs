using System;
using System.IO;
using System.Linq;
using System.Text;

namespace verify_prod
{
    class Program
    {
        static int Main(string[] args)
        {
            var output = File.ReadAllLines("output.txt", Encoding.UTF8);
            var expected = File.ReadAllLines("expected.txt", Encoding.UTF8);
            var verified = expected.SequenceEqual(output);
            if (verified)
            {
                Console.WriteLine("Looking good!");
                return 0;
            }
            else
            {
                Console.WriteLine("Expected:");
                Console.Write(string.Join('\n', expected));
                Console.WriteLine("Was:");
                Console.Write(string.Join('\n', output));
                return 1;
            }
        }
    }
}
