using System.Diagnostics;

var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solutionOne = 6098;
var solutionTwo = 2597;


//Problem One: https://adventofcode.com/2022/day/9

var snekkTimer = new Stopwatch();
snekkTimer.Start();

var parser = new Parser();
var commands = parser.Parse(input);
var snekk = new Snekk();
var mover = new Mover();

mover.DoTheChacha(commands, snekk);
snekkTimer.Stop();

var problemOneResult = solutionOne == snekk.GetNumberOfTouchedFields() ? $"Yes the answer is {snekk.GetNumberOfTouchedFields()}"
                                                                       : $"No the answer isnt {snekk.GetNumberOfTouchedFields()}";

Console.WriteLine(problemOneResult);


//Problem Two: https://adventofcode.com/2022/day/9

var anacondaTimer = new Stopwatch();
anacondaTimer.Start();

var parser2 = new Parser();
var commands2 = parser2.Parse(input);
var mover2 = new Mover();
var length = 9;
var anaconda = new Anaconda(length);

mover2.DoTheChacha(commands2, anaconda);
anacondaTimer.Stop();

var problemTwoResult = solutionTwo == anaconda.GetNumberOfTouchedFields() ? $"Yes the answer is {anaconda.GetNumberOfTouchedFields()}"
                                                                          : $"No the answer isnt {anaconda.GetNumberOfTouchedFields()}";

Console.WriteLine(problemTwoResult);



Console.WriteLine($"Snekk: \t\t{snekkTimer.Elapsed.TotalMilliseconds} ms");
Console.WriteLine($"Anna Conda: \t{anacondaTimer.Elapsed.TotalMilliseconds} ms");