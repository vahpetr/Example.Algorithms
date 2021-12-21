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

    private static int[][] t1dataset = Tests.T1Dataset().Select(p => (int[])p[0]).ToArray();
    private static (int[], int)[] t2dataset = Tests.T2Dataset().Select(p => ((int[])p[0], (int)p[1])).ToArray();
    private static string[] t3dataset = Tests.T3Dataset().Select(p => (string)p[0]).ToArray();
    private static int[][] t4dataset = Tests.T4Dataset().Select(p => (int[])p[0]).ToArray();
    private static (int[], int, int)[] t5dataset = Tests.T5Dataset().Select(p => ((int[])p[0], (int)p[1], (int)p[2])).ToArray();

    [BenchmarkCategory("Algorithm1"), Benchmark(Baseline = true)]
    public void Bench1_1()
    {
        for (int i = 0, l = t1dataset.Length; i < l; i++)
        {
            Experiments.Algorithm1_1(t1dataset[i]);
        }
    }

    [BenchmarkCategory("Algorithm1"), Benchmark]
    public void Bench1_2()
    {
        for (int i = 0, l = t1dataset.Length; i < l; i++)
        {
            Experiments.Algorithm1_2(t1dataset[i]);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark(Baseline = true)]
    public void Bench2_1()
    {
        for (int i = 0, l = t2dataset.Length; i < l; i++)
        {
            Experiments.Algorithm2_1(t2dataset[i].Item1, t2dataset[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_2()
    {
        for (int i = 0, l = t2dataset.Length; i < l; i++)
        {
            Experiments.Algorithm2_2(t2dataset[i].Item1, t2dataset[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_3()
    {
        for (int i = 0, l = t2dataset.Length; i < l; i++)
        {
            Experiments.Algorithm2_3(t2dataset[i].Item1, t2dataset[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm2"), Benchmark]
    public void Bench2_4()
    {
        for (int i = 0, l = t2dataset.Length; i < l; i++)
        {
            Experiments.Algorithm2_3(t2dataset[i].Item1, t2dataset[i].Item2);
        }
    }

    [BenchmarkCategory("Algorithm3"), Benchmark(Baseline = true)]
    public void Bench3_1()
    {
        for (int i = 0, l = t3dataset.Length; i < l; i++)
        {
            Experiments.Algorithm3_1(t3dataset[i]);
        }
    }

    [BenchmarkCategory("Algorithm4"), Benchmark(Baseline = true)]
    public void Bench4_1()
    {
        for (int i = 0, l = t4dataset.Length; i < l; i++)
        {
            Experiments.Algorithm4_1(t4dataset[i]);
        }
    }

    [BenchmarkCategory("Algorithm5"), Benchmark(Baseline = true)]
    public void Bench5_1()
    {
        for (int i = 0, l = t5dataset.Length; i < l; i++)
        {
            Experiments.Algorithm5_1(t5dataset[i].Item1, t5dataset[i].Item2, t5dataset[i].Item3);
        }
    }
}
