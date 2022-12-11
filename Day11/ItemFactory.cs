internal class ItemFactory
{
    internal Item CreateItem(int value)
        => new(value);
}