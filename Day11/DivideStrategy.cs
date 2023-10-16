internal class DivideStrategy : ICalmingStrategy
{
    private readonly int interestDropRate;

    public DivideStrategy(int interestDropRate)
    {
        this.interestDropRate = interestDropRate;
    }

    public void CalmDown(Item item)
        => item.Divide(interestDropRate);
}