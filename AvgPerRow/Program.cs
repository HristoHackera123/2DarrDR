namespace AvgPerRow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give rows and columns (on diff lines)");
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,] arr = new int[rows, cols];
            Console.WriteLine("Input elements, each on new line");
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = int.Parse(Console.ReadLine());
                }
            }
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0, 10}", arr[row, col]);
                    sum+= arr[row, col];
                }
                Console.Write("{0, 10}", (double)sum/cols);
                Console.WriteLine();
            }
        }
    }
}
