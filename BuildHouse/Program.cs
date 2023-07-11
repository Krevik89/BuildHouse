using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{

    interface IPart
    {
        bool IsBuilt { get; }
        void Build();
        string GetName();
    }

    class House
    {
        public List<IPart> parts;

        public House()
        {
            parts = new List<IPart>();
            parts.Add(new Basement());
            for (int i = 0; i < 4; i++)
            {
                parts.Add(new Walls());
            }
            parts.Add(new Door());
            for (int i = 0; i < 4; i++)
            {
                parts.Add(new Window());
            }
            parts.Add(new Roof());
        }

        public bool IsBuilt()
        {
            foreach (IPart part in parts)
            {
                if (!part.IsBuilt)
                {
                    return false;
                }
            }
            return true;
        }

        public void BuildNextPart()
        {
            foreach (IPart part in parts)
            {
                if (!part.IsBuilt)
                {
                    part.Build();
                    Console.WriteLine("Построено " + part.GetName());
                    break;
                }
            }
        }

        public void PrintHouse()
        {
            Console.WriteLine("  /\\");
            Console.WriteLine(" /  \\");
            Console.WriteLine("/____\\");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
            Console.WriteLine("|____|");
        }
    }

    class Basement : IPart
    {
        private bool isBuilt;

        public Basement()
        {
            isBuilt = false;
        }

        public bool IsBuilt
        {
            get { return isBuilt; }
        }

        public void Build()
        {
            isBuilt = true;
        }

        public string GetName()
        {
            return "Фундамент";
        }
    }

    class Walls : IPart
    {
        private bool isBuilt;

        public Walls()
        {
            isBuilt = false;
        }

        public bool IsBuilt
        {
            get { return isBuilt; }
        }

        public void Build()
        {
            isBuilt = true;
        }

        public string GetName()
        {
            return "Стена";
        }
    }

    class Door : IPart
    {
        private bool isBuilt;

        public Door()
        {
            isBuilt = false;
        }

        public bool IsBuilt
        {
            get { return isBuilt; }
        }

        public void Build()
        {
            isBuilt = true;
        }

        public string GetName()
        {
            return "Дверь";
        }
    }

    class Window : IPart
    {
        private bool isBuilt;

        public Window()
        {
            isBuilt = false;
        }

        public bool IsBuilt
        {
            get { return isBuilt; }
        }

        public void Build()
        {
            isBuilt = true;
        }

        public string GetName()
        {
            return "Окно";
        }
    }

    class Roof : IPart
    {
        private bool isBuilt;

        public Roof()
        {
            isBuilt = false;
        }

        public bool IsBuilt
        {
            get { return isBuilt; }
        }

        public void Build()
        {
            isBuilt = true;
        }

        public string GetName()
        {
            return "Крыша";
        }
    }

    interface IWorker
    {
        void BuildHouse(House house);
    }

    class Worker : IWorker
    {
        public void BuildHouse(House house)
        {
            while (!house.IsBuilt())
            {
                house.BuildNextPart();
            }
        }
    }

    class TeamLeader : IWorker
    {
        public void BuildHouse(House house)
        {
            while (!house.IsBuilt())
            {
                Console.Clear();
                house.PrintHouse();
                Console.WriteLine("Отчет:");
                foreach (IPart part in house.parts)
                {
                    Console.WriteLine(part.GetName() + ": " + (part.IsBuilt ? "Построено" : "Не построено"));
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите Enter для продолжения.");
                Console.ReadLine();
                house.BuildNextPart();
            }
            house.PrintHouse();
            Console.WriteLine("Дом построен!!!");
        }
    }

    class Team
    {
        private List<IWorker> workers;

        public Team()
        {
            workers = new List<IWorker>();
            workers.Add(new Worker());
            workers.Add(new TeamLeader());
        }

        public void BuildHouse(House house)
        {
            Random random = new Random();
            
            while (!house.IsBuilt())
            {
               
                int workerIndex = random.Next(workers.Count);
                
                workers[workerIndex].BuildHouse(house);
                
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            
                House house = new House();
                Team team = new Team();
                team.BuildHouse(house);
            //если с первого раза вывелось что все построено перезапустить программу надо)))
            
        }
    }
}
