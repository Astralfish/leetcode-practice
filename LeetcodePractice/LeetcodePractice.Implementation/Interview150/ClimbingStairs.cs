namespace LeetcodePractice.Implementation.Interview150;
public class ClimbingStairs
{
    public int HowManyWays(int numberOfSteps)
    {
        var current = 1;
        var currentMinus1 = 1;
        var currentminus2 = 1;

        for (int i = 2; i <= numberOfSteps; i++)
        {
            current = currentMinus1 + currentminus2;
            currentminus2 = currentMinus1;
            currentMinus1 = current;
        }

        return current;
    }
}
