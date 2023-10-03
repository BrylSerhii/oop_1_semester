using System;
using System.Collections.Generic;

namespace Lab_1
{
    public static class ConvexityChecker
    {
        public static bool IsConvex(List<double> angles)
        {
            foreach (var angle in angles)
            {
                if (angle >= 180.0)
                    return false; // Not convex if any angle is 180 degrees or greater
            }
            return true; // All angles are less than 180 degrees, indicating convexity
        }
    }
}
