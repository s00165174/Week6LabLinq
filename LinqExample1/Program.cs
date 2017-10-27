using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample1
{
    public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }

        public override string ToString()
        {
            return _id.ToString() + " " + _name + " " + _xp.ToString();
        }
    }
    class Program
    {
        //create list of players
        static List<Player> players = new List<Player>()
        {
            new Player { Id = Guid.NewGuid(), Name = "Pete Volga", Xp = 100 },
            new Player { Id = Guid.NewGuid(), Name = "Joe Bloggs", Xp = 10 },
            new Player { Id = Guid.NewGuid(), Name = "Pete Townsend", Xp = 200 },
            new Player { Id = Guid.NewGuid(), Name = "Mary Shelly", Xp = 300 }
        };

        static void Main(string[] args)
        {
            //return the first occourance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "Mary Shelly");
            if (found != null)
            {
                Console.WriteLine("{0}", found.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }
            Console.WriteLine("\n");
            //return the first occourance of some records
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Pete"));
            if (found1 != null)
            {
                Console.WriteLine("First Found: {0}", found1.ToString());
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            Console.WriteLine("\n");

            //return all those with xp value over or equal to 100
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 100).ToList();
            if (topPlayers.Count > 0)
            {
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No match found");
            }
            Console.WriteLine("\n");

            //return scoreboard, highest scores first
            Console.WriteLine("Top Scores");
            var Scoreboard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select(scores => new { scores.Name, scores.Xp });//this is a dynamic collection / anonymous object
            foreach (var item in Scoreboard)
            {
                Console.WriteLine("{0} - {1} xp", item.Name, item.Xp);
            }


            Console.ReadKey();
        }
    }
}
