using System.Data;

namespace LotteryTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input rows and cols on same line");
            string[] input = Console.ReadLine().Split();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            uint[,] arr = new uint[rows, cols];
            Console.WriteLine($"Input the array like a spreadsheet, with {cols} nums per line");
            for (int row = 0; row < rows; row++)
            {
                uint[] rowArr = Console.ReadLine().Split().Select(uint.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    arr[row, col] = rowArr[col];
                }
            }
            if (WinCon1(arr, rows, cols) && WinCon2(arr, rows, cols) && WinCon3(arr, rows, cols))
            {
                Console.WriteLine("YES");
                Console.WriteLine($"The amount of money won is: {FindMoney(arr, rows, cols):f2}");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static bool WinCon1(uint[,] arr, int rows, int cols)
        {
            bool result = false;
            uint sumMain = 0;
            uint sumSec = 0;
            int sRow = 0;
            int sCol = cols - 1;
            for (int i = 0; i < rows; i++)
            {
                sumMain += arr[i, i];
                sumSec += arr[sRow, sCol];
                sRow++;
                sCol--;
            }
            if (sumMain == sumSec)
            {
                result = true;
            }
            return result;
        }
        static bool WinCon2(uint[,] arr, int rows, int cols) //over
        {
            bool result = false;
            uint sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row - col < 0)
                    {
                        sum += arr[row, col];
                    }
                }
            }
            if (sum % 2 == 0)
            {
                result = true;
            }
            return result;
        }
        static bool WinCon3(uint[,] arr, int rows, int cols) //under
        {
            bool result = false;
            uint sum = 0;
            for (int row = 1; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row - col > 0)
                    {
                        sum += arr[row, col];
                    }
                }
            }
            if (sum % 2 != 0)
            {
                result = true;
            }
            return result;
        }
        static double FindMoney(uint[,] arr, int rows, int cols)
        {
            uint sum1 = 0; // vsichki pod gl. diag.
            for (int row = 1; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row - col > 0)
                    {
                        sum1 += arr[row, col];
                    }
                }
            }

            uint sum2 = 0; //chetni na gl. diag.
            for (int i = 0; i < rows; i++)
            {
                if (arr[i, i] % 2 == 0)
                {
                    sum2 += arr[i, i];
                }
            }

            uint sum3 = 0; //chetni na vunshni redove
            int firstRow = 0;
            int lastRow = rows - 1;
            for (int col = 0; col < cols; col++)
            {
                if (arr[firstRow, col] % 2 == 0)
                {
                    sum3 += arr[firstRow, col];
                }
                if (arr[lastRow, col] % 2 == 0)
                {
                    sum3 += arr[lastRow, col];
                }
            }

            uint sum4 = 0; //nechetni na vunshni 
            int firstCol = 0;
            int lastCol = cols - 1;
            for (int row = 0; row < rows; row++)
            {
                if (arr[row, firstCol] % 2 != 0)
                {
                    sum4 += arr[row, firstCol];
                }
                if (arr[row, lastCol] % 2 != 0)
                {
                    sum4 += arr[row, lastCol];
                }
            }
            return (double)(sum1 + sum2 + sum3 + sum4) / 4;
        }
    }
}
