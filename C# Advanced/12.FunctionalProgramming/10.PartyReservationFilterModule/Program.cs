namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<string, Func<string, bool>>> filters = new()
            {
                ["Starts with"] = str =>
                {
                    return x => x.StartsWith(str);
                },
                ["Ends with"] = str =>
                {
                    return x => x.EndsWith(str);
                },
                ["Length"] = length =>
                {
                    return x => x.Length == int.Parse(length);
                },
                ["Contains"] = str =>
                {
                    return x => x.Contains(str);
                }
            };

            Dictionary<(string, string), Func<string, bool>> activeFilters = new();

            List<string> names = Console.ReadLine().Split(' ').ToList();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] parts = cmd.Split(";");
                if (parts[0] == "Add filter")
                {
                    Func<string, bool> filter = filters[parts[1]](parts[2]);
                    activeFilters.Add((parts[1], parts[2]), filter);
                }
                else
                {
                    activeFilters.Remove((parts[1], parts[2]));
                }
            }
            foreach (var filter in activeFilters)
            {
                names = names.Where(x => !filter.Value(x)).ToList();
            }
            Console.WriteLine(string.Join(" ", names));
        }
    }
}
