using System;
using System.Collections.Generic;
using System.Linq;

using Example.Algorithms;

using Xunit;

public class Tests
{
    public static IEnumerable<object[]> T1Dataset()
    {
        yield return new object[] { Array.Empty<int>(), 0 };
        yield return new object[] { new[] { 0 }, 0 };
        yield return new object[] { new[] { 1 }, 1 };
        yield return new object[] { new[] { 0, 0 }, 0 };
        yield return new object[] { new[] { 0, 1 }, 1 };
        yield return new object[] { new[] { 1, 0 }, 1 };
        yield return new object[] { new[] { 1, 1 }, 2 };
        yield return new object[] { new[] { 1, 0, 1 }, 2 };
        yield return new object[] { new[] { 0, 1, 0 }, 1 };
        yield return new object[] { new[] { 1, 1, 0, 1, 1 }, 4 };
        yield return new object[] { new[] { 1, 0, 1, 0, 1 }, 3 };
        yield return new object[] { new[] { 1, 0, 1, 0, 1, 0 }, 3 };
        yield return new object[] { new[] { 1, 1, 0, 0, 1, 1, 0, 1, 1, 0 }, 4 };
        yield return new object[] { new[] { 1, 1, 0, 0, 1, 1, 0, 1, 1, 1 }, 5 };
        yield return new object[] { new[] { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0 }, 7 };
    }

    /// <summary>
    /// 1. Дан массив из нулей и единиц.
    ///    Нужно определить, какой максимальный по длине подинтервал единиц можно получить,
    ///    удалив ровно один элемент массива.
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="expect"></param>
    [Theory, MemberData(nameof(T1Dataset))]
    public void Test1_1(int[] arr, int expect)
    {
        var result = Experiments.Algorithm1_1(arr);
        Assert.True(result == expect, $"expect: {expect}, result: {result}");
    }

    [Theory, MemberData(nameof(T1Dataset))]
    public void Test1_2(int[] arr, int expect)
    {
        var result = Experiments.Algorithm1_2(arr);
        Assert.True(result == expect, $"expect: {expect}, result: {result}");
    }

    public static IEnumerable<object[]> T2Dataset()
    {
        yield return new object[] { Array.Empty<int>(), 2, new int[] { } };
        yield return new object[] { new[] { 1 }, 2, new[] { 1 } };
        yield return new object[] { new[] { 1, 2 }, 2, new[] { 2, 1 } };
        yield return new object[] { new[] { 1, 2, 3 }, 2, new[] { 3, 2 } };
        yield return new object[] { new[] { 3, 2, 1 }, 2, new[] { 3, 2 } };
        yield return new object[] { new[] { 3, 2 }, 2, new[] { 3, 2 } };
        yield return new object[] { new[] { -1 }, 2, new[] { -1 } };
        yield return new object[] { new[] { -1, -2 }, 2, new[] { -1, -2 } };
        yield return new object[] { new[] { -1, -2, -3 }, 2, new[] { -1, -2 } };
        yield return new object[] { new[] { -3, -2, -1 }, 2, new[] { -1, -2 } };
        yield return new object[] { new[] { -3, -2 }, 2, new[] { -2, -3 } };
        yield return new object[] { new[] { -3, -3, -2 }, 2, new[] { -2, -3 } };
    }

    /// <summary>
    /// 2. Вернуть 2 наибольших числа в массиве
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="expect"></param>
    [Theory, MemberData(nameof(T2Dataset))]
    public void Test2_1(int[] arr, int k, int[] expect)
    {
        var result = Experiments.Algorithm2_1(arr, k);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    [Theory, MemberData(nameof(T2Dataset))]
    public void Test2_2(int[] arr, int k, int[] expect)
    {
        var result = Experiments.Algorithm2_2(arr, k);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    [Theory, MemberData(nameof(T2Dataset))]
    public void Test2_3(int[] arr, int k, int[] expect)
    {
        var result = Experiments.Algorithm2_3(arr, k);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    [Theory, MemberData(nameof(T2Dataset))]
    public void Test2_4(int[] arr, int k, int[] expect)
    {
        var result = Experiments.Algorithm2_4(arr, k);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    public static IEnumerable<object[]> T3Dataset()
    {
        yield return new object[] { "", "" };
        yield return new object[] { "a", "1a" };
        yield return new object[] { "aa", "2a" };
        yield return new object[] { "ab", "1a1b" };
        yield return new object[] { "aaBBBcDDDD", "2a3B1c4D" };
    }

    /// <summary>
    /// 3. Сжатие строки (RLE)
    /// </summary>
    /// <param name="text"></param>
    /// <param name="expect"></param>
    [Theory, MemberData(nameof(T3Dataset))]
    public void Test3_1(string text, string expect)
    {
        var result = Experiments.Algorithm3_1(text);
        Assert.True(expect == result, $"expect: {expect}, result: {result}");
    }

    public static IEnumerable<object[]> T4Dataset()
    {
        yield return new object[] { new int[] { }, new int[] { } };
        yield return new object[] { new[] { 0 }, new int[] { } };
        yield return new object[] { new[] { 0, 1 }, new[] { 1 } };
        yield return new object[] { new[] { 0, 0 }, new int[] { } };
        yield return new object[] { new[] { 1, 2 }, new[] { 1, 2 } };
        yield return new object[] { new[] { 1, 0, 2 }, new[] { 1, 2 } };
        yield return new object[] { new[] { 2, 1, 0 }, new[] { 2, 1 } };
        yield return new object[] { new[] { 1, 3, 0, 0, 2 }, new[] { 1, 3, 2 } };
    }

    /// <summary>
    /// 4. Дан вектор, надо удалить из него нули, сохранив порядок остальных элементов
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="expect"></param>
    [Theory, MemberData(nameof(T4Dataset))]
    public void Test4_1(int[] arr, int[] expect)
    {
        var result = Experiments.Algorithm4_1(arr);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    public static IEnumerable<object[]> T5Dataset()
    {
        yield return new object[] { new int[] { }, 4, 3, new int[] { } };
        yield return new object[] { new[] { 1 }, 4, 3, new[] { 1 } };
        yield return new object[] { new[] { 1, 3 }, 4, 3, new[] { 1, 3 } };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 4, 3, new[] { 1, 2, 3, 4 } };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 4, 5, new[] { 2, 3, 4, 5 } };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 4, 6, new[] { 2, 3, 4, 5 } };
        yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 4, -1, new[] { 1, 2, 3, 4 } };
    }

    /// <summary>
    /// 5. Найти K ближайших к заданному элементов в отсортированном массиве
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="k"></param>
    /// <param name="x"></param>
    [Theory, MemberData(nameof(T5Dataset))]
    public void Test5_1(int[] arr, int k, int x, int[] expect)
    {
        var result = Experiments.Algorithm5_1(arr, k, x);
        Assert.Collection(result, CreateElementInspectors(expect));
    }

    private static Action<int>[] CreateElementInspectors(int[] values)
    {
        return values.Select((expect) =>
        {
            Action<int> inspector = (result)
                => Assert.True(expect == result, $"expect: {expect}, result: {result}");
            return inspector;
        }).ToArray();
    }
}