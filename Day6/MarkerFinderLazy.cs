using System.Collections.Generic;

public class MarkerFinderLazy
{
    public int FindMarker(string input, int markerLenght)
    {
        if (input.Length < markerLenght)
        {
            throw new ArgumentException("No solution biatch");
        }

        for (int i = markerLenght; i <= input.Length; i++)
        {
            var set = input[(i - markerLenght)..i].ToHashSet();

            if (set.Count == markerLenght)
            {
                return i;
            }
        }

        throw new ArgumentException("No solution biatch");
    }
}