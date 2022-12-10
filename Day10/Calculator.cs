internal class Calculator
{
    private long solution = 0L;

    private long x = 1L;

    internal void Calculate(int[] ints)
    {
        x = 1L; 

        var targets = new long[] { 19, 59, 99, 139, 179, 219 };
        
        for (int i = 0; i < ints.Length; i++)
        {
            if (targets.Contains(i))
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

        var targets = new long[] { 39, 79, 119, 159, 199, 239 };

        for (int i = 0; i < ints.Length; i++)
        {
            var pixel = ' ';

            var ShouldPrint = x - 1 <= i % 40 && i % 40 <= x + 1;

            if (ShouldPrint)
            {
                pixel = '#';
            }

            Console.Write(pixel);

            if (targets.Contains(i))
            {
                Console.WriteLine();
            }

            x += ints[i];
        }
    }
}