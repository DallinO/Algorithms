# Convex Hull (Graham Scan) - Algorithm Report

(c) BYU-Idaho - It is an honor code violation to post this file completed in a public file sharing site. S4.

Name: 

## 1. Code (60%)

Make sure that you submit both the ConvexHull.cs file and this markdown file.

## 2. Methodology (20%)

NOTE: Do not copy/paste from an AI or the book.  Answer these questions in your own words without code.  You will either receive a grade of `Correct`, `More Detail Needed`, or `Incorrect` for each question.

1. Explain how the points are sorted in the Convex Hull (Graham Scan) algorithm.

In the Graham Scan algorithm for finding the convex hull of a set of points, sorting the points is a crucial step. The process begins by identifying the anchor point, which is the point with the lowest Y-coordinate, and if there are ties, the lowest X-coordinate. This anchor point serves as a reference for sorting the remaining points based on the polar angle they make with the anchor, calculated using the arctangent of the slope between the anchor and each point. If two points have the same polar angle, they are further sorted by their distance from the anchor to ensure the closest points are considered first. This sorting order ensures that points are processed in a counterclockwise direction, which is essential for constructing the convex hull. During the hull construction, points are added to a stack, and concave angles are managed by backtracking and removing the last point added. Finally, the hull is closed by adding the first point again at the end, forming a complete loop of the boundary points.

2. Explain how the algorithm can determine if three points form a convex, concave, or co-linear angle.

In the Graham Scan algorithm used to determine the convex hull of a set of points, the orientation of three points a, b, and c is determined using the cross product of vectors. This involves calculating the cross product of vectors formed by points a-b and b-c. The sign of this cross product indicates whether the angle abc is convex, concave, or if the points are colinear. A negative cross product means a convex angle, indicating a left turn in the sequence of points. A positive cross product means a concave angle, indicating a right turn. When the cross product is zero, or very close to zero considering floating-point precision, it signifies that the points are colinear.

3. Explain how the algorithm selects the correct points for inclusion in the hull.

In the Graham Scan algorithm for constructing the convex hull of a set of points, the selection of points for inclusion follows a methodical process to ensure the resulting hull forms a counterclockwise loop around the outermost boundary. It begins by choosing an anchor point, typically the point with the lowest Y-coordinate, and ties are broken by selecting the point with the lowest X-coordinate. Points are then sorted based on the polar angles they form with the anchor point, calculated using the arctangent function. This sorting ensures that points are processed in a sequence that follows a counterclockwise direction around the anchor, which is essential for correctly identifying the hull vertices. As the algorithm iterates through the sorted points, it uses a stack to maintain the vertices of the hull. Points are added to the hull if they form a convex angle with the last two points on the stack, while points resulting in a concave angle are omitted, indicating they lie inside the hull boundary. Finally, the hull is closed by adding the anchor point again to complete the loop.

## 3. Performance (10%)

The performance for generating the convex hull (where $n$ is the number points):

* Worst Case: $O(n log n)$
* Best Case: $\Omega(n log n)$

## 4. AI Research (10%)

NOTE: Do not copy/paste from the AI.  Describe what you learned in at least 100 of your own words.

Using an AI, explore a different algorithm called Jarvis March and describe how it works and compares with Graham Scan. 

Graham Scan and Jarvis March are both algorithms used to compute the convex hull of a set of points in a plane, each with distinct approaches and performance characteristics. Graham Scan initiates by selecting an anchor point and sorting all other points based on their polar angles relative to this anchor. It then scans through the sorted points to construct the hull, leaning for efficiency but resulting in a O(nlogn) time complexity in both average and worst cases due to the sorting step. This method is advantageous for its robust handling of colinear points and efficiency with uniformly or randomly distributed datasets. In contrast, Jarvis March, also known as the Gift Wrapping algorithm, iteratively selects the next point that forms the smallest counter-clockwise angle with the current hull point, continuing until it completes the hull. While simpler to implement, Jarvis March can be less efficient with a worst-case time complexity of O(n2), especially in dense datasets where n represents the number of points. However, it can outperform Graham Scan in scenarios where the resulting hull h is significantly smaller than n. Therefore, the choice between Graham Scan and Jarvis March depends on factors such as dataset characteristics and desired computational efficiency, with Graham Scan generally favored for its overall performance and handling of diverse point distributions.