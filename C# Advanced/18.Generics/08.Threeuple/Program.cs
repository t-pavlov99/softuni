/*
Adam Smith Wallstreet New York
Mark 18 drunk
Karren 0.10 USBan
 */
using System.Text;

namespace _08.Threeuple;

internal class Program
{
    static void Main(string[] args)
    {
        string[] NAT = Console.ReadLine().Split();
        string[] NLB = Console.ReadLine().Split();
        string[] NBB = Console.ReadLine().Split();

        StringBuilder sb = new StringBuilder();
        for (int i = 3; i < NAT.Length; i++)
        {
            sb.Append(NAT[i] + ' ');
        }
        CustomThreeuple<string, string, string> t1 =
            new CustomThreeuple<string, string, string>
            (NAT[0] + " " + NAT[1], NAT[2], sb.ToString());
        CustomThreeuple<string, int, bool> t2 =
            new CustomThreeuple<string, int, bool>
            (NLB[0], int.Parse(NLB[1]), NLB[2] == "drunk");
        CustomThreeuple<string, double, string> t3 =
            new CustomThreeuple<string, double, string>
            (NBB[0], double.Parse(NBB[1]), NBB[2]);
        Console.WriteLine(t1);
        Console.WriteLine(t2);
        Console.WriteLine(t3);
    }
}

