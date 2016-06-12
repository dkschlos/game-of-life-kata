using GameOfLifeKata.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeKataTest
{
    [TestClass]
    public class BoundedNeighborshipInitializerTest
    {
        [TestMethod]
        public void InitializeSetsLeftCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell leftNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(1, 2, new[] {new[] {leftNeighbor, cellToTest}});
            var initializer = new BoundedNeighborshipInitializer(); 

            initializer.Initialize(board);

            Assert.AreEqual(1, cellToTest.Neighbors.Count);
            Assert.AreSame(leftNeighbor, cellToTest.Neighbors[0]);
        }

        [TestMethod]
        public void InitializeSetsRightCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell rightNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(1, 2, new[] { new[] { cellToTest, rightNeighbor } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.AreEqual(1, cellToTest.Neighbors.Count);
            Assert.AreSame(rightNeighbor, cellToTest.Neighbors[0]);
        }

        [TestMethod]
        public void InitializeSetsTopCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell topNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 1, new[] { new []{ topNeighbor }, new[] { cellToTest } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.AreEqual(1, cellToTest.Neighbors.Count);
            Assert.AreSame(topNeighbor, cellToTest.Neighbors[0]);
        }

        [TestMethod]
        public void InitializeSetsBottomCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell bottomNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 1, new[] { new[] { cellToTest }, new[] { bottomNeighbor } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.AreEqual(1, cellToTest.Neighbors.Count);
            Assert.AreSame(bottomNeighbor, cellToTest.Neighbors[0]);
        }

        [TestMethod]
        public void InitializeSetsLeftBottomCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell leftBottomNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 2, new[] { new[] { new Cell(GameOfLifeCellState.Dead), cellToTest,  }, new[] { leftBottomNeighbor, new Cell(GameOfLifeCellState.Alive),  } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.IsTrue(cellToTest.Neighbors.Contains(leftBottomNeighbor));
        }

        [TestMethod]
        public void InitializeSetsLeftTopCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell leftTopNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 2, new[] { new[] { leftTopNeighbor, new Cell(GameOfLifeCellState.Alive),  }, new [] { new Cell(GameOfLifeCellState.Dead), cellToTest, } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.IsTrue(cellToTest.Neighbors.Contains(leftTopNeighbor));
        }

        [TestMethod]
        public void InitializeSetsRightTopCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell rightTopNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 2, new[] { new[] { new Cell(GameOfLifeCellState.Dead), rightTopNeighbor }, new[] { cellToTest, new Cell(GameOfLifeCellState.Alive),  } });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.IsTrue(cellToTest.Neighbors.Contains(rightTopNeighbor));
        }

        [TestMethod]
        public void InitializeSetsRightBottomCellAsNeighbor()
        {
            Cell cellToTest = new Cell(GameOfLifeCellState.Dead);
            Cell rightBottomNeighbor = new Cell(GameOfLifeCellState.Alive);
            var board = new Board(2, 2, new[] { new[] { cellToTest, new Cell(GameOfLifeCellState.Alive),  }, new[] { new Cell(GameOfLifeCellState.Dead), rightBottomNeighbor }, });
            var initializer = new BoundedNeighborshipInitializer();

            initializer.Initialize(board);

            Assert.IsTrue(cellToTest.Neighbors.Contains(rightBottomNeighbor));
        }


        // TODO: Negativtests (z.B. Zelle zwei weiter rechts ist kein Nachbar)
    }
}
