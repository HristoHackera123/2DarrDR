namespace OutputElements
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
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(arr[row, col] + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
