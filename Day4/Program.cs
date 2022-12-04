using System.Linq.Expressions;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();
var pairAssigments = new List<(Assignment, Assignment)>();

foreach(var line in input)
{
    pairAssigments.Add(parser.Parse(line)) ;
}

var numberOfFullContains = pairAssigments.Where(v => v.Item1.IsContatining(v.Item2) || v.Item2.IsContatining(v.Item1)).Count();

Console.WriteLine(numberOfFullContains);

var numberOfOverlappingPairs = pairAssigments.Where(v => v.Item1.IsOverLapping(v.Item2) || v.Item2.IsOverLapping(v.Item1)).Count();

Console.WriteLine(numberOfOverlappingPairs);