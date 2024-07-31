namespace LeetcodePractice.Implementation.Interview150;

public class WordBreak
{
    public bool CanBeBroken(string word, IList<string> fragments)
    {
        var breakpoints = new List<bool> { true }.Concat(Enumerable.Repeat(false, word.Length)).ToList();

        for (int i = 1; i <= word.Length; i++)
        {
            foreach (var fragment in fragments)
            {
                var start = i - fragment.Length;
                if (start >= 0 && breakpoints[start] && word.Substring(start).StartsWith(fragment))
                {
                    breakpoints[i] = true;
                    break;
                }
            }
        }

        return breakpoints.Last();
    }
}
