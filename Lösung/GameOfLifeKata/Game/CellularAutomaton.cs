namespace GameOfLifeKata.Game
{
    public class CellularAutomaton
    {
        private readonly Updater updater;

        public CellularAutomaton(Board board, Updater updater)
        {
            this.updater = updater;
            Board = board;
        }
        public Board Board { get; private set; }

        public void Update()
        {
            updater.Update(Board);
        }
    }
}
