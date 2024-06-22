namespace LeetcodePractice.Implementation.Interview150;

/// <summary>
/// https://leetcode.com/problems/candy/description/?envType=study-plan-v2&envId=top-interview-150
/// </summary>
public class Candy
{
    public int MinimumRequiredCandy(List<int> children)
    {
        var childrenWithCandy = children.Select(c => (rating: c, candy: 1)).ToList();
        while (!DistributeCandy(childrenWithCandy))
        {
        }
        return childrenWithCandy.Sum(x => x.candy);
    }

    public bool DistributeCandy(List<(int rating, int candy)> childrenWithCandy)
    {
        var wasCorrectlyDistributed = true;
        for (int i = 0; i < childrenWithCandy.Count; i++)
        {
            var current = childrenWithCandy[i];
            var leftNeighbor = i > 0 ? childrenWithCandy[i - 1] : (rating: 0, candy: 0);
            var rightNeighbor = i < childrenWithCandy.Count - 1 ? childrenWithCandy[i + 1] : (rating: 0, candy: 0);
            bool shouldGetAdditionalCandy = (current.rating > leftNeighbor.rating && current.candy <= leftNeighbor.candy) || (current.rating > rightNeighbor.rating && current.candy <= rightNeighbor.candy);
            if (shouldGetAdditionalCandy)
            {
                wasCorrectlyDistributed = false;
                childrenWithCandy[i] = (current.rating, current.candy + 1);
            }
        }
        return wasCorrectlyDistributed;
    }
}
