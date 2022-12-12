var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();

(var map, var start, var end) = parser.Parse(input);

Console.WriteLine(map.CalculateShortestRoute(start, end));

var starts = new List<(int y, int x)>();

(map, starts, end) = parser.Parse2(input);

var routes = new HashSet<int>();

foreach (var startingPoint in starts)
{
    routes.Add(map.CalculateShortestRoute(startingPoint, end));
}

Console.WriteLine(routes.Min());