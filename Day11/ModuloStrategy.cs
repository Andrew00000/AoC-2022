internal class ModuloStrategy : ICalmingStrategy
{
    public void CalmTheFuckDown(Item item, int interestDropRate)
        => item.Modulo(interestDropRate);
}