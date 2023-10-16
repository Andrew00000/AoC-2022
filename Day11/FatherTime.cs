internal class FatherTime
{
    private readonly List<Monkey> monkeys;

    public FatherTime(IEnumerable<Monkey> monkeys)
    {
        this.monkeys = monkeys.ToList();
    }

    public void PassTime(int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            DoOneRound();
        }
    }
    private void DoOneRound()
    {
        foreach (var monkey in monkeys)
        {
            var thrownItems = monkey.ProcessAllItems();
            SortThrownItems(thrownItems);
        }
    }

    private void SortThrownItems(Queue<(int target, Item item)> packages)
    {
        while (packages.Count != 0) 
        {
            var (target, item) = packages.Dequeue();
            var targetMonkey = monkeys[target];
            targetMonkey.CatchItem(item);
        }
    }

}