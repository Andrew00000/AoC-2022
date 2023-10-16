internal class Monkey
{
    private readonly Queue<Item> items;
    private readonly int divider;
    private readonly int trueTarget;
    private readonly int falseTarget;
    private readonly Action<Item> operation;
    private readonly ICalmingStrategy calmingStrategy;

    public long Activeness { get; private set; } = 0L;
    public int MonkeyID { get; init; }

    public Monkey(int monkeyID, Queue<Item> items, Action<Item> operation, int divider, int trueTarget, int falseTarget, ICalmingStrategy calmingStrategy)
    {
        MonkeyID = monkeyID;
        this.items = items;
        this.divider = divider;
        this.trueTarget = trueTarget;
        this.falseTarget = falseTarget;
        this.operation = operation;
        this.calmingStrategy = calmingStrategy;
    }

    public Queue<(int target, Item item)> ProcessAllItems()
    {
        var thrownItems = new Queue<(int target, Item item)>();

        while (items.Count != 0)
        {
            var item = items.Dequeue();
            thrownItems.Enqueue(ProcessItem(item));
        }

        return thrownItems;
    }
    public void CatchItem(Item item)
        => items.Enqueue(item);

    private (int target, Item item) ProcessItem(Item item)
    {
        Activeness++;
        operation(item);
        calmingStrategy.CalmDown(item);
        return ThrowItem(item);
    }

    private (int target, Item item) ThrowItem(Item item)
        => item.Value % divider == 0 ? (trueTarget, item) : (falseTarget, item);
}