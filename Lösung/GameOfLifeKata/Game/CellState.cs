namespace GameOfLifeKata.Game
{
    public class CellState
    {
        public CellState(int val, string name)
        {
            Value = val;
            Name = name;
        }
        public int Value { get; private set; }
        public string Name { get; private set; }
        
    }
}
