using System.Collections.Generic;

namespace GameOfLifeKata.Game
{
    public class Cell
    {
        public Cell(CellState state) : this(state, new List<Cell>())
        {
            
        }
        public Cell(CellState state, List<Cell> neighbors)
        {
            State = state;
            Neighbors = neighbors;
        }

        public CellState State { get; set; }
        public List<Cell> Neighbors { get; private set; } 
    }
}
