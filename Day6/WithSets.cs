public class WithSets : IMarkerFinderApproach
{
    public int FindMarker(char[] input, int markerLength)
    {
        if (input.Length < markerLength)
        {
            throw new ArgumentException("No solution... wamp wamp waaamp");
        }

        for (int i = markerLength; i <= input.Length; i++)
        {
            var set = input[(i - markerLength)..i].ToHashSet();

            if (set.Count == markerLength)
            {
                return i;
            }
        }

        throw new ArgumentException("No solution");
    }
}