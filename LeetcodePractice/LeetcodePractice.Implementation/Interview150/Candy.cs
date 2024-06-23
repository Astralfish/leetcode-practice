namespace LeetcodePractice.Implementation.Interview150;

/// <summary>
/// https://leetcode.com/problems/candy/description/?envType=study-plan-v2&envId=top-interview-150
/// </summary>
public class Candy
{
    public int MinimumRequiredCandy(List<int> children)
    {
        //var childrenWithCandy = children.Select(c => new ChildWithCandy(c, 1)).ToList();
        //LeftPass(childrenWithCandy);
        //RightPass(childrenWithCandy);
        //return childrenWithCandy.Sum(x => x.Candy);
        return ValleyAndPeaksAlgorithm(children);
    }

    //Based on an algorithm described by Leetcode user TITAN (https://leetcode.com/problems/candy/solutions/2234434/c-o-n-time-o-1-space-full-explanation/)
    //O(n) time, O(1) space
    public int ValleyAndPeaksAlgorithm(List<int> children)
    {
        var candy = children.Count;
        var risingSlopeCounter = 0;
        var fallingSlopeCounter = 0;
        var previousPeakHeight = 0;

        for (int i = 1; i < children.Count; i++)
        {
            var current = children[i];
            var previous = children[i - 1];

            if (previous < current)
            {
                fallingSlopeCounter = 0;
                risingSlopeCounter++;
                previousPeakHeight = risingSlopeCounter;
                candy += risingSlopeCounter;
            }
            else if (previous > current)
            {
                fallingSlopeCounter++;
                risingSlopeCounter = 0;
                var shallowValleyModifier = fallingSlopeCounter <= previousPeakHeight ? -1 : 0;
                candy += fallingSlopeCounter + shallowValleyModifier;
            }
            else
            {
                fallingSlopeCounter = 0;
                risingSlopeCounter = 0;
                previousPeakHeight = 0;
            }
        }
        return candy;
    }

    public enum Trend
    {
        Constant,
        Rising,
        Falling,
    }

    public void RightPass(List<ChildWithCandy> childrenWithCandy)
    {
        for (int i = 1; i < childrenWithCandy.Count; i++)
        {
            var current = childrenWithCandy[i];
            var leftNeighbor = childrenWithCandy[i - 1];
            if (leftNeighbor.Rating < current.Rating && leftNeighbor.Candy >= current.Candy)
            {
                current.Candy = leftNeighbor.Candy + 1;
            }
        }
    }

    public void LeftPass(List<ChildWithCandy> childrenWithCandy)
    {
        for (int i = childrenWithCandy.Count - 2; i >= 0; i--)
        {
            var current = childrenWithCandy[i];
            var rigthNeighbor = childrenWithCandy[i + 1];
            if (rigthNeighbor.Rating < current.Rating && rigthNeighbor.Candy >= current.Candy)
            {
                current.Candy = rigthNeighbor.Candy + 1;
            }
        }
    }

    public class ChildWithCandy
    {
        public ChildWithCandy(int rating, int candy)
        {
            this.Rating = rating;
            this.Candy = candy;
        }

        public int Rating { get; set; }

        public int Candy { get; set; }
    }
}
