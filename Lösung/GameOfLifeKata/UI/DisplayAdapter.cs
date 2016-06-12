using GameOfLifeKata.Game;
using System.Threading;
using System.Windows;

namespace GameOfLifeKata.UI
{
    public class DisplayAdapter
    {
        public void Run()
        {
            var mainWindow = new MainWindow();
            Thread worker = new Thread(() =>
            {
                var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(100, 100);
                while (true)
                {
                    Thread.Sleep(500);

                    var transformedCells = Transform(gameOfLife.Board);
                    Application.Current.Dispatcher.Invoke(() => mainWindow.Draw(transformedCells, gameOfLife.Board.Width, gameOfLife.Board.Height));
                    gameOfLife.Update();
                }
            });

            mainWindow.Closing += (sender, args) => worker.Abort();
            mainWindow.Show();
            worker.Start();
        }

        private static int[][] Transform(Board board)
        {
            int[][] result = new int[board.Width][];
            for (int i = 0; i < board.Width; i++)
            {
                result[i] = new int[board.Height];
                for (int j = 0; j < board.Height; j++)
                {
                    result[i][j] = board.Cells[i][j].State.Value;
                }

            }

            return result;
        }
    }
}
