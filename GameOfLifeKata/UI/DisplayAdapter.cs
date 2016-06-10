using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GameOfLifeKata.Game;

namespace GameOfLifeKata.UI
{
    public class DisplayAdapter
    {
        public void Run()
        {
            var mainWindow = new MainWindow();
            Thread worker = new Thread(() =>
            {
                var board = new Board();
                while (true)
                {
                    Thread.Sleep(500);
                    Application.Current.Dispatcher.Invoke(() => mainWindow.Draw(board.Cells, board.Width, board.Height));
                }
            });

            mainWindow.Closing += (sender, args) => worker.Abort();
            mainWindow.Show();
            worker.Start();
            
        }
    }
}
