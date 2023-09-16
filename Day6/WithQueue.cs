public class WithQueue : IMarkerFinderApproach
{
    private readonly Queue<char> queue = new(); 

    private Queue<char> Shift(char nextElement)
    {
        while (queue.Contains(nextElement))
        {
            queue.Dequeue();
        }

        queue.Enqueue(nextElement);

        return queue;
    }

    public int FindMarker(char[] input, int markerLength)
    {
        if (queue.Count != 0)
        {
            queue.Clear();
        }

        var index = 0;

        while(queue.Count != markerLength)
        {
            if (index == input.Length)
            {
                throw new ArgumentException("No solution :'(");
            }

            Shift(input[index]);
            index++;
        }

        return index;
    }
}