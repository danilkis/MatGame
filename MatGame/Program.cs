// See https://aka.ms/new-console-template for more information

Console.WriteLine("Введите размер матрицы M (от 2 до 10)");
var M = Convert.ToInt16(Console.ReadLine());
if (M > 10 && M < 2)
{
    Console.WriteLine("Вне диапазона");
    return 0;
}
Console.WriteLine("Введите размер матрицы N (от 2 до 10)");
var N = Convert.ToInt16(Console.ReadLine());
if (N > 10 && N < 2)
{
    Console.WriteLine("Вне диапазона");
    return 0;
}
int i, j;
int[,] matrix = new int[N, M];

for (int o = 0; o < M; o++) {
    for (int p = 0; p < N; p++)
    {
        Random rnd = new Random();
        int rand_num  = rnd.Next(2, 12);
        matrix[o,p] = rand_num;
        Console.Write(matrix[o,p].ToString() + " ");
    }
    Console.WriteLine();
}
Console.WriteLine("\nМинимальное значение в строках: ");
List<int> price1 = new List<int>();
List<int> price2 = new List<int>();
for (int k = 0; k < M; k++)
{
    int minLine = matrix[k, 0];
    for (int q = 0; q < N; q++)
    {
        if (matrix[k, q] < minLine)
        {
            minLine = matrix[k, q];
        }                   
    }
    Console.WriteLine("Строка {0}, значение: {1}", k, minLine);
    price1.Add(minLine);
    Console.WriteLine();
}
for (int k = 0; k < M; k++)
{
    int maxcol = matrix[0, k];
    for (int q = 0; q < N; q++)
    {
        if (matrix[q, k] > maxcol)
        {
            maxcol = matrix[q, k];
        }                   
    }
    Console.WriteLine("Столбец {0}, значение: {1}", k, maxcol);
    price2.Add(maxcol);
    Console.WriteLine();
}
Console.WriteLine("Нижняя цена "+ price1.Max());
Console.WriteLine("Верхняя цена "+ price2.Min());

if (price1.Max() == price2.Min())
{
    Console.WriteLine("Чистые стратегии есть");
} else
{
    Console.WriteLine("Чистых стратегий не существует");
}

return 0;
