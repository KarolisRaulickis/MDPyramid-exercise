using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //Column size = Row size
        private static int ArrayLength;

        private static int[][] TriangleData;
        private const int NumOfChildren = 2;
        private static string FullPath;
        private static int MaxSum;
        private static string input = @"215  
            192 124  
            117 269 442  
            218 836 347 235  
            320 805 522 417 345  
            229 601 728 835 133 124  
            248 202 277 433 207 263 257  
            359 464 504 528 516 716 871 182  
            461 441 426 656 863 560 380 171 923  
            381 348 573 533 448 632 387 176 975 449  
            223 711 445 645 245 543 931 532 937 541 444  
            330 131 333 928 376 733 017 778 839 168 197 197  
            131 171 522 137 217 224 291 413 528 520 227 229 928  
            223 626 034 683 839 052 627 310 713 999 629 817 410 121  
            924 622 911 233 325 139 721 218 253 223 107 233 230 124 233 ";

        private static void MoveDown(int column, int row, int sum, string path)
        {
            bool IsCurrentEven = IsEvenNumber(TriangleData[row] [column]);

            //If NOT reached bottom
            if (row != ArrayLength-1)
            {
                for (int j = 0; j < NumOfChildren; j++)
                {
                    int child = TriangleData[row+1] [column+j];

                    if (IsCurrentEven && !IsEvenNumber(child)   || !IsCurrentEven && IsEvenNumber(child))
                    {
                        MoveDown(column + j, row + 1, sum + child, row + 1 != ArrayLength - 1 ? path + child.ToString() + " -> ": path + child.ToString());
                    }
                }
            }
            else
            {  
                if (sum> MaxSum)
                {
                    MaxSum = sum;
                    FullPath = path;
                }
            }
        }

        private static bool IsEvenNumber(int num)
        {
            if (num % 2 == 0)
                return true;
            else
                return false;
        }

        private static void ReadTriangle()
        {
            var RowsOfChars = input.Split('\n');
            ArrayLength = RowsOfChars.Length;
            TriangleData = new int[ArrayLength][];
            
            for (int i = 0; i < RowsOfChars.Length; i++)
            {
                var SplitNumbersByRow = RowsOfChars[i].Trim().Split(' ');
                int[] Arr = new int[SplitNumbersByRow.Length];

                for (int j = 0; j < SplitNumbersByRow.Length; j++)
                {
                    int Num = Convert.ToInt32(SplitNumbersByRow[j]);
                    Arr[j]=Num;
                }
                TriangleData[i] = Arr;
            }
        }

        static void Main(string[] args)
        {
            ReadTriangle();
            MoveDown(0, 0, TriangleData[0][0], TriangleData[0][0].ToString() + " -> ");
              
            Console.WriteLine("Maximum : " + MaxSum);
            Console.WriteLine("Maximum total path: " + FullPath);
            Console.ReadLine();
        }
    }
}
