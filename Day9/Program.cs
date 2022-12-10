var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var parser = new Parser();

var snek = new Snek();

var commands = parser.Parse(input);

var mover = new Mover();

mover.DoTheChacha(commands, snek);

Console.WriteLine(snek.GetNumberOfTouchedFields());

var length = 10;
var factory = new CommandFactory();

var anaconda = new Anaconda(length, factory);

mover.DoTheTango(commands, anaconda);

Console.WriteLine(anaconda.GetTouchedFields());