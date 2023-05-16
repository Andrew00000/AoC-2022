var input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";


var sum = 0;
foreach (var line in input)
{
    var set1 = line[..(line.Length/2)].ToHashSet();
    var set2 = line[(line.Length / 2)..].ToHashSet();
    var set3 = set1.Intersect(set2);

    sum += alphabet.IndexOf(set3.First()) + 1;
}
Console.WriteLine(sum); 

var sum2 = 0;
for (int i = 0; i < input.Length; i+=3)
{
    var set1 = input[i].ToHashSet();
    var set2 = input[i+1].ToHashSet();
    var set3 = input[i+2].ToHashSet();

    var intersect = set1.Intersect(set2).Intersect(set3);

    sum2 += alphabet.IndexOf(intersect.First()) + 1;
}
Console.WriteLine(sum2);