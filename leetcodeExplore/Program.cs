using System;
using leetcodeExplore.lib;

namespace leetcodeExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestLinkedList();
            Console.ReadKey();
        }

        static void TestLinkedList(){
           
            MyLinkedList l = new MyLinkedList();
            l.AddAtHead(38);
            l.AddAtHead(45);
            l.DeleteAtIndex(2);
            l.AddAtIndex(1,24);
            l.AddAtTail(36);
            l.AddAtIndex(3,72);
            l.AddAtTail(76);
            l.AddAtHead(7);
            l.AddAtHead(36);
            l.AddAtHead(34);
            l.AddAtTail(91);
            l.AddAtTail(69);
            l.AddAtHead(37);
            l.AddAtTail(38);
            l.AddAtTail(4);
            l.AddAtHead(66);
            l.AddAtTail(38);
            l.DeleteAtIndex(14);
            l.AddAtTail(12);
            l.AddAtTail(32);
            var a = l.Get(5);
            l.AddAtIndex(7,5);
            l.AddAtHead(74);
            var b = l.Get(7);
            var c = l.Get(13);
    
            while(l.node != null){
                Console.WriteLine(l.node.val);
                l.node = l.node.next;
            }
            //Console.WriteLine($"b : {b}");
            //Console.WriteLine($"c : {c}");
            //Console.WriteLine($"d : {d}");
            //Console.WriteLine($"e : {e}");
      
        }



    }
}
