Console.WriteLine("Введите размер матрицы M (от 2 до 10)");
int M = Convert.ToInt16(Console.ReadLine());
if (M > 10 && M < 2)
{
    Console.WriteLine("Вне диапазона");
}
Console.WriteLine("Введите размер матрицы N (от 2 до 10)");
int N = Convert.ToInt16(Console.ReadLine());
if (N > 10 && N < 2)
{
    Console.WriteLine("Вне диапазона");
} 
int[,] matrix = new int[N, M];
List<int> row = new List<int>();
List<int> price1 = new List<int>();
List<int> price2 = new List<int>();
List<Tuple<int, int>> temp_pos = new List<Tuple<int, int>>();
List<Tuple<int, int>> price_pos = new List<Tuple<int, int>>();

Generate();

void Generate()
{
    price1.Clear();
    price2.Clear();
    temp_pos.Clear();
    price_pos.Clear();
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
    Count();
}

void Count()
{
    Console.WriteLine(" ");
    if (price1.Max() == price2.Min())
    {
        Generate();
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
        Console.WriteLine("Верхняя цена: "+ price2.Min());
        Console.WriteLine("Нижняя цена: "+ price1.Max());
        Console.WriteLine("Решения игры в чистых стратегиях не существует!");
        if (N == 2 && M == 2) {
            // Формулы взяты из интернета
            var x1 = (float)(matrix[1,1] - matrix[1,0]) / (float)(matrix[0,0] + matrix[1,1] - matrix[1,0] - matrix[0,1]);
            var x2 = (float)(matrix[0,0] - matrix[0,1]) / (float)(matrix[0,0] + matrix[1,1] - matrix[1,0] - matrix[0,1]);
            var y1 = (float)(matrix[1,1] - matrix[0,1]) / (float)(matrix[0,0] + matrix[1,1] - matrix[1,0] - matrix[0,1]);
            var y2 = (float)(matrix[0,0] - matrix[1,0]) / (float)(matrix[0,0] + matrix[1,1] - matrix[1,0] - matrix[0,1]);
            var v = (float)(matrix[0,0] * matrix[1,1] - matrix[0,1] * matrix[1,0]) / (matrix[0,0] + matrix[1,1] - matrix[1,0] - matrix[0,1]);
            Console.WriteLine($"x1 = {x1} x2 = {x2} y1 = {y1} y2 = {y2}");
            Console.WriteLine($"Цена игры {v}");
        }
    }
}
