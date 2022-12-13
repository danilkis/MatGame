Console.WriteLine("Введите размер матрицы M (от 2 до 10)");
var M = Convert.ToInt16(Console.ReadLine());
if (M > 10 && M < 2)
{
    Console.WriteLine("Вне диапазона");
}
Console.WriteLine("Введите размер матрицы N (от 2 до 10)");
var N = Convert.ToInt16(Console.ReadLine());
if (N > 10 && N < 2)
{
    Console.WriteLine("Вне диапазона");
}
int i, j;
int[,] matrix = new int[N, M];

List<int> row = new List<int>();
List<int> price1 = new List<int>();
List<int> price2 = new List<int>();
List<Tuple<int, int>> temp_pos = new List<Tuple<int, int>>();
List<Tuple<int, int>> price_pos = new List<Tuple<int, int>>();
for (int o = 0; o < M; o++)
{
    for (int p = 0; p < N; p++)
    {
        Random rnd = new Random();
        int rand_num = rnd.Next(2, 12);
        matrix[p, o] = rand_num;
        Console.Write(matrix[p, o] + "\t");
        row.Add(matrix[p, o]);
        temp_pos.Add(Tuple.Create(p, o));
        if (p == N - 1)
        {
            price1.Add(row.Min());
            Console.Write("\t" + "|" + row.Min());
            price_pos.Add(temp_pos[row.IndexOf(row.Min())]);
            temp_pos.Clear();
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
                price_pos.Add(Tuple.Create(y,z));
            }
            Console.Write(column.Max() + "\t");
            price2.Add(column.Max());
            column.Clear();
        }
    }
}
Console.WriteLine(" ");
Console.WriteLine("Верхняя цена: "+ price2.Min());
Console.WriteLine("Нижняя цена: "+ price1.Max());
if (price1.Max() == price2.Min())
{
    Console.WriteLine("Чистые стратегии есть");
    Tuple<int, int> temp_tup = new Tuple<int, int>(0,0);
    foreach (Tuple<int,int> tup in price_pos)
    {
        if (tup.Item1 == temp_tup.Item1 && tup.Item2 == temp_tup.Item2)
        {
            Console.WriteLine("Седловая точка на координатах: " + tup.Item1 + ";" + tup.Item2 );
        }
    }
} 
else
{
    Console.WriteLine("Решения игры в чистых стратегиях не существует!");
}