internal class Calculator
{
    private long solution = 0L;

    private long x = 1L;

    internal void Calculate(int[] ints)
    {
        x = 1L; 

        for (int i = 0; i < ints.Length; i++)
        {
            if (i < 220 && i % 40 == 19)
            {
                solution += (i + 1) * x;
            }

            x += ints[i];
        }
    }

    internal long GetSolution()
        => solution;

    internal void Print(int[] ints)
    {
        x = 1L;
        var width = 40;

        for (int i = 0; i < ints.Length; i++)
        {
            var pixel = ' ';

            var ShouldPrint = x - 1 <= i % width && i % width <= x + 1;

            if (ShouldPrint)
            {
                pixel = '#';
            }

            Console.Write(pixel);

            if ((i + 1) % width == 0)
            {
                Console.WriteLine();
            }

            x += ints[i];
        }
    }
}