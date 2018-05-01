using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoinChangerKataVp;

namespace CoinChangerKataVpTest
{
    [TestClass]
    public class CoinChangerShould
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void ReturnExactChange_WhenUsingOneCoin()
        {
            // Expectation
            int[] expected = new int[] { 5 };

            // Arrange
            int[] denominatorArray = new int[] { 1 };
            int changeAmount = 5;

            // Act
            var result = CoinChanger.Compute(changeAmount, denominatorArray);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        public void ReturnExactChange_WhenUsingTwoCoins()
        {
            // Expectation
            int[] expected = new int[] { 0, 1 };

            // Arrange
            int[] denominatorArray = new int[] { 1, 5 };
            int changeAmount = 5;

            // Act
            var result = CoinChanger.Compute(changeAmount, denominatorArray);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(UnchangeableAmountException))]
        public void Throw_WhenChangeAmountIsUnchangeable()
        {
            // Expectation

            // Arrange
            int[] denominatorArray = new int[] { 5, 10 };
            int changeAmount = 4;

            // Act
            var result = CoinChanger.Compute(changeAmount, denominatorArray);

            // Assert
        }

        [TestMethod]
        public void ReturnExactChange_WhenDenominationNotSorted()
        {
            // Expectation
            int[] expected = new int[] { 3, 0, 1 };

            // Arrange
            int[] denominatorArray = new int[] { 5, 1, 2 };
            int changeAmount = 17;

            // Act
            var result = CoinChanger.Compute(changeAmount, denominatorArray);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDenominationException))]
        public void Throw_WhenDenominationIsInvalid()
        {
            // Expectation

            // Arrange
            int[] denominatorArray = new int[] { 5, 10, 10 };
            int changeAmount = 4;

            // Act
            var result = CoinChanger.Compute(changeAmount, denominatorArray);

            // Assert
        }
    }
}
