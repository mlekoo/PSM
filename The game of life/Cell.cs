using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace The_game_of_life
{
    public class Cell
    {
        public Rectangle uiElement { get; set; }
        public bool isAlive { get; set; }

        public Point position { get; set; }

        public Cell(bool isAlive) {
            this.isAlive = isAlive;
        }
        public Cell() { }

        public void setIsAlive(bool isAlive)
        {
            if (isAlive)
            {
                this.isAlive = true;
                this.uiElement.Fill = Brushes.Green;
            }
            else {
                this.isAlive = false;
                this.uiElement.Fill = Brushes.DarkGray;
            }

        }

    }
}
