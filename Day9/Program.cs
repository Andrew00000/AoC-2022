using System.Diagnostics;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var snekTimer = new Stopwatch();
snekTimer.Start();

var parser = new Parser();
var snek = new Snek();
var commands = parser.Parse(input);
var mover = new Mover();

mover.DoTheChacha(commands, snek);
snekTimer.Stop();

var anacondaTimer = new Stopwatch();
anacondaTimer.Start();

var parser2 = new Parser();
var commands2 = parser2.Parse(input);
var mover2 = new Mover();
var length = 9;
var anaconda = new Anaconda(length);

mover2.DoTheTango(commands2, anaconda);
anacondaTimer.Stop();

Console.WriteLine(snek.GetNumberOfTouchedFields());
Console.WriteLine(anaconda.GetTouchedFields());
Console.WriteLine($"snek: {snekTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"conda: {anacondaTimer.Elapsed.TotalMilliseconds} ms");