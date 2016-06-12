namespace GameOfLifeKata.Game
{
    public interface BoardFactory
    {
        Board Create(int width, int height, NeighborshipInitializer neighborshipInitializer);
    }
}
