internal class Parser
{
    internal (IEnumerable<Monkey>, int) Parse(string input, bool calming)
    {
        var monkeyProperties = input.Split(Environment.NewLine + Environment.NewLine);

        var monkeys = new List<Monkey>();
        var itemFactory = new ItemFactory();
        var monkeyFactory = new MonkeyFactory();
        var number = 1;

        foreach (var monkey in monkeyProperties)
        {
            var properties = monkey.Split(Environment.NewLine);

            var monkeyID = int.Parse(properties[0].Split(' ')[1].Trim(':'));

            var items = new Queue<Item>();
            var itemsString = properties[1].Split("items: ")[1];
            itemsString.Split(", ").ToList().ForEach(i => items.Enqueue(itemFactory.CreateItem(Int32.Parse(i), calming)));

            var operationAndValue = properties[2].Split("new = old ")[1];

            var operation = operationAndValue.Split(' ')[0];
            var valueString = operationAndValue.Split(' ')[1];

            var condition = int.Parse(properties[3].Split(' ')[^1]);
            number *= condition;

            var trueTarget = int.Parse(properties[4].Split(' ')[^1]);
            var falseTarget = int.Parse(properties[5].Split(' ')[^1]);

            if (Int32.TryParse(valueString, out var value))
            {
                monkeys.Add(monkeyFactory.CreateMonkey(monkeyID, items, operation, value, condition, trueTarget, falseTarget));
            }
            else
            {
                monkeys.Add(monkeyFactory.CreateMonkey(monkeyID, items, condition, trueTarget, falseTarget));
            }
        }
        return (monkeys, number); 
    }
}