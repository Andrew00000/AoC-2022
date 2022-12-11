internal class FatherTime
{
    private List<Monkey> monkeys;
    private int number = 1;

    public FatherTime(IEnumerable<Monkey> monkeys)
    {
        this.monkeys = monkeys.ToList();
    }

    public FatherTime(IEnumerable<Monkey> monkeys, int number)
    {
        this.monkeys = monkeys.ToList();
        this.number = number;
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
            ProtectFromOverflow(thrownItems);
            SortThrownItems(thrownItems);
        }
    }

    private void ProtectFromOverflow(Queue<(int target, Item item)> thrownItems)
    {
        foreach (var item in thrownItems)
        {
            if (item.item.Value > number)
            {
                item.item.Modulo(number);
            }
        }
    }

    private void SortThrownItems(Queue<(int target, Item item)> packages)
    {
        while (packages.Count != 0) 
        {
            var package = packages.Dequeue();
            var targetMonkey = monkeys.Where(m => m.MonkeyID == package.target).First();
            targetMonkey.CatchItem(package.item);
        }
    }

}