using System.Diagnostics;

var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

var lazyFinder = new MarkerFinderLazy();

var queueFinder = new MarkerFinderQueue<char>(14);


var indexOfMarker = lazyFinder.FindMarker(input, 4);

Console.WriteLine(indexOfMarker);

var lazyTimer = new Stopwatch();
lazyTimer.Start();
var indexOfMessageLazy = lazyFinder.FindMarker(input, 14);
lazyTimer.Stop();

var timer = new Stopwatch();
timer.Start();
var indexOfMessageQueue = queueFinder.FindMarker(input.ToCharArray());
timer.Stop();

Console.WriteLine(indexOfMessageQueue);
Console.WriteLine(indexOfMessageLazy == indexOfMessageQueue);

Console.WriteLine($"lazy {lazyTimer.Elapsed}");
Console.WriteLine($"queue {timer.Elapsed}");