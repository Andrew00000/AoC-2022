internal class DivideStrategy : ICalmingStrategy
{
    public void CalmTheFuckDown(Item item, int interestDropRate)
        => item.Divide(interestDropRate);
}