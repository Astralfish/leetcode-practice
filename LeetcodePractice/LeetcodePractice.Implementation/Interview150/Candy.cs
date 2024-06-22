namespace LeetcodePractice.Implementation.Interview150;

/// <summary>
/// https://leetcode.com/problems/candy/description/?envType=study-plan-v2&envId=top-interview-150
/// </summary>
public class Candy
{
    public int MinimumRequiredCandy(List<int> children)
    {
        var childrenWithCandy = children.Select(c => new ChildWithCandy(c, 1)).ToList();
        LeftPass(childrenWithCandy);
        RightPass(childrenWithCandy);
        return childrenWithCandy.Sum(x => x.Candy);
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
