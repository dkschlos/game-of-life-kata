using GameOfLifeKata.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOfLifeKataTest
{
    [TestClass]
    public class RandomBoardFactoryTest
    {
        [TestMethod]
        public void CreateReturnsBoardWithGivenDimensions()
        {
            int width = 10;
            int height = 12;
            var initializer = new RandomGameOfLifeBoardFactory();

            var board = initializer.Create(width, height, Mock.Of<NeighborshipInitializer>());

            Assert.AreEqual(width, board.Width);
            Assert.AreEqual(height, board.Height);
            Assert.AreEqual(width, board.Cells.Length);
            for (int i = 0; i < width; i++)
            {
                Assert.AreEqual(height, board.Cells[i].Length);
            }
        }

        [TestMethod]
        public void CreateInitializesNeighborship()
        {
            var initializer = new RandomGameOfLifeBoardFactory();
            var neighborshipInitializer = new Mock<NeighborshipInitializer>();

            var board = initializer.Create(1, 1, neighborshipInitializer.Object);
            
            neighborshipInitializer.Verify(i => i.Initialize(board));
        }
    }
}
