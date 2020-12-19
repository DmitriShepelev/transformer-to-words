using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CA1822
#pragma warning disable CA1305
#pragma warning disable CA1304

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            var result = new string[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = TransformToWords(source[i]);
            }

            return result;
        }

        private static string TransformToWords(double number)
        {
            if (double.IsNaN(number))
            {
                return "Not a Number";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }

            if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            var dict = new Dictionary<char, string>()
            {
                { '-', "Minus" },
                { '0', "zero" },
                { ',', "point" },
                { '.', "point" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { 'E', "E" },
                { '+', "plus" },
            };

            var sb = new StringBuilder();
            for (int i = 0; i < number.ToString().Length; i++)
            {
                sb.Append(dict[number.ToString()[i]]);
                sb.Append(" ");
            }

            sb[0] = char.ToUpper(sb[0]);
            return new string(sb.ToString().TrimEnd());
        }
    }
}
