using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace com.fabioscagliola.AdventOfCode202107
{
    class Program
    {
        class Result
        {
            public int Position { get; protected set; }
            public int Fuel { get; protected set; }

            public Result(int position, int fuel)
            {
                Position = position;
                Fuel = fuel;
            }

        }

        static void Main()
        {
            List<int> positionList = File.ReadAllText("Input1.txt")
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList().Select(x => int.Parse(x)).ToList();

            // PART 1 

            {
                List<Result> resultList = new List<Result>();

                for (int i = 0; i < positionList.Max(); i++)
                {
                    int fuel = 0;

                    foreach (int position in positionList)
                    {
                        fuel += Math.Abs(position - i);
                    }

                    resultList.Add(new Result(i, fuel));
                }

                resultList.Sort((a, b) => a.Fuel.CompareTo(b.Fuel));

                Result result = resultList[0];

                Console.WriteLine($"In order to align to position {result.Position} the crabs must spend {result.Fuel} fuel");
            }

            // PART 2 

            {
                List<Result> resultList = new List<Result>();

                for (int i = 0; i < positionList.Max(); i++)
                {
                    int fuel = 0;

                    foreach (int position in positionList)
                    {
                        for (int j = 0; j < Math.Abs(position - i); j++)
                        {
                            fuel += j + 1;
                        }
                    }

                    resultList.Add(new Result(i, fuel));
                }

                resultList.Sort((a, b) => a.Fuel.CompareTo(b.Fuel));

                Result result = resultList[0];

                Console.WriteLine($"In order to align to position {result.Position} the crabs must spend {result.Fuel} fuel");
            }
        }

    }
}

