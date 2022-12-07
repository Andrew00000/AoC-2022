public class MarkerFinderQueue<T>
{
    private Queue<T> queue = new(); 
    private int queueLength = 0;
    public MarkerFinderQueue(int queueLength)
    {
        this.queueLength = queueLength;
    }

    private Queue<T> Shift(T nextElement)
    {
        while (queue.Contains(nextElement))
        {
            queue.Dequeue();
        }

        queue.Enqueue(nextElement);

        return queue;
    }

    public int FindMarker(T[] input)
    {
        var index = 0;

        while(queue.Count != queueLength)
        {
            if (index == input.Count())
            {
                throw new ArgumentException("No solution biatch");
            }

            Shift(input[index]);
            index++;
        }

        return index;
    }
}