internal class Item
{
    public long Value { get; private set;}
    public bool AmICalming { get; private set;} = true;

    public Item(int value, bool calming)
    {
        Value = value;
        AmICalming = calming;
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