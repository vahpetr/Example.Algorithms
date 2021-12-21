# Example Algorithms

Project example how write algorithms tests and benchmarks

## How run

```bash
# Run test
dotnet test -f net6.0 -c Release

# Run benchmark
dotnet run -f net6.0 -c Release
```

## Tests results

Passed!  - Failed:     0, Passed:    98, Skipped:     0, Total:    98, Duration: 34 ms

## Benchmark results

``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.6 (20G165) [Darwin 20.6.0]
Intel Core i9-9880H CPU 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  Job-USRMOK : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Runtime=.NET 6.0  IterationCount=5  

```
|   Method | Categories |        Mean |     Error |    StdDev |         Min |         Max |      Median | Ratio | RatioSD | Rank |  Gen 0 | Allocated |
|--------- |----------- |------------:|----------:|----------:|------------:|------------:|------------:|------:|--------:|-----:|-------:|----------:|
| Bench1_2 | Algorithm1 |   100.64 ns |  2.044 ns |  0.531 ns |    99.96 ns |   101.22 ns |   100.72 ns |  0.94 |    0.06 |    1 |      - |         - |
| Bench1_1 | Algorithm1 |   107.85 ns | 25.097 ns |  6.518 ns |    97.09 ns |   114.30 ns |   110.06 ns |  1.00 |    0.00 |    1 |      - |         - |
|          |            |             |           |           |             |             |             |       |         |      |        |           |
| Bench2_1 | Algorithm2 |   982.85 ns | 40.360 ns | 10.481 ns |   973.84 ns |   998.35 ns |   977.08 ns |  1.00 |    0.00 |    1 | 0.4139 |   3,464 B |
| Bench2_2 | Algorithm2 | 1,037.74 ns | 39.539 ns | 10.268 ns | 1,027.28 ns | 1,050.69 ns | 1,035.01 ns |  1.06 |    0.01 |    2 | 0.3796 |   3,176 B |
| Bench2_4 | Algorithm2 | 1,212.24 ns | 21.854 ns |  5.676 ns | 1,206.23 ns | 1,219.35 ns | 1,214.22 ns |  1.23 |    0.02 |    3 | 0.3357 |   2,816 B |
| Bench2_3 | Algorithm2 | 1,224.22 ns | 38.611 ns |  5.975 ns | 1,218.53 ns | 1,231.84 ns | 1,223.25 ns |  1.24 |    0.02 |    3 | 0.3357 |   2,816 B |
|          |            |             |           |           |             |             |             |       |         |      |        |           |
| Bench3_1 | Algorithm3 |   146.91 ns |  2.539 ns |  0.659 ns |   145.90 ns |   147.42 ns |   147.32 ns |  1.00 |    0.00 |    1 | 0.0658 |     552 B |
|          |            |             |           |           |             |             |             |       |         |      |        |           |
| Bench4_1 | Algorithm4 |   103.61 ns | 20.242 ns |  5.257 ns |    97.42 ns |   107.93 ns |   106.61 ns |  1.00 |    0.00 |    1 | 0.0219 |     184 B |
|          |            |             |           |           |             |             |             |       |         |      |        |           |
| Bench5_1 | Algorithm5 |    73.10 ns | 11.906 ns |  3.092 ns |    68.12 ns |    75.58 ns |    74.34 ns |  1.00 |    0.00 |    1 | 0.0191 |     160 B |

## Links
1. [BenchmarkDotNet](ttps://benchmarkdotnet.org/articles/overview.html)
