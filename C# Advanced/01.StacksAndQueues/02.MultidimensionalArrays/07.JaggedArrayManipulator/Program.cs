/*
5
10 20 30
1 2 3
2
2
10 10
End

5
10 20 30
1 2 3
2
2
10 10
Add 0 10 10
Add 0 0 10
Subtract -3 0 10
Subtract 3 0 10
End
    */
namespace _07.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            decimal[][] numbers = new decimal[size][];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            }
            for (int i = 0; i < size - 1; i++)
            {
                if (numbers[i].Length == numbers[i + 1].Length)
                {
                    numbers[i] = numbers[i].Select(x => x * 2).ToArray();
                    numbers[i + 1] = numbers[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    numbers[i] = numbers[i].Select(x => x / 2).ToArray();
                    numbers[i + 1] = numbers[i + 1].Select(x => x / 2).ToArray();
                }
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] parts = cmd.Split();
                try
                {
                    int row = int.Parse(parts[1]);
                    int col = int.Parse(parts[2]);
                    decimal value = int.Parse(parts[3]);
                    switch (parts[0])
                    {
                        case "Add":
                            numbers[row][col] += value;
                            break;
                        case "Subtract":
                            numbers[row][col] -= value;
                            break;
                        default: break;
                    }
                }
                catch { }
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(string.Join(" ", numbers[i]));
            }
        }
    }
}
