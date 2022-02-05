namespace DinoSoft.CuCounters.Common.Extensions
{
    /// <summary>
    /// Разрешения для <see cref="int"/>
    /// </summary>
    public static class IntExtension
    {
        /// <summary>
        /// Получить массив значений.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Массив значений.</returns>
        public static int[] ToArray(this int value)
        {
            var result = new int[value.Lenght()];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = value % 10;
                value /= 10;
            }

            return result;
        }

        /// <summary>
        /// Получить длинну.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Длинна.</returns>
        public static int Lenght(this int value)
        {
            int lenght = 0;
            do 
            {
                lenght++;
                value /= 10;
            } while (value != 0);

            return lenght;
        }
    }
}
