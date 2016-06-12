using System;

namespace GameOfLifeKata.Game
{
    public class RandomGameOfLifeBoardFactory : BoardFactory
    {
        public Board Create(int width, int height, NeighborshipInitializer neighborshipInitializer)
        {
            var random = new Random();
            Cell[][] result = new Cell[width][];
            for (int i = 0; i < width; i++)
            {
                result[i] = new Cell[height];
                for (int j = 0; j < height; j++)
                {
                    result[i][j] = new Cell(random.Next(2) == 1 ? GameOfLifeCellState.Alive : GameOfLifeCellState.Dead);
                }
            }

            var board = new Board(width, height, result);
            neighborshipInitializer.Initialize(board);

            return board;
        }
    }
}
