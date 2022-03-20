using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Retele_Token_Ring
{
    class Program
    {
        static void PrintComputers(List<Computer> computers)
        {
            for (int i = 0; i < computers.Count; i++)
            {
                Console.WriteLine($"C{i}: {computers[i]}");
            }
        }

        static void CyclicRing()
        {
            List<Computer> computers = new List<Computer>();
            Token token = new Token();

            for (int i = 0; i < 10; i++)
            {
                Computer c = new Computer();
                c.GenerateNewIp();
                computers.Add(c);
            }

            string message = "(Message)";
            Random random = new Random();
            for (int i = 0; i < computers.Count; i++)
            {
                if (token.IsBusy == false)
                {
                    if (String.IsNullOrEmpty(token.Message))
                    {
                        PrintComputers(computers);
                        int source = random.Next(0, 10);
                        int destination = random.Next(0, 10);
                        while (destination == source)
                        {
                            destination = random.Next(0, 10);
                        }

                        token.SourceAddress = computers[source].IpAddress;
                        token.DestinationAddress = computers[destination].IpAddress;
                        token.IsBusy = true;
                        token.DestinationReached = false;
                        Console.WriteLine($"Source: C{source}\nDestination: C{destination}");
                    }

                }

                if (token.IsBusy == true)
                {
                    if (token.DestinationReached == false)
                    {
                        if (token.SourceAddress == computers[i].IpAddress)
                        {
                            Console.WriteLine($"C{i}: Token accepted");
                            token.Message = message;
                        }
                        if (token.DestinationAddress == computers[i].IpAddress && String.IsNullOrEmpty(token.Message) == false)
                        {
                            Console.WriteLine($"C{i}: Token reached destination");
                            computers[i].Buffer += message;
                            token.DestinationReached = true;
                            token.Message = null;
                        }

                        Console.WriteLine($"C{i}: Token moved");
                    }
                    else
                    {
                        if (token.SourceAddress == computers[i].IpAddress)
                        {
                            Console.WriteLine($"C{i}: Token reached back the source");
                            token.IsBusy = false;


                        }
                        Console.WriteLine($"C{i}: Token moved");
                    }
                }
                if (i == 9)
                {
                    i = -1;
                }
            }

        }

        static void SteppedRing(int steps)
        {
            int takensteps = 0;
            List<Computer> computers = new List<Computer>();
            Token token = new Token();

            for (int i = 0; i < 10; i++)
            {
                Computer c = new Computer();
                c.GenerateNewIp();
                computers.Add(c);
            }

            string message = "(Message)";
            Random random = new Random();
            for (int i = 0; i < computers.Count; i++)
            {
                takensteps++;
                if (token.IsBusy == false)
                {
                    if (String.IsNullOrEmpty(token.Message))
                    {
                        PrintComputers(computers);
                        int source = random.Next(0, 10);
                        int destination = random.Next(0, 10);
                        while (destination == source)
                        {
                            destination = random.Next(0, 10);
                        }

                        token.SourceAddress = computers[source].IpAddress;
                        token.DestinationAddress = computers[destination].IpAddress;
                        token.IsBusy = true;
                        token.DestinationReached = false;
                        Console.WriteLine($"Source: C{source}\nDestination: C{destination}");
                    }

                }

                if (token.IsBusy == true)
                {
                    if (token.DestinationReached == false)
                    {
                        if (token.SourceAddress == computers[i].IpAddress)
                        {
                            Console.WriteLine($"C{i}: Token accepted");
                            token.Message = message;
                        }
                        if (token.DestinationAddress == computers[i].IpAddress && String.IsNullOrEmpty(token.Message) == false)
                        {
                            Console.WriteLine($"C{i}: Token reached destination");
                            computers[i].Buffer += message;
                            token.DestinationReached = true;
                            token.Message = null;
                        }

                        Console.WriteLine($"C{i}: Token moved");
                    }
                    else
                    {
                        if (token.SourceAddress == computers[i].IpAddress)
                        {
                            Console.WriteLine($"C{i}: Token reached back the source");
                            token.IsBusy = false;


                        }
                        Console.WriteLine($"C{i}: Token moved");
                    }
                }
                if (i == 9)
                {
                    i = -1;
                }

                if (takensteps == steps)
                {
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Choose option:\n1.Cyclic\n2.With limited steps");
            int option; 
            int.TryParse(Console.ReadLine(),out option);
            switch (option)
            {
                case 1:
                    CyclicRing();
                    break;
                case 2:
                    Console.Write("Enter number of steps: ");
                    int.TryParse(Console.ReadLine(), out option);
                    SteppedRing(option);
                    break;
            }

            Console.Read();
        }
    }
}
