internal class MonkeyFactory
{
    internal Monkey CreateMonkey(int monkeyID, Queue<Item> items, string operation, int value, int condition, int trueTarget, int falseTarget, bool IsUltraCalmingOn, int interestDropRate)
        => new(monkeyID, items, SetOperation(operation, value), condition, trueTarget, falseTarget, ChooseCalmingStrategy(IsUltraCalmingOn), interestDropRate);

    internal Monkey CreateMonkey(int monkeyID, Queue<Item> items, int condition, int trueTarget, int falseTarget, bool IsUltraCalmingOn, int interestDropRate)
        => new(monkeyID, items, i => i.Square(), condition, trueTarget, falseTarget, ChooseCalmingStrategy(IsUltraCalmingOn), interestDropRate);

    private Action<Item> SetOperation(string operation, int value)
    {
        return operation switch
        {
            "+" => i => i.Add(value),
            "*" => i => i.Multiply(value),
            _ => throw new ArgumentException("little math prodigy brings fancy new operations, eh?"),
        };
    }

    private ICalmingStrategy ChooseCalmingStrategy(bool IsUltraCalmingOn)
        => IsUltraCalmingOn ? new ModuloStrategy() : new DivideStrategy();
}