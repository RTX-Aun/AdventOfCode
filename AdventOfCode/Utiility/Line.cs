namespace AdventOfCode.Utilities
{
    using System;
    using System.Collections.Generic;

    public static class LineUtilityMethods
    {
        public static IEnumerable<Point> GetPointsOnLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                var t = x0;
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                var t = x0;
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }
            var dx = x1 - x0;
            var dy = Math.Abs(y1 - y0);
            var error = dx / 2;
            var yStep = y0 < y1 ? 1 : -1;
            var y = y0;
            for (var x = x0; x <= x1; x++)
            {
                yield return new Point(steep ? y : x, steep ? x : y);
                error -= dy;
                if (error >= 0) continue;
                y += yStep;
                error += dx;
            }
        }
    }
}