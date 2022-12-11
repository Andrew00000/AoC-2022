internal class ItemFactory
{
    internal Item CreateItem(int value, bool calming)
        => new Item(value, calming);
}