namespace GameOfLifeKata.Game
{
    public class BoundedNeighborshipInitializer : NeighborshipInitializer
    {
        public void Initialize(Board board)
        {
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    var cell = board.Cells[i][j];   
                    cell.Neighbors.Clear();
                    
                    if (i > 0)
                    {
                        // Links
                        cell.Neighbors.Add(board.Cells[i - 1][j]);

                        // Links Oben
                        if (j > 0)
                        {
                            cell.Neighbors.Add(board.Cells[i - 1][j - 1]);
                        }

                        // Links Unten
                        if (j < board.Height - 1)
                        {
                            cell.Neighbors.Add(board.Cells[i - 1][j + 1]);
                        }
                    }

                    if (i < board.Width - 1)
                    {
                        // Rechts
                        cell.Neighbors.Add(board.Cells[i + 1][j]);

                        // Rechts Oben
                        if (j > 0)
                        {
                            cell.Neighbors.Add(board.Cells[i + 1][j - 1]);
                        }

                        // Rechts Unten
                        if (j < board.Height - 1)
                        {
                            cell.Neighbors.Add(board.Cells[i + 1][j + 1]);
                        }
                    }

                    // Oben
                    if (j > 0)
                    {
                        cell.Neighbors.Add(board.Cells[i][j - 1]);
                    }

                    // Unten
                    if (j < board.Height - 1)
                    {
                        cell.Neighbors.Add(board.Cells[i][j + 1]);
                    }
                }
            
            }
        }
    }
}
