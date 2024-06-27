using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePractice.Implementation.Interview150;
public class TextJustification
{
    public List<string> Justify(List<string> words, int maxWidth)
    {
        var lines = SplitIntoLines(words, maxWidth).ToList();
        var spaceDistribution = CalculateSpaceDistribution(lines, maxWidth).ToList();
        return GenerateLines(lines, spaceDistribution).ToList();
    }

    public IEnumerable<List<string>> SplitIntoLines(List<string> words, int maxWidth)
    {
        var currentLine = new List<string>();
        var currentLineLength = 0;

        foreach (var word in words)
        {
            if (currentLineLength + word.Length > maxWidth - currentLine.Count)
            {
                yield return currentLine;
                currentLine = new List<string>() { word };
                currentLineLength = word.Length;
            }
            else
            {
                currentLine.Add(word);
                currentLineLength += word.Length;
            }
        }

        if (currentLine.Any())
        {
            yield return currentLine;
        }
    }

    public IEnumerable<List<int>> CalculateSpaceDistribution(List<List<string>> lines, int maxWidth)
    {
        for (int i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var numberOfSpaces = maxWidth - line.Sum(l => l.Length);
            var spaceDistribution = new List<int>(line.Count);
            var numberOfSpots = line.Count - 1;

            if (line.Count > 1 && i < lines.Count - 1)
            {
                yield return line.Select((w, index) => numberOfSpaces / numberOfSpots + (index < numberOfSpaces % numberOfSpots ? 1 : 0))
                    .SkipLast(1)
                    .Append(0)
                    .ToList();
            }
            else
            {
                yield return line.Select(w => 1)
                    .SkipLast(1)
                    .Append(numberOfSpaces - numberOfSpots)
                    .ToList();
            }
        }
    }

    public IEnumerable<string> GenerateLines(List<List<string>> lines, List<List<int>> spaceDistribution)
    {
        foreach (var (words, spaces) in lines.Zip(spaceDistribution))
        {
            var line = "";
            foreach (var (word, space) in words.Zip(spaces))
            {
                line += word + new string(' ', space);
            }
            yield return line;
        }
    }
}
