using System;
using System.Collections.Generic;
using System.Text;

namespace ownsOne
{
    public class FootballTeam
    {
        public static FootballTeam Seville = new FootballTeam() { Id = 1, Name = "Seville" };
        public static FootballTeam Liverpool = new FootballTeam() { Id = 2, Name = "Liverpool" };

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
