using System.Collections.Generic;
using System.Linq;
using System.Text;

using static System.Math;

namespace Example.Algorithms
{
    public static class Experiments
    {
        public static int Algorithm1_1(int[] arr)
        {
            var curr = 0;
            var result = 0;

            for (int i = 0, l = arr.Length; i < l; i++)
            {
                if (i > 0 && arr[i - 1] == 0 && arr[i] == 0)
                {
                    result = Max(result, curr);
                    curr = 0;
                }
                else if (arr[i] == 1)
                {
                    curr++;
                }
            }

            return Max(result, curr);
        }

        public static int Algorithm1_2(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            var curr = 0;
            var best = 0;

            var l = arr.Length - 1;
            for (int i = 0; i < l; i++)
            {
                if (arr[i] == 0 && arr[i + 1] == 0)
                {
                    best = Max(best, curr);
                    curr = 0;
                }
                else if (arr[i] == 1)
                {
                    curr++;
                }
            }

            if (arr[l] == 1)
            {
                curr++;
            }

            best = Max(best, curr);

            return best;
        }

        public static IEnumerable<int> Algorithm2_1(int[] arr, int k)
        {
            return new SortedSet<int>(arr).Reverse().Take(k);
        }

        readonly static Comparer<int> _comparer = Comparer<int>.Create((a, b) => b - a);
        public static IEnumerable<int> Algorithm2_2(int[] arr, int k)
        {
            return new SortedSet<int>(arr, _comparer).Take(k);
        }

        public static IEnumerable<int> Algorithm2_3(int[] arr, int k)
        {
            var set = new SortedSet<int>(_comparer);

            for (int i = 0, l = arr.Length; i < l; i++)
            {
                if (!set.Contains(arr[i]))
                {
                    set.Add(arr[i]);

                    if (set.Count > k)
                    {
                        set.Remove(set.Last());
                    }
                }
            }

            return set.Take(k);
        }

        public static IEnumerable<int> Algorithm2_4(int[] arr, int k)
        {
            var set = new SortedSet<int>(_comparer);

            for (int i = 0, l = arr.Length; i < l; i++)
            {
                set.Add(arr[i]);

                if (set.Count > k)
                {
                    set.Remove(set.Last());
                }
            }

            return set.Take(k);
        }

        public static string Algorithm3_1(string s)
        {
            if (s.Length == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            var curr = s[0];
            var count = 1;

            for (int i = 1, l = s.Length; i < l; i++)
            {
                if (s[i] == curr)
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(curr);
                    curr = s[i];
                    count = 1;
                }
            }

            if (count != 0)
            {
                sb.Append(count);
                sb.Append(s[s.Length - 1]);
            }

            return sb.ToString();
        }

        public static IEnumerable<int> Algorithm4_1(int[] arr)
        {
            var p = 0;
            for (int i = 0, l = arr.Length; i < l; i++)
            {
                if (arr[i] != 0)
                {
                    arr[p++] = arr[i];
                }
            }
            return arr[..p];
        }

        public static IEnumerable<int> Algorithm5_1(int[] arr, int k, int x)
        {
            if (arr.Length <= k)
            {
                return arr;
            }

            var left = 0;
            // 1
            var right = arr.Length - k;

            while (left < right)
            {
                // (0 + 1) / 2 = 0
                var mid = (left + right) / 2;
                //     (0)   (0 + 4)
                // -1 - 1   > 5       - -1
                if (x - arr[mid] > arr[mid + k] - x)
                {
                    left = mid + 1;
                }
                else
                {
                    // here
                    right = mid;
                }
            }

            return arr[left..(left + k)];
        }
    }
}
