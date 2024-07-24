/* CSE 381 - Convex Hull (Graham Scan)
*  (c) BYU-Idaho - It is an honor code violation to post this
*  file completed in a public file sharing site. S4.
*
*  Instructions: Implement the Orientation, GetAngle, GetDist, and
*  GenerateHull functions per the instructions in the comments.  
*  Run all tests in ConvexHullTest.cs to verify your code.
*  Submit this file and the completed ConvexHull.md file into Canvas.
*/
//#define GENHULLV2
namespace AlgorithmLib;

public static class ConvexHull
{
    /* Valid angle types to be used in the code */
    public enum Angle
    {
        Convex,
        Concave,
        Colinear
    }

    /* Representation of a 2D point with support
     * for comparing 2 points for equivalence.
    */
    public class Point
    {
        public readonly double X;
        public readonly double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /* This function supports testing */
        public bool Equals(Point point)
        {
            return Math.Abs(X - point.X) < 0.001 &&
                   Math.Abs(Y - point.Y) < 0.001;
        }
    }

    /* Determine if 3 points form a convex, concave, or
     * co-linear angle.
     *
     *  Inputs:
     *     a - Point 1
     *     b - Point 2
     *     c - Point 3
     *  Outputs:
     *     Return Angle.Convex, Angle.Concave, or Angle.Colinear
     */
    public static Angle Orientation(Point a, Point b, Point c)
    {
        double crossProduct = (b.Y - a.Y) * (c.X - b.X) - (b.X - a.X) * (c.Y - b.Y);

        if (Math.Abs(crossProduct) < 0.001)
            return Angle.Colinear;
        else if (crossProduct > 0)
            return Angle.Concave;
        else
            return Angle.Convex;
    }

    /* Determine the angle of a point relative to an anchor point.
     *
     *  Inputs:
     *     anchor - Anchor point
     *     point - Other point
     *  Outputs:
     *     Return angle in radians
     */
    public static double GetAngle(Point anchor, Point point)
    {
        double deltaX = point.X - anchor.X;
        double deltaY = point.Y - anchor.Y;
        return Math.Atan2(deltaY, deltaX);
    }

    /* Determine the distance from an anchor point to another point
     *
     *  Inputs:
     *     anchor - Anchor point
     *     point - Other point
     *  Outputs:
     *     Return distance
     */
    public static double GetDist(Point anchor, Point point)
    {
        double deltaX = point.X - anchor.X;
        double deltaY = point.Y - anchor.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    /* Generate a Convex Hull from a list of points using Graham Scan.
     *
     *  Inputs:
     *     points - List of points to create hull around
     *  Outputs:
     *     Return list of points in the hull
     *
     * NOTE: If no hull exists, then return an empty list.
     */
    public static List<Point> GenerateHull(List<Point> points)
    {
        if (points.Count < 3)
            return new List<Point>(); // Return an empty list if less than 3 points

        // Find the point with the lowest Y coordinate, breaking ties by X coordinate
        Point anchor = points[0];
        foreach (var point in points)
        {
            if (point.Y < anchor.Y || (point.Y == anchor.Y && point.X < anchor.X))
                anchor = point;
        }

        // Sort the points by polar angle with the anchor, breaking ties by distance to the anchor
        points = points.OrderBy(p => GetAngle(anchor, p)).ThenBy(p => GetDist(anchor, p)).ToList();

        // Use a stack to process the points and build the convex hull
        Stack<Point> hull = new Stack<Point>();
        hull.Push(points[0]);
        hull.Push(points[1]);

        for (int i = 2; i < points.Count; i++)
        {
            Point top = hull.Pop();
            while (hull.Count > 0 && Orientation(hull.Peek(), top, points[i]) != Angle.Convex)
            {
                top = hull.Pop();
            }
            hull.Push(top);
            hull.Push(points[i]);
        }

        // Convert the stack to a list and add the first point to close the hull
        var hullList = hull.ToList();
        hullList.Reverse();
        hullList.Add(hullList[0]);

        return hullList;
    }
}