namespace Day6
{
    internal class MarkerFinder
    {
        private readonly IMarkerFinderApproach markerFinderApproach;


        public MarkerFinder(IMarkerFinderApproach markerFinderApproach)
        {
            this.markerFinderApproach = markerFinderApproach;
        }

        public int FindMarker(char[] input, int markerLength)
            => markerFinderApproach.FindMarker(input, markerLength);
    }
}
