using System;

namespace dotnetalgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World of Bit Manipulation in c#");

            Console.WriteLine("Lest get num first");
            var num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Lest get i'th bit position to get");
            var i = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("set bit to?");
            var value = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("GetBit i'th bit is: {0}", Convert.ToString(BitTasks.GetBit(num, i).ToString()));
            Console.WriteLine("SetBit number: {0}", BitTasks.SetBit(num, i));
            Console.WriteLine("clearBit number: {0}", BitTasks.clearBit(num, i));
            Console.WriteLine("clearBitIThrough0 number {0}", BitTasks.clearBitIThrough0(num, i));
            Console.WriteLine("clearBitMSThroughI {0}", BitTasks.clearBitMSThroughI(num, i));
            Console.WriteLine("Update i'th bit {0}", BitTasks.updateBit(num, i, value));        
        }
    }
}
