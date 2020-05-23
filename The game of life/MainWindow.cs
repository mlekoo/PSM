using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace The_game_of_life
{
    public partial class MainWindow : Window
    {
        const int cellSize = 18;
      //  int cellsToSurvive = [2]
        private Cell[,] cells;

        private GameSettings gameSettings;
        private void DrawCells()
        {
            int countOfAliveNeighbours;



            foreach (var cell in cells)
            {
                countOfAliveNeighbours = 0;
                foreach (var neighbour in getCellNeighbours(cell))
                {

                    if (cells[(int)neighbour.X, (int)neighbour.Y].isAlive)
                    {
                        countOfAliveNeighbours++;
                    }


                }



                if (cell.isAlive)
                {
                    bool isStayingAlive = false;
                    foreach (var howManyToSurvive in gameSettings.howManyAliveNeighboursToSurvive)
                    {
                        if (howManyToSurvive == countOfAliveNeighbours)
                        {
                            isStayingAlive = true;
                        }
                    }

                    if (!isStayingAlive)
                    {
                        cell.setIsAlive(false);
                    }

                    bool isToBeBorn = false;
                    foreach (var howManyToBeBorn in gameSettings.howManyAliveNeighboursToBeBorn)
                    {
                        if (howManyToBeBorn == countOfAliveNeighbours)
                        {
                            isToBeBorn = true;
                        }
                    }
                    if (isToBeBorn)
                    {
                        cell.setIsAlive(true);

                    }
                }
            }
        }
        private void BtnKill_Click(object sender, EventArgs e) {
                foreach (var cell in cells) {
                    cell.setIsAlive(false);
                }
        }
        private void GamePlate_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(MainPlate);
            p.X = p.X / cellSize;
            p.Y = p.Y / cellSize;

            if (cells[(int)p.X, (int)p.Y].isAlive)
            {
                cells[(int)p.X, (int)p.Y].setIsAlive(false);
            }
            else {
                cells[(int)p.X, (int)p.Y].setIsAlive(true);
            }
        }
        public void BtnStartSimulation_Click(object sender, EventArgs e) {
            Debug.WriteLine("X");
            if (gameTickTimer.IsEnabled == false)
            {
                KillButton.Visibility = System.Windows.Visibility.Hidden;
                gameTickTimer.Interval = TimeSpan.FromMilliseconds(getInterval());
                gameSettings = getGameSettings();
                gameTickTimer.IsEnabled = true;
                startSimulationButton.Content = "Pause Simulation";
            }
            else {
                KillButton.Visibility = System.Windows.Visibility.Visible;
                gameTickTimer.IsEnabled = false;
                startSimulationButton.Content = "Start Simulation";
            }
        }
        public long getInterval() {
            return long.Parse(IntervalTextBox.Text);
        }
        
        public GameSettings getGameSettings() {
            var data = GameSettingsTextBox.Text.Split("/");

            if (data.Length != 2)
            {

                throw new FormatException("Wrong format of game settings...");

            }
            else
            {
                char[] charArray0 = data[0].ToCharArray();
                char[] charArray1 = data[1].ToCharArray();

                GameSettings gs = new GameSettings();
                for (int i = 0; i < charArray0.Length; i++) {
                    gs.howManyAliveNeighboursToSurvive.Add((int)Char.GetNumericValue(charArray0[i]));


                }
                for (int i = 0; i < charArray1.Length; i++)
                {
                    gs.howManyAliveNeighboursToBeBorn.Add((int)Char.GetNumericValue(charArray1[i]));
                }
                return gs;
            }
        }
        public void Window_ContentRendered(object sender, EventArgs e)
        {
            cells = new Cell[(int)GamePlate.ActualWidth / cellSize, (int)GamePlate.ActualWidth / cellSize];
            DrawGamePlate();

           

            
        }
        private List<Point> getCellNeighbours(Cell cell) {
            List<Point> neighbours = new List<Point>();
            int k = 0;
            for (int i = (int)cell.position.X - 1; i <= (int)cell.position.X + 1; i++) {
                for (int j = (int)cell.position.Y - 1; j <= (int)cell.position.Y + 1; j++) {
                    if (i >= 0) {
                        if (i < GamePlate.ActualWidth / cellSize) {
                            if (j >= 0) {
                                if (j < GamePlate.ActualHeight / cellSize) {
                                    if (!(i == (int)cell.position.X && j == (int)cell.position.Y))
                                    {
                                        neighbours.Add(new Point(i, j));
                                        k++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return neighbours;
        }
        private void DrawGamePlate()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int x; 
            int y;
            

            while (doneDrawingBackground == false)
            {
                x = nextX / cellSize;
                y = nextY / cellSize;
                Cell cell = new Cell
                {
                    isAlive = false,
                    position = new Point(x, y),
                    uiElement = new Rectangle
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Stroke = Brushes.Black,
                        Fill = Brushes.DarkGray
                    }
                };

                cells[x,y] = cell;
                
                GamePlate.Children.Add(cell.uiElement);
                Canvas.SetTop(cell.uiElement, nextY);
                Canvas.SetLeft(cell.uiElement, nextX);

                nextX += cellSize;
                if (nextX >= GamePlate.ActualWidth)
                {
                    nextX = 0;
                    nextY += cellSize;
                    
                }

                if (nextY >= GamePlate.ActualHeight)
                    doneDrawingBackground = true;
            }
        }
    }
}
