using System;

namespace rps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, would you like to play RPS with a computre? y/n");
            if (Console.ReadLine()=="y"){

                Rounds qm = new Rounds();
                string winner=qm.quickMatchComputer();
                Console.WriteLine(winner);
            }
        }

        




    }
}