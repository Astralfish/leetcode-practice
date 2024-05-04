using FluentAssertions;
using LeetcodePractice.Implementation.Neetcode.Core;

namespace LeetcodePractice.Tests.Neetcode.Core;
public class DynamicArrayTests
{
    [Theory]
    [MemberData(nameof(GetShouldReturnValueAtIndexTestData))]
    public void GetShouldReturnValueAtIndex(DynamicArray array, int index, int expected)
    {
        var result = array.Get(index);
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(SetShouldSetValueAtIndexTestData))]
    public void SetShouldSetValueAtIndex(DynamicArray array, int index, int value, DynamicArray expected)
    {
        array.Set(index, value);
        array.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(PushBackShouldAddValueToTheEndTestData))]
    public void PushBackShouldAddValueToTheEnd(DynamicArray array, int value, DynamicArray expected)
    {
        array.PushBack(value);
        array.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [MemberData(nameof(PushBackShouldResizeArrayIfTooSmallTestData))]
    public void PushBackShouldResizeArrayIfTooSmall(DynamicArray array, int value, int expectedCapacity)
    {
        array.PushBack(value);
        array.GetCapacity().Should().Be(expectedCapacity);
    }

    [Theory]
    [MemberData(nameof(PopBackShouldReturnLastElementTestData))]
    public void PopBackShouldReturnLastElement(DynamicArray array, int expected)
    {
        var result = array.PopBack();
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(PopBackShouldRemoveReturnedElementTestData))]
    public void PopBackShouldRemoveReturnedElement(DynamicArray array, DynamicArray expected)
    {
        _ = array.PopBack();
        array.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> GetShouldReturnValueAtIndexTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), 0, -10 };
        yield return new object[] { new DynamicArray([-10, 0, 10]), 1, 0 };
        yield return new object[] { new DynamicArray([-10, 0, 10]), 2, 10 };
    }

    public static IEnumerable<object[]> SetShouldSetValueAtIndexTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), 0, int.MaxValue, new DynamicArray([int.MaxValue, 0, 10]) };
        yield return new object[] { new DynamicArray([-10, 0, 10]), 1, -1, new DynamicArray([-10, -1, 10]) };
        yield return new object[] { new DynamicArray([-10, 0, 10]), 2, int.MinValue, new DynamicArray([-10, 0, int.MinValue]) };
    }

    public static IEnumerable<object[]> PushBackShouldAddValueToTheEndTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), int.MaxValue, new DynamicArray([-10, 0, 10, int.MaxValue]) };
    }

    public static IEnumerable<object[]> PushBackShouldResizeArrayIfTooSmallTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), int.MaxValue, 6 };
    }

    public static IEnumerable<object[]> PopBackShouldReturnLastElementTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), 10 };
    }

    public static IEnumerable<object[]> PopBackShouldRemoveReturnedElementTestData()
    {
        yield return new object[] { new DynamicArray([-10, 0, 10]), new DynamicArray([-10, 0]) };
    }
}
