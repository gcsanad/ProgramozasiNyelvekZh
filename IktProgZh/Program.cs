namespace IktProgZh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 == 0 || args.Length == 0)
            {
                Console.WriteLine("Nono");
            }
            else
            {
                int kozepso = Convert.ToInt32(Math.Floor((double)args.Length / 2));
                if (Convert.ToDouble(args[kozepso - 1]) > Convert.ToDouble(args[kozepso + 1]))
                {
                    Console.WriteLine(Math.Floor(Math.Pow(Convert.ToInt32(args[kozepso]), Math.Round(Convert.ToDouble(args[kozepso - 1]) / Convert.ToDouble(args[kozepso + 1])))));

                }
                else
                {
                    Console.WriteLine(Math.Floor(Math.Pow(Convert.ToInt32(args[kozepso]), Math.Round(Convert.ToDouble(args[kozepso + 1]) / Convert.ToDouble(args[kozepso - 1])))));

                }
            }
            Console.WriteLine(new string('-', 40));

            List<char> magan = ['A', 'E', 'I', 'O', 'U'];
            List<string> szoveg = File.ReadAllLines("szavak.txt").Select(x => x.Trim()).ToList();
            int legalabbNegy = 0;
            foreach (var item in szoveg)
            {
                int szamol = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    if (magan.Contains(item[i]))
                    {
                        szamol++;
                    }
                }
                if (szamol > 4)
                {
                    legalabbNegy++;
                    //Console.WriteLine(item);
                }
            }
            Console.WriteLine("Legalább 4 szótagú szavak: " + legalabbNegy);
            Console.WriteLine(new string('-', 40));

            Random rnd = new Random();
            int[,] matrix = new int[6, 6];

            List<int> matrixSzamok = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(55, 156);
                    Console.Write(new string(' ', 3 - matrix[i, j].ToString().Length) + matrix[i, j] + " ");
                    if (i == 0 || i == 5 || j == 0 || j == 5)
                    {
                        matrixSzamok.Add(matrix[i, j]);
                    }
                }
                Console.WriteLine();

            }

            Console.WriteLine($"A szélső elemek átlaga: {String.Format("{0:0.00}", (double)matrixSzamok.Sum() / (double)matrixSzamok.Count()).Replace(',', '.')}");
            Console.WriteLine("Legalább 4 szótagú szavak: " + legalabbNegy);

            List<string> rgbLista = File.ReadAllLines("kep.txt").Select(x => x.Trim()).ToList();
            List<string> kekitett = [];

            foreach (var item in rgbLista)
            {
                if (int.Parse(item.Split(';')[2]) < 100)
                {
                    kekitett.Add($"{item.Split(';')[0]};{item.Split(';')[1]};{int.Parse(item.Split(';')[2]) + 20}");
                }
            }
            File.WriteAllLines("kekitett.txt", kekitett.Select(x => x));
            Console.WriteLine("#Kesz");



        }
    }
}
