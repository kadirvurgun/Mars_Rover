using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Program
    {
        public static int SpaceX { get; set; }
        public static int SpaceY { get; set; }
        protected static List<string> MainMethodArgs = new List<string>();
        public static void Main(string[] args)
        {
            MainMethodArgs = args.ToList();
            Console.WriteLine("Plateau surface size :");
            Run(Console.ReadLine());

            Console.WriteLine("Rover position :");
            string location = Console.ReadLine() ;
            Console.WriteLine("Rover direction command:");
            string roverDirection = Console.ReadLine();
            ReadProcess(location, roverDirection);
        }
        public static void Run(string x)
        {
            SpaceX = IntControl(x.Split(' ')[0]);
            SpaceY = IntControl(x.Split(' ')[1]);
        }
        public static string ReadProcess(string position = "", string roverDirection = "", bool test = false)
        {
            string[] location;
            Business business = new Business();
            if (string.IsNullOrEmpty(position) && string.IsNullOrEmpty(roverDirection))
            {
                Console.WriteLine("Rover position :");
                location = Console.ReadLine().Split(' ');
                Console.WriteLine("Rover direction command:");
                roverDirection = Console.ReadLine();
            }
            else
            {
                location = position.Split(' ');
            }

            Location loc = new Location();
            loc.X = IntControl(location[0]); 
            loc.Y = IntControl(location[1]);
            switch (location[2])
            {
                case "W":
                    loc.currentDirection = Enums.Directon.W;
                    break;
                case "E":
                    loc.currentDirection = Enums.Directon.E;
                    break;
                case "S":
                    loc.currentDirection = Enums.Directon.S;
                    break;
                case "N":
                    loc.currentDirection = Enums.Directon.N;
                    break;
            }



            string rDirection = "L|R";
            for (int i = 0; i < roverDirection.Length; i++)
            {
                if (rDirection.Contains(roverDirection[i]))
                {
                    Enums.ToDirection enumDirection = roverDirection[i].ToString() == "L" ? Enums.ToDirection.L : Enums.ToDirection.R;
                    loc.currentDirection = business.ProcessDirection(enumDirection, loc.currentDirection);
                }
                else
                {
                    loc = business.Move(loc);
                }
            }

            if (loc.X > SpaceX || loc.Y > SpaceY)
                Console.WriteLine("Input Size Exceeded !!");
            else
                Console.WriteLine($"{loc.X} {loc.Y} {loc.currentDirection}");
            if (!test)
            {
                Console.WriteLine("Want to add another rover and route? (Y/N)");
                if (Console.ReadLine() == "Y")
                    ReadProcess();
                return "";
            }
            else
            {
                return $"{loc.X} {loc.Y} {loc.currentDirection}";
            }  
        }

        public static int IntControl(string value)
        {
            if (!int.TryParse(value, out int result))
            {
                Console.WriteLine("Hatalı Değer girdiniz lütfen baştan başlayınız.");
                Main(MainMethodArgs.ToArray());
            }
            return result;
        }
    }
}
