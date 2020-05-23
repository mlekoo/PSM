using System;
using System.Collections.Generic;
using System.Text;

namespace The_game_of_life
{
    public class GameSettings
    {
        public List<int> howManyAliveNeighboursToBeBorn { get; set; }
        public List<int> howManyAliveNeighboursToSurvive { get; set; }

        public GameSettings() {
            howManyAliveNeighboursToBeBorn = new List<int>();
            howManyAliveNeighboursToSurvive = new List<int>();
        }
    }
}
