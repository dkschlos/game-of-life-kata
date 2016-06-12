using GameOfLifeKata.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GameOfLifeKataTest
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void UpdateKillsCellsWithLessThanTwoNeighbors()
        {
            Cell[][] boardConfiguration = new [] { new []{ new Cell(GameOfLifeCellState.Alive, new List<Cell>() {new Cell(GameOfLifeCellState.Alive)})}};
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Dead, gameOfLife.Board.Cells[0][0].State);

        }

        [TestMethod]
        public void UpdateLetsCellsWithExactlyTwoAliveNeighborsSurvive()
        {
            Cell[][] boardConfiguration = new[] { new[] { new Cell(GameOfLifeCellState.Alive, new List<Cell>() { new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive) }) } };
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Alive, gameOfLife.Board.Cells[0][0].State);

        }

        [TestMethod]
        public void UpdateIgnoresDeadCellsWithLessThanThreeAliveNeighbors()
        {
            Cell[][] boardConfiguration = new[] { new[] { new Cell(GameOfLifeCellState.Dead, new List<Cell>() { new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive) }) } };
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Dead, gameOfLife.Board.Cells[0][0].State);

        }

        [TestMethod]
        public void UpdateIgnoresDeadCellsWithMoreThanThreeAliveNeighbors()
        {
            Cell[][] boardConfiguration = new[] { new[] { new Cell(GameOfLifeCellState.Dead, new List<Cell>() { new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive) }) } };
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Dead, gameOfLife.Board.Cells[0][0].State);

        }

        [TestMethod]
        public void UpdateKillsAliveCellsWithMoreThanThreeAliveNeighbors()
        {
            Cell[][] boardConfiguration = new[] { new[] { new Cell(GameOfLifeCellState.Alive, new List<Cell>() { new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive) }) } };
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Dead, gameOfLife.Board.Cells[0][0].State);

        }

        [TestMethod]
        public void UpdateResurrectsDeadCellsWithExactlyThreeAliveNeighbors()
        {
            Cell[][] boardConfiguration = new[] { new[] { new Cell(GameOfLifeCellState.Dead, new List<Cell>() { new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive), new Cell(GameOfLifeCellState.Alive) }) } };
            var gameOfLife = CellularAutomatonFactory.CreateGameOfLife(1, 1, CreateMockBoardFactory(1, 1, boardConfiguration));

            gameOfLife.Update();

            Assert.AreEqual(GameOfLifeCellState.Alive, gameOfLife.Board.Cells[0][0].State);

        }

        private BoardFactory CreateMockBoardFactory(int width, int height, Cell[][] boardConfiguration)
        {
            var boardFactory = new Mock<BoardFactory>();
            boardFactory.Setup(b => b.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<NeighborshipInitializer>()))
                        .Returns(new Board(width, height, boardConfiguration));

            MoqShowcase();
            return boardFactory.Object;
        }


        private interface Useless
        {
            int GetResult(long param);
        }

        private void MoqShowcase()
        {
            var usefulMock = new Mock<Useless>();
            // Calls to this mock will always return 42
            usefulMock.Setup(u => u.GetResult(It.IsAny<long>())).Returns(42);

            Useless instanceOfMockedInterface = usefulMock.Object;
            // Pass as dependency, for example:
            // var service = new Service(instanceofMockedInterface);
            // service.Run();

            // Verify method was called with any parameter or explicit param value (line 2)
            usefulMock.Verify(u => u.GetResult(It.IsAny<long>()));
            usefulMock.Verify(u => u.GetResult(21));
        }
    }
}
