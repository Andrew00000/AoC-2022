internal class Item
{
    public long Value { get; private set;}

    public Item(int value)
    {
        Value = value;
    }

    public void Add(int value)
        => Value += value;

    public void Multiply(int value)
        => Value *= value;

    public void Square()
        => Value *= Value;

    public void Divide(int value)
        => Value /= value;

    public void Modulo(int value)
        => Value %= value;
}