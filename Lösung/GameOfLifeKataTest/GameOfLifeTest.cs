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

            return boardFactory.Object;
        }
    }
}
