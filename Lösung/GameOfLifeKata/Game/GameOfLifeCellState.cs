namespace GameOfLifeKata.Game
{
    public sealed class GameOfLifeCellState
    {
        public static readonly CellState Alive = new CellState(1, "Alive");
        public static readonly CellState Dead = new CellState(0, "Dead");
    }
}
