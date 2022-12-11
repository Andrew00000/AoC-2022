internal class Monkey
{
    public int MonkeyID { get; init; }
    private readonly Queue<Item> items;
    private Action<Item> operation;
    private readonly int value;
    private readonly int divider;
    private readonly int trueTarget;
    private readonly int falseTarget;
    private readonly int interestDrop = 3;
    public long Activeness { get; private set; } = 0L;

    public Monkey(int monkeyID, Queue<Item> items, int divider, int trueTarget, int falseTarget)
    {
        MonkeyID = monkeyID;
        this.items = items;
        this.divider = divider;
        this.trueTarget = trueTarget;
        this.falseTarget = falseTarget;
        SetOperationToSquare();
    }

    public Monkey(int monkeyID, Queue<Item> items, string operation, int value, int divider, int trueTarget, int falseTarget)
    {
        MonkeyID = monkeyID;
        this.items = items;
        this.value = value;
        this.divider = divider;
        this.trueTarget = trueTarget;
        this.falseTarget = falseTarget;
        SetOperation(operation);
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
        DoInterestCorrection(item);
        return ThrowItem(item);
    }

    private (int target, Item item) ThrowItem(Item item)
        => item.Value % divider == 0 ? (trueTarget, item) : (falseTarget, item);


    private void DoInterestCorrection(Item item)
    {
        if (item.AmICalming)
        {
            item.Divide(interestDrop);
        }
    }

    private void Multiply(Item item)
        => item.Multiply(value);

    private void Add(Item item)
        => item.Add(value);

    private void Square(Item item)
        => item.Square();

    private void SetOperationToSquare()
        => operation = Square;

    private void SetOperation(string operation)
    {
        this.operation = operation switch
        {
            "+" => Add,
            "*" => Multiply,
            _ => throw new ArgumentException("little math prodigy brings fancy new operations, eh?"),
        };
    }
}