﻿Console.WriteLine("Введите размер матрицы M (от 2 до 10)");
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

List<int> row = new List<int>();
List<int> col = new List<int>();
List<int> price1 = new List<int>();
List<int> price2 = new List<int>();
List<Tuple<int, int>> price_pos= new List<Tuple<int,int>>();
List<Tuple<int, int>> row_pos= new List<Tuple<int,int>>();
for (int o = 0; o < M; o++)
{
    for (int p = 0; p < N; p++)
    {
        Random rnd = new Random();
        int rand_num = rnd.Next(2, 12);
        matrix[p, o] = rand_num;
        Console.Write(matrix[p, o].ToString() + "\t");
        row_pos.Add(Console.GetCursorPosition().ToTuple());
        row.Add(matrix[p, o]);
        if (p == N - 1)
        {
            price1.Add(row.Min());
            price_pos.Add(row_pos[row.IndexOf(Convert.ToInt16(row.Min()))]);
            Console.Write("\t" + "|" + row.Min());
            Console.GetCursorPosition();
            row_pos.Clear();
            row.Clear();
        }
    }

    Console.WriteLine();
    if (o == M - 1)
    {
        Console.WriteLine(new string('-', N * 7));
        int max = 0;
        List<int> column = new List<int>();
        for (int y = 0; y < N; y++)
        {
            for (int z = 0; z < M; z++)
            {
                column.Add(matrix[y,z]);
            }
            Console.Write(column.Max() + "\t");
            price2.Add(column.Max());
            column.Clear();
        }
    }
}

Console.WriteLine("\nМинимальное значение в строках: ");
Console.WriteLine("Нижняя цена: "+ price1.Max());
Console.WriteLine("Верхняя цена: "+ price2.Min());
/*
foreach (var tup in price_pos)
{
    Console.BackgroundColor= ConsoleColor.Red;
    Console.SetCursorPosition(tup.Item1, tup.Item2);
    Console.Write('*');
}
*/
if (price1.Max() == price2.Min())
{
    Console.WriteLine("Чистые стратегии есть");
    
} else
{
    Console.WriteLine("Решения игры в чистых стратегиях не существует!");
}
return 0;
