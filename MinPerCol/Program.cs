using System.Buffers;

namespace MinPerCol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give rows and columns (on diff lines)");
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] arr = new int[rows, cols];
            Console.WriteLine($"Input the array like a spreadsheet, with {cols} nums per line");
            for (int row = 0; row < rows; row++)
            {

                int[] rowArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = rowArr[col];
                }
            }

            int[] minArr = new int[cols];
            int minRow = 0;
            int minValue = int.MaxValue;
            int counter = 0;

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (arr[row, col] < minValue)
                    {
                        minValue = arr[row, col];
                        minRow = row;
                    }
                }
                minArr[counter] = arr[minRow, col];
                counter++;
                minValue = int.MaxValue;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0, 5}", arr[row, col]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < minArr.Length; i++)
            {
                Console.Write("{0, 5}", minArr[i]);
            }
        }
    }
}
