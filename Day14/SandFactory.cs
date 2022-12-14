internal class SandFactory
{
    internal Sand CreateSand((int y, int x) start, (int y, int x) cave)
        => new Sand(start, cave);
}