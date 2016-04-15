using System.Collections.Generic;
using CSharpKatas.Sudoku;
using NUnit.Framework;

namespace CSharpKataTests.Sudoku
{
    [TestFixture]
    public class SquareTest
    {
        [Test]
        public void Test_4xSquare_GetAllValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3, 4 }, square.GetValues());
        }

        [Test]
        public void Test_9xSquare_GetAllValues()
        {
            // arrange
            var square = new Square(new int[3, 3] { { 3, 9, 4 }, { 0, 0, 0 }, { 5, 0, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3, 9, 4, 5 }, square.GetValues());
        }

        [Test]
        public void Test_Square_GetRowValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 3 }, square.GetRowValues(0));
            CollectionAssert.AreEqual(new List<int> { 4 }, square.GetRowValues(1));
        }

        [Test]
        public void Test_Square_GetColumnValues()
        {
            // arrange
            var square = new Square(new int[2, 2] { { 0, 3 }, { 4, 0 } });

            // act and assert
            CollectionAssert.AreEqual(new List<int> { 4 }, square.GetColumnValues(0));
            CollectionAssert.AreEqual(new List<int> { 3 }, square.GetColumnValues(1));
        }
    }
}
