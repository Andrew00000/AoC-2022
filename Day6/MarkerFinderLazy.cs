using System.Collections.Generic;

public class MarkerFinderLazy
{
    public int FindMarker(string input, int markerLength)
    {
        if (input.Length < markerLength)
        {
            throw new ArgumentException("No solution biatch");
        }

        for (int i = markerLength; i <= input.Length; i++)
        {
            var set = input[(i - markerLength)..i].ToHashSet();

            if (set.Count == markerLength)
            {
                return i;
            }
        }

        throw new ArgumentException("No solution biatch");
    }
}