Console.WriteLine("Enter number of rows: ");
int rows = int.Parse(Console.ReadLine());

Console.WriteLine("Enter number of columns: ");
int columns = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the elements of the matrix:");
int[] vals = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[,] matrix = new int[rows, columns];

int index = 0;

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrix[i, j] = vals[index++];
    }
}

Console.WriteLine("The matrix is:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("Matrix size: " + rows + " x " + columns);
Console.WriteLine("Write a slicing for the matrix (row_start, row_end, col_start, col_end):");

int[] sliceParams = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int rowStart = sliceParams[0]-1;
int rowEnd = sliceParams[1];
int colStart = sliceParams[2]-1;
int colEnd = sliceParams[3];

Console.WriteLine("The sliced matrix is:");
for (int i = rowStart; i < rowEnd; i++)
{
    for (int j = colStart; j < colEnd; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("The matrix visualization is:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if(i >= rowStart && i < rowEnd && j >= colStart && j < colEnd)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}