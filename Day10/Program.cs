using System.Diagnostics;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var part1Timer = new Stopwatch();
part1Timer.Start();
var parser = new Parser();

var ints = parser.Parse(input).ToArray();

var calculator = new Calculator();

calculator.Calculate(ints);
part1Timer.Stop();
Console.WriteLine(calculator.GetSolution());

var part2Timer = new Stopwatch();
part2Timer.Start();
var parser2 = new Parser();

var ints2 = parser2.Parse(input).ToArray();

var calculator2 = new Calculator();

calculator2.Print(ints2);
part2Timer.Stop();

Console.WriteLine($"part1: {part1Timer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"part2: {part2Timer.Elapsed.TotalMilliseconds} ms");