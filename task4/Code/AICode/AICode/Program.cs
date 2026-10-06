using System;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    static int[,] SliceMatrix(
        int[,] matrix,
        int rowStart,
        int rowEnd,
        int colStart,
        int colEnd)
    {
        int rows = rowEnd - rowStart;
        int cols = colEnd - colStart;

        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[rowStart + i, colStart + j];
            }
        }

        return result;
    }

    static void CreateMatrixImage(
        int[,] matrix,
        int rowStart,
        int rowEnd,
        int colStart,
        int colEnd)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int cellSize = 80;
        int startX = 50;
        int startY = 100;

        int width = startX * 2 + cols * cellSize;
        int height = startY + rows * cellSize + 70;

        using Bitmap bitmap = new Bitmap(width, height);
        using Graphics g = Graphics.FromImage(bitmap);

        g.Clear(Color.White);

        using Font titleFont = new Font("Arial", 20, FontStyle.Bold);
        using Font numberFont = new Font("Arial", 18);
        using Font infoFont = new Font("Arial", 14);
        using Pen gridPen = new Pen(Color.Black, 2);

        string title =
            $"2D Matrix Slicing: matrix[{rowStart}:{rowEnd}, {colStart}:{colEnd}]";

        g.DrawString(
            title,
            titleFont,
            Brushes.Black,
            20,
            30
        );

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int x = startX + j * cellSize;
                int y = startY + i * cellSize;

                bool isSliced =
                    i >= rowStart &&
                    i < rowEnd &&
                    j >= colStart &&
                    j < colEnd;

                if (isSliced)
                {
                    g.FillRectangle(
                        Brushes.LightBlue,
                        x,
                        y,
                        cellSize,
                        cellSize
                    );
                }
                else
                {
                    g.FillRectangle(
                        Brushes.White,
                        x,
                        y,
                        cellSize,
                        cellSize
                    );
                }

                g.DrawRectangle(
                    gridPen,
                    x,
                    y,
                    cellSize,
                    cellSize
                );

                string number = matrix[i, j].ToString();

                SizeF textSize =
                    g.MeasureString(number, numberFont);

                float textX =
                    x + (cellSize - textSize.Width) / 2;

                float textY =
                    y + (cellSize - textSize.Height) / 2;

                g.DrawString(
                    number,
                    numberFont,
                    Brushes.Black,
                    textX,
                    textY
                );
            }
        }

        string explanation =
            $"Highlighted region = matrix[{rowStart}:{rowEnd}, {colStart}:{colEnd}]";

        g.DrawString(
            explanation,
            infoFont,
            Brushes.Black,
            20,
            startY + rows * cellSize + 15
        );

        bitmap.Save(
            "matrix_result.png",
            ImageFormat.Png
        );

        Console.WriteLine("\nImage created: matrix_result.png");
    }

    static void Main()
    {
        Console.Write("Rows of matrix: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Columns of matrix: ");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter matrix:");

        int[] values = Array.ConvertAll(
            Console.ReadLine().Split(),
            int.Parse
        );

        if (values.Length != rows * cols)
        {
            Console.WriteLine("Incorrect number of matrix elements.");
            return;
        }

        int[,] matrix = new int[rows, cols];

        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = values[index++];
            }
        }

        Console.WriteLine("\nOriginal matrix:");
        PrintMatrix(matrix);

        Console.WriteLine(
            "\nEnter slicing (row_start row_end col_start col_end):"
        );

        int[] slicing = Array.ConvertAll(
            Console.ReadLine().Split(),
            int.Parse
        );

        if (slicing.Length != 4)
        {
            Console.WriteLine("Enter exactly four values.");
            return;
        }

        int rowStart = slicing[0];
        int rowEnd = slicing[1];
        int colStart = slicing[2];
        int colEnd = slicing[3];

        if (
            rowStart < 0 ||
            rowEnd > rows ||
            colStart < 0 ||
            colEnd > cols ||
            rowStart >= rowEnd ||
            colStart >= colEnd
        )
        {
            Console.WriteLine("Invalid slicing range.");
            return;
        }

        int[,] sliced = SliceMatrix(
            matrix,
            rowStart,
            rowEnd,
            colStart,
            colEnd
        );

        Console.WriteLine("\nSliced matrix:");
        PrintMatrix(sliced);

        CreateMatrixImage(
            matrix,
            rowStart,
            rowEnd,
            colStart,
            colEnd
        );
    }
}