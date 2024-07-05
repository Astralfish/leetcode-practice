using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePractice.Tests.Interview150;
public class SingleNumberTests
{
    private readonly SingleNumber sut = new SingleNumber();

    [Theory]
    [MemberData(nameof(FindSingleNumberTestData))]
    public void FindSingleNumber_ShouldReturnSingleNumber(int[] numbers, int expected)
    {
        var result = sut.FindSingleNumber(numbers);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> FindSingleNumberTestData()
    {
        yield return [new int[] { 2, 2, 1 }, 1];
        yield return [new int[] { 4, 1, 2, 1, 2 }, 4];
        yield return [new int[] { 1 }, 1];
    }
}
