internal class Parser
{
    internal IEnumerable<Monkey> Parse(string input, bool IsUltraCoolOn, int interestDropRate = 1)
    {
        var monkeyProperties = input.Split(Environment.NewLine + Environment.NewLine);

        var monkeys = new List<Monkey>();
        var itemFactory = new ItemFactory();
        var monkeyFactory = new MonkeyFactory();
        var magicNumber = 1;

        foreach (var monkey in monkeyProperties)
        {
            var condition = int.Parse(monkey.Split("Test: divisible by ")[1].Split(' ')[0]);
            magicNumber *= condition;
        }

        foreach (var monkey in monkeyProperties)
        {
            var properties = monkey.Split(Environment.NewLine);

            var monkeyID = int.Parse(properties[0].Split(' ')[1].Trim(':'));

            var items = new Queue<Item>();
            var itemsString = properties[1].Split("items: ")[1];
            itemsString.Split(", ").ToList().ForEach(i => items.Enqueue(itemFactory.CreateItem(Int32.Parse(i))));

            var operationAndValue = properties[2].Split("new = old ")[1];

            var operation = operationAndValue.Split(' ')[0];
            var valueString = operationAndValue.Split(' ')[1];

            var condition = int.Parse(properties[3].Split(' ')[^1]);

            var trueTarget = int.Parse(properties[4].Split(' ')[^1]);
            var falseTarget = int.Parse(properties[5].Split(' ')[^1]);

            magicNumber = IsUltraCoolOn ? magicNumber : interestDropRate;

            if (int.TryParse(valueString, out var value))
            {
                monkeys.Add(monkeyFactory.CreateMonkey(monkeyID, items, operation, value, condition, trueTarget, falseTarget, IsUltraCoolOn, magicNumber));
            }
            else
            {
                monkeys.Add(monkeyFactory.CreateMonkey(monkeyID, items, condition, trueTarget, falseTarget, IsUltraCoolOn, magicNumber));
            }
        }
        return monkeys; 
    }
}