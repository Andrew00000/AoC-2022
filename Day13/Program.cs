var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\min.txt");

var parser = new Parser();

var bla = parser.Parse(input);