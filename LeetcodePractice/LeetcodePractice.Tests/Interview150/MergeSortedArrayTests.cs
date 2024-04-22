using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePractice.Tests.Interview150;

public class MergeSortedArrayTests
{
    private MergeSortedArray sut;

    public MergeSortedArrayTests()
    {
        sut = new MergeSortedArray();
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void MergeShouldStoreSortedArrayIntoArr1(int[] arr1, int m, int[] arr2, int n, int[] expected)
    {
        sut.Merge(arr1, m, arr2, n);
        arr1.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new int[] { }, 0, new int[] { }, 0, new int[] { } },
            new object[] { new int[] { 1, 2, 3 }, 3, new int[] { }, 0, new int[] { 1, 2, 3 } },
            new object[] { new int[] { 1, 2, 3, 4, 0, 0, 0 }, 4, new int[] { 0, 2, 5 }, 3, new int[] { 0, 1, 2, 2, 3, 4, 5 } },
        };
}
