public class Assignment
{
    private readonly int startParcel;
    private readonly int endParcel;

    public Assignment(int argStartParcel, int argEndParcel)
    {
        startParcel= argStartParcel;
        endParcel= argEndParcel;
    }

    public bool IsContatining(Assignment tested)
        => startParcel <= tested.startParcel && endParcel >= tested.endParcel;

    public bool IsOverLapping(Assignment tested)
        => startParcel >= tested.startParcel && startParcel <= tested.endParcel
        || endParcel >= tested.startParcel && endParcel <= tested.endParcel
        || IsContatining(tested);
}