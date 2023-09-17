internal class ModuloStrategy : ICalmingStrategy
{
    private readonly int interestDropRate;

    public ModuloStrategy(int interestDropRate)
    {
        this.interestDropRate = interestDropRate;
    }

    public void CalmDown(Item item)
        => item.Modulo(interestDropRate);
}