using System.Linq;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;

using Example.Algorithms;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net60, targetCount: 5, baseline: true)]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn(NumeralSystem.Arabic)]
[MarkdownExporter]
public class Benchy
{
    private static int[][] dataset1 = Tests.Test1Dataset().Select(p => (int[])p[0]).ToArray();
    private static (int[], int)[] dataset2 = Tests.Test2Dataset().Select(p => ((int[])p[0], (int)p[1])).ToArray();
    private static string[] dataset3 = Tests.Test3Dataset().Select(p => (string)p[0]).ToArray();
    private static int[][] dataset4 = Tests.Test4Dataset().Select(p => (int[])p[0]).ToArray();
    private static (int[], int, int)[] dataset5 = Tests.Test5Dataset().Select(p => ((int[])p[0], (int)p[1], (int)p[2])).ToArray();

    [BenchmarkCategory("Algorithm1"), Benchmark(Baseline = true)]
    public void Bench1_1()
    {
        for (int i = 0, l = dataset1.Length; i < l; i++)
        {
            Experiments.Algorithm1_1(dataset1[i]);
        }
    }

    [BenchmarkCategory("Algorithm1"), Benchmark]
    public void Bench1_2()
    {
        for (int i = 0, l = dataset1.Length; i < l; i++)
        {
            Experiments.Algorithm1_2(dataset1[i]);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark(Baseline = true)]
    public void Bench2_1()
    {
        for (int i = 0, l = dataset2.Length; i < l; i++)
        {
            Experiments.Algorithm2_1(dataset2[i].Item1, dataset2[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_2()
    {
        for (int i = 0, l = dataset2.Length; i < l; i++)
        {
            Experiments.Algorithm2_2(dataset2[i].Item1, dataset2[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_3()
    {
        for (int i = 0, l = dataset2.Length; i < l; i++)
        {
            Experiments.Algorithm2_3(dataset2[i].Item1, dataset2[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_4()
    {
        for (int i = 0, l = dataset2.Length; i < l; i++)
        {
            Experiments.Algorithm2_3(dataset2[i].Item1, dataset2[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm3"), Benchmark(Baseline = true)]
    public void Bench3_1()
    {
        for (int i = 0, l = dataset3.Length; i < l; i++)
        {
            Experiments.Algorithm3_1(dataset3[i]);
        }
    }

    [BenchmarkCategory("Algorithm4"), Benchmark(Baseline = true)]
    public void Bench4_1()
    {
        for (int i = 0, l = dataset4.Length; i < l; i++)
        {
            Experiments.Algorithm4_1(dataset4[i]);
        }
    }

    [BenchmarkCategory("Algorithm5"), Benchmark(Baseline = true)]
    public void Bench5_1()
    {
        for (int i = 0, l = dataset5.Length; i < l; i++)
        {
            Experiments.Algorithm5_1(dataset5[i].Item1, dataset5[i].Item2, dataset5[i].Item3);
        }
    }
}
