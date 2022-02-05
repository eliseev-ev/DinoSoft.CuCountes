using DinoSoft.CuCounters.Common.Extensions;
using NUnit.Framework;

namespace DinoSoft.CuCounters.Common.Tests.Extensions
{
    /// <summary>
    /// Тест <see cref="IntExtensions"/>.
    /// </summary>
    public class IntExtensionsTests
    {
        /// <summary>
        /// Тестирование <see cref="IntExtensions.ToArrayTests(int)"/> метода.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Результат (массив).</returns>
        [TestCase(0, ExpectedResult = new int[] { 0 })]
        [TestCase(1, ExpectedResult = new int[] { 1 })]
        [TestCase(12, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(123, ExpectedResult = new int[] { 1, 2, 3 })]
        [TestCase(1234, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(12345, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(123456, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(1234567, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(12345678, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(123456789, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(1234567890, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 })]
        public int[] ToArrayTests(int value)
        {
            return value.ToArray();
        }

        /// <summary>
        /// Тестирование <see cref="IntExtensions.LenghtTests(int)"/> метода.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Длинна.</returns>
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(123, ExpectedResult = 3)]
        [TestCase(1234, ExpectedResult = 4)]
        [TestCase(12345, ExpectedResult = 5)]
        [TestCase(123456, ExpectedResult = 6)]
        [TestCase(1234567, ExpectedResult = 7)]
        [TestCase(12345678, ExpectedResult = 8)]
        [TestCase(123456789, ExpectedResult = 9)]
        [TestCase(1234567890, ExpectedResult = 10)]
        public int LenghtTests(int value)
        {
            return value.Lenght();
        }
    }
}
