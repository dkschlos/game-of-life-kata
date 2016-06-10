using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLifeKata.UI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int CELL_SIZE = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Zeichnet den aktuellen Zustand des Spielfelds
        /// </summary>
        /// <param name="board">Spielfeldbeschreibung, 0 = tot, alle anderen Zahlen = lebendig</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(int[][] board, int width, int height)
        {
            canvas.Children.Clear();
            canvas.Width = width * CELL_SIZE;
            canvas.Height = height * CELL_SIZE;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (board[j][i] != 0)
                    {
                        var rect = new Rectangle();
                        rect.Width = CELL_SIZE;
                        rect.Height = CELL_SIZE;
                        rect.Stroke = new SolidColorBrush(Colors.Black);
                        rect.Fill = new SolidColorBrush(Colors.Black);
                        rect.StrokeThickness = 1;

                        canvas.Children.Add(rect);
                        Canvas.SetLeft(rect, i * CELL_SIZE);
                        Canvas.SetTop(rect, j * CELL_SIZE);
                    }
                }
            }
        }
    }
}
