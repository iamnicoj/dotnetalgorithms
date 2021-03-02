using System;
namespace dotnetalgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("1 for Bit Manipulation\n2 for LinkedList");
            var option = Console.ReadLine();
            switch (Convert.ToInt32(option))
            {
                case 1:
                    NewMethod();
                    break;
                case 2: 
                    var option2  = -1;
                    LinkedList<int> myLinkedList = new LinkedList<int>();

                    while (option2 != 99)
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("0 print");
                        System.Console.WriteLine("1 add");
                        System.Console.WriteLine("2 get");
                        System.Console.WriteLine("3 delete");
                        System.Console.WriteLine("4 sort");
                        System.Console.WriteLine("5 reverse");
                        System.Console.WriteLine("6 lenght");
                        option2 = Convert.ToInt32(Console.ReadLine());
                        switch (option2)
                        {
                            case 0:
                                foreach (int item in myLinkedList)
                                {
                                    System.Console.WriteLine(item);                                   
                                }
                                Console.ReadLine();
                                break;
                            case 1:
                                Random r = new Random();
                                int rInt = r.Next(0, 100);
                                System.Console.WriteLine("Added : {0}", rInt.ToString());
                                myLinkedList.Add(rInt);
                                Console.ReadLine();

                                break;
                            case 2:
                                System.Console.WriteLine("Get Item");
                                var itemtoget = Convert.ToInt32(Console.ReadLine());
                                System.Console.WriteLine("Item = {0}", myLinkedList.GetItem(itemtoget));
                                Console.ReadLine();

                                break;
                            case 3:
                                System.Console.WriteLine("Remove Item");
                                var remove = Convert.ToInt32(Console.ReadLine());
                                System.Console.WriteLine("Removed = {0}", myLinkedList.RemoveItem(remove).ToString());
                                Console.ReadLine();

                                break;
                            case 4:
                                System.Console.WriteLine("Sort List");
                                myLinkedList.BubbleSort();
                                Console.ReadLine();
                                break;
                            case 5:
                                System.Console.WriteLine("Reverse List");
                                myLinkedList.ReverseList();
                                Console.ReadLine();
                                break;
                            case 6:
                                System.Console.WriteLine("Lenght = {0}", myLinkedList.Length.ToString());
                                Console.ReadLine();
                                break;
                            default:
                                 break;
                        }                                                                          
                    }
                    break;

                default:
                    break;
            }
        }

        private static void NewMethod()
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
