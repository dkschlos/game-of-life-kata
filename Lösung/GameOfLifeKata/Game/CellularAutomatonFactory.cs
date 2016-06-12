namespace GameOfLifeKata.Game
{
    public sealed class CellularAutomatonFactory
    {
        public static CellularAutomaton CreateGameOfLife(int width, int height)
        {
            var neighborshipInitializer = new BoundedNeighborshipInitializer();
            var randomBoardFactory = new RandomGameOfLifeBoardFactory();
            return CreateGameOfLife(width, height, randomBoardFactory, neighborshipInitializer);
        }

        public static CellularAutomaton CreateGameOfLife(int width, int height, BoardFactory boardFactory)
        {
            var neighborshipInitializer = new BoundedNeighborshipInitializer();
            return CreateGameOfLife(width, height, boardFactory, neighborshipInitializer);
        }

        public static CellularAutomaton CreateGameOfLife(int width, int height, BoardFactory boardFactory, NeighborshipInitializer neighborshipInitializer)
        {
            return new CellularAutomaton(boardFactory.Create(width, height, neighborshipInitializer), new GameOfLifeUpdater());
        }
    }
}
