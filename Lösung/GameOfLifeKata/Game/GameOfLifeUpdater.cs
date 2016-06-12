using System.Linq;

namespace GameOfLifeKata.Game
{
    public class GameOfLifeUpdater : Updater
    {
        public void Update(Board board)
        {
            CellState[][] newStates = new CellState[board.Width][];
            for (int i = 0; i < board.Width; i++)
            {
                newStates[i] = new CellState[board.Height];
                for (int j = 0; j < board.Height; j++)
                {
                    var cell = board.Cells[i][j];
                    CellState newState = cell.State;
                    var aliveNeighborCount = cell.Neighbors.Count(n => n.State == GameOfLifeCellState.Alive);
                    if (aliveNeighborCount < 2)
                    {
                        newState = GameOfLifeCellState.Dead;
                    }
                    else if (aliveNeighborCount == 3)
                    {
                        newState = GameOfLifeCellState.Alive;
                    }
                    else if (aliveNeighborCount > 3)
                    {
                        newState = GameOfLifeCellState.Dead;
                    }

                    newStates[i][j] = newState;
                }
            }

            UpdateCellStates(board, newStates);
        }

        private void UpdateCellStates(Board board, CellState[][] newStates)
        {
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    board.Cells[i][j].State = newStates[i][j];
                }
            }
        }
    }
}
