/*
Private 1 Peter Johnson 22.22
Commando 13 Sam Peterson 13.1 Airforces
Private 222 Tony Samthon 80.08
LieutenantGeneral 3 George Stevenson 100 222 1
End

Engineer 7 Peter Johnson 12.23 Marines Boat 2 Crane 17
Commando 19 George Stevenson 150.15 Airforces HairyFoot Finished Freedom InProgress
End
*/

namespace _07.MilitaryElite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<int, ISoldier> army = new Dictionary<int, ISoldier>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(parts[1]);
                string firstName = parts[2];
                string lastName = parts[3];

                switch (parts[0])
                {
                    case "Private":
                        army.Add(id, new Private(id, firstName, lastName, decimal.Parse(parts[4])));
                        break;
                    case "LieutenantGeneral":
                        LieutenantGeneral lg = new LieutenantGeneral(id, firstName, lastName, decimal.Parse(parts[4]));
                        for (int i = 5; i < parts.Length; i++)
                        {
                            lg.AddPrivate((IPrivate)army[int.Parse(parts[i])]);
                        }
                        army.Add(id, lg);
                        break;
                    case "Engineer":
                        Engineer eng = null;
                        try
                        {
                            eng = new Engineer(id, firstName, lastName, decimal.Parse(parts[4]), parts[5]);
                        }
                        catch { continue; }
                        for (int i = 6; i < parts.Length; i += 2)
                        {
                            string part = parts[i];
                            int hours = int.Parse(parts[i + 1]);
                            eng.AddRepair(new Repair(part, hours));
                        }
                        army.Add(id, eng);
                        break;
                    case "Commando":
                        Commando cmd = null;
                        try
                        {
                            cmd = new Commando(id, firstName, lastName, decimal.Parse(parts[4]), parts[5]);
                        }
                        catch { continue; }
                        for (int i = 6; i < parts.Length; i += 2)
                        {
                            string code = parts[i];
                            string state = parts[i + 1];
                            try
                            {
                                cmd.AddMission(new Mission(code, state));
                            }
                            catch { continue; }
                        }
                        army.Add(id, cmd);
                        break;
                    case "Spy":
                        army.Add(id, new Spy(id, firstName, lastName, int.Parse(parts[4])));
                        break;
                    default:
                        break;
                }
            }
            foreach (var soldier in army)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
