public class MarkerFinderQueue<T>
{
    private Queue<T> queue = new(); 
    private int queueLenght = 0;
    public MarkerFinderQueue(int queueLenght)
    {
        this.queueLenght = queueLenght;
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

        while(queue.Count != queueLenght)
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