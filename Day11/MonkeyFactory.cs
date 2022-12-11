internal class MonkeyFactory
{
    internal Monkey CreateMonkey(int monkeyID, Queue<Item> items, string operation, int value, int condition, int trueTarget, int falseTarget)
        => new Monkey(monkeyID, items, operation, value, condition, trueTarget, falseTarget);

    internal Monkey CreateMonkey(int monkeyID, Queue<Item> items, int condition, int trueTarget, int falseTarget)
        => new Monkey(monkeyID, items, condition, trueTarget, falseTarget);
}