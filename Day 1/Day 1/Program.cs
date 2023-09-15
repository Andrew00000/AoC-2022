var input = File.ReadAllText($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");
var solution1 = 66719;
var solution2 = 198551;

if (input is null)
{
    Console.WriteLine("Input missing");
}

//Problem One: https://adventofcode.com/2022/day/1

var caloriesByElfves = input!.Split(Environment.NewLine + Environment.NewLine).ToList()
      .Select(c => c.Split(Environment.NewLine).ToList()
      .Aggregate(0, (x, y) => x + int.Parse(y))).ToList();
      

var maximumCalories = caloriesByElfves.Max();

var problemOneResult = solution1 == maximumCalories ? $"Yes the answer is {maximumCalories}" 
                                                    : $"No the answer isnt {maximumCalories}";

Console.WriteLine(problemOneResult);

//Problem Two: https://adventofcode.com/2022/day/1

var topThreeMaximumCalories = caloriesByElfves.OrderDescending().ToList().Take(3).Sum();

var problemTwoResult = solution2 == topThreeMaximumCalories ? $"Yes the answer is {topThreeMaximumCalories}" 
                                                            : $"No the answer isnt {topThreeMaximumCalories}";

Console.WriteLine(problemTwoResult);


