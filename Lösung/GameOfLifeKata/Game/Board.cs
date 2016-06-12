namespace GameOfLifeKata.Game
{
    public class Board
    {
        public Board(int width, int height, Cell[][] cells)
        {
            Width = width;
            Height = height;
            Cells = cells;
        }

        public Cell[][] Cells { get; private set; }

       
        public int Width { get; private set; }

        public int Height { get; private set; }
    }
}
