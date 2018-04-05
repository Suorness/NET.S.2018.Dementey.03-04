namespace GCDAlgorithm
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Calculates greatest common divisor of numbers  by different methods.
    /// Euclidean and Stein's algorithms.
    /// </summary>
    public static class GCDSeeker
    {
        #region public method
        /// <summary>
        /// Finds the greatest common divisor of numbers by the Euclidean algorithm.
        /// </summary>
        ///  <param name="numbers">Numbers to find greatest common divisor.</param> 
        /// <exception cref="ArgumentNullException">
        /// Throws if numbers array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if length of an array of numbers  is smaller than 2.
        /// </exception>
        /// <returns> The greatest common divisor of numbers array. </returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            return CalculateGcd(Euclid, numbers);
        }

        /// <summary>
        /// Finds the greatest common divisor of numbers by the Euclidean algorithm.
        /// </summary>
        /// <param name="leadTime">Algorithm execution time.</param> 
        /// <param name="numbers">Numbers to find greatest common divisor.</param> 
        /// <exception cref="ArgumentNullException">
        /// Throws if numbers array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if length of an array of numbers  is smaller than 2.
        /// </exception>
        /// <returns> The greatest common divisor of numbers array. </returns>
        public static int EuclideanAlgorithm(out TimeSpan leadTime, params int[] numbers)
        {
            return CalculateTime(() => EuclideanAlgorithm(numbers), out leadTime);
        }

        /// <summary>
        /// Finds the greatest common divisor of numbers by the Stein's algorithm.
        /// </summary>
        ///  <param name="numbers">Numbers to find greatest common divisor.</param> 
        /// <exception cref="ArgumentNullException">
        /// Throws if numbers array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if length of an array of numbers  is smaller than 2.
        /// </exception>
        /// <returns> The greatest common divisor of numbers array.</returns>
        public static int SteinAlgorithm(params int[] numbers)
        {
            return CalculateGcd(Stein, numbers);
        }

        /// <summary>
        /// Finds the greatest common divisor of numbers by the Stein's algorithm.
        /// </summary>
        /// <param name="leadTime">Algorithm execution time.</param> 
        /// <param name="numbers">Numbers to find greatest common divisor.</param> 
        /// <exception cref="ArgumentNullException">
        /// Throws if numbers array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws if length of an array of numbers  is smaller than 2.
        /// </exception>
        /// <returns> The greatest common divisor of numbers array.</returns>
        public static int SteinAlgorithm(out TimeSpan leadTime, params int[] numbers)
        {
            return CalculateTime(() => SteinAlgorithm(numbers), out leadTime);
        }
        #endregion public method

        #region private method
        private static int Euclid(int value1, int value2)
        {
            if (value1.Equals(0))
            {
                return value2;
            }

            if (value2.Equals(0))
            {
                return value1;
            }

            while (value1 != value2)
            {
                if (value1 > value2)
                {
                    value1 = value1 - value2;
                }
                else
                {
                    value2 = value2 - value1;
                }
            }

            return value1;
        }

        private static int Stein(int value1, int value2)
        {
            if (value1.Equals(0))
            {
                return value2;
            }

            if (value2.Equals(0))
            {
                return value1;
            }

            int shitf;

            for (shitf = 0; ((value1 | value2) & 1) == 0; shitf++)
            {
                value1 >>= 1;
                value2 >>= 1;
            }

            while ((value1 & 1) == 0)
            {
                value1 >>= 1;
            }

            do
            {
                while ((value2 & 1) == 0)
                {
                    value2 >>= 1;
                }

                if (value1 > value2)
                {
                    var temp = value2;
                    value2 = value1;
                    value1 = temp;
                }

                value2 -= value1;
            }
            while (value2 != 0);

            return value1 << shitf;
        }

        private static int[] AbsArray(int[] array)
        {
            var absArray = new int[array.Length];
            Array.Copy(array, absArray, array.Length);

            for (int i = 0; i < absArray.Length; i++)
            {
                absArray[i] = Math.Abs(absArray[i]);
            }

            return absArray;
        }

        private static int CalculateTime(Func<int> function, out TimeSpan leadTime)
        {
            var watcher = Stopwatch.StartNew();
            var result = function();
            watcher.Stop();
            leadTime = watcher.Elapsed;

            return result;
        }

        private static int CalculateGcd(Func<int,int,int> func, int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException(nameof(numbers));
            }

            numbers = AbsArray(numbers);

            int resultGCD = numbers[numbers.Length - 1];
            int i = numbers.Length - 2;
            do
            {
                resultGCD = func(resultGCD, numbers[i]);
                i--;
            }
            while (i > 0);

            return resultGCD;
        }
        #endregion private method
    }
}
