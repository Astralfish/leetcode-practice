namespace LeetcodePractice.Implementation.Interview150;
public class ClimbingStairs
{
    public int HowManyWays(int numberOfSteps)
    {
        var counter = new int[numberOfSteps + 1];
        counter[0] = 1;
        counter[1] = 1;

        for (int i = 2; i <= numberOfSteps; i++)
        {
            counter[i] = counter[i - 1] + counter[i - 2];
        }

        return counter[numberOfSteps];
    }
}
