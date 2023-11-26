using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DSASolutions
{
    public class IntroductiontoProblemSolving1
    {
        public int CountFactors_2(int A)
        {
            //Problem Description
            //Given an integer A, you need to find the count of it's factors.
            //Factor of a number is the number which divides it perfectly leaving no remainder.
            //Example : 1, 2, 3, 6 are factors of 6
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(A); i++)
            {
                if (A % i == 0)
                {
                    if (A / i == i)
                    {
                        count++;
                    }
                    else
                    {
                        count = count + 2;
                    }
                }
            }
            return count;
        }

        public bool IsPalindrome(int x)
        {
            int temp = x;
            int sum = 0;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum = sum * 10 + digit;
                temp = temp / 10;
            }
            if (x == sum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RomanToInt(string s)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'I' && s.Length > i + 1)
                {
                    if (s[i + 1] == 'V' || s[i + 1] == 'V')
                    {
                        sum += symbols[s[i + 1]] - symbols[s[i]];
                        i++;
                    }
                    else
                    {
                        sum += symbols[s[i]];
                    }
                }
                else if (s[i] == 'X' && s.Length > i + 1)
                {
                    if (s[i + 1] == 'L' || s[i + 1] == 'C')
                    {
                        sum += symbols[s[i + 1]] - symbols[s[i]];
                        i++;
                    }
                    else
                    {
                        sum += symbols[s[i]];
                    }
                }
                else if (s[i] == 'C' && s.Length > i + 1)
                {
                    if (s[i + 1] == 'D' || s[i + 1] == 'M')
                    {
                        sum += symbols[s[i + 1]] - symbols[s[i]];
                        i++;
                    }
                    else
                    {
                        sum += symbols[s[i]];
                    }
                }
                else
                {
                    sum += symbols[s[i]];
                }
            }
            return sum;
        }

        public int NobleInteger(List<int> A)
        {
            A.Sort();
            int result = -1;
            int count = 0;
            if (A[A.Count - 1] == count)
            {
                return 1;
            }
            for (int i = A.Count - 2, j = 0; i >= 0; i--, j++)
            {
                if (A[i] != A[i + 1])
                {
                    count = j;
                }
                if (A[i] == count)
                {
                    return 1;
                }
            }
            return result;
        }

        public List<List<int>> Diagonal(List<List<int>> A)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < A.Count(); i++)
            {
                int r = 0, c = i;
                List<int> row = new List<int>();
                while (r < A.Count && c >= 0)
                {
                    row.Add(A[r][c]);
                    r++;
                    c--;
                }
                for (int j = row.Count; j < A.Count; j++)
                {
                    row.Add(0);
                }
                result.Add(row);
            }
            for (int i = 1; i < A.Count; i++)
            {
                List<int> row = new List<int>();
                int r = i, c = A[i].Count - 1;
                while (r < A.Count && c >= 0)
                {
                    row.Add(A[r][c]);
                    r++;
                    c--;
                }
                for (int j = row.Count; j < A.Count; j++)
                {
                    row.Add(0);
                }
                result.Add(row);
            }
            return result;
        }


        public List<List<int>> TransposeMatrix(List<List<int>> A)
        {
            int r = A.Count, c = A[0].Count;
            if (r > c)
            {
                for (int i = 0; i < A.Count; i++)
                {
                    for (int j = c; j < A.Count; j++)
                    {
                        A[i].Add(0);
                    }
                }

            }
            else if (c > r)
            {
                for (int i = r; i < A[0].Count; i++)
                {
                    var row = new List<int>();
                    for (int j = 0; j < A[0].Count; j++)
                    {
                        row.Add(0);
                    }
                    A.Add(row);
                }
            }

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A[i].Count; j++)
                {
                    int temp = A[i][j];
                    A[i][j] = A[j][i];
                    A[j][i] = temp;
                }
            }

            if (r > c)
            {
                A.RemoveRange(A.Count - (r - c), r - c);
            }
            else if (c > r)
            {
                for (int i = 0; i < A.Count; i++)
                {
                    A[i].RemoveRange(A[i].Count - (c - r), c - r);
                }
            }
            return A;
        }

        public void Rotate(List<List<int>> A)
        {
            //Transpose matrix
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    var temp = A[i][j];
                    A[i][j] = A[j][i];
                    A[j][i] = temp;
                }
            }
            //reverse
            for (int i = 0; i < A.Count; i++)
            {
                int s = 0, e = A[i].Count - 1;
                while (s <= e)
                {
                    int temp = A[i][s];
                    A[i][s] = A[i][e];
                    A[i][e] = temp;
                    s++; e--;
                }
            }
        }


        public int KSymbol(int A, int B)
        {
            List<int> result = new List<int>();
            string s = "0";
            for (int i = 1; i < A; i++)
            {
                string temp = s;
                s = temp.Replace("0", "01") + temp.Replace("1", "10");
            }
            return s[B];
        }


        public string StringOperations(string A)
        {
            string result = A + A;
            Regex regex = new Regex("[^a-z]");
            result = regex.Replace(result, "");
            result = result.Replace('a', '#').Replace('e', '#').Replace('i', '#').Replace('o', '#').Replace('u', '#');
            return result;
        }

        public string LongestPalindrome(string A)
        {
            string result = "";
            for (int i = 0; i < A.Length; i++)
            {
                var oddLength = extend(i, i, A);
                if (oddLength.Length > result.Length)
                {
                    result = oddLength;
                }
                var evenLength = extend(i, i + 1, A);
                if (evenLength.Length > result.Length)
                {
                    result = evenLength;
                }
            }
            return result;
        }
        public string extend(int left, int right, string A)
        {
            while (left >= 0 && right < A.Length)
            {
                if (A[left] != A[right])
                {
                    break;
                }
                left--;
                right++;
            }
            return A.Substring(left + 1, right - left - 1);
        }

        public int Isalnum(List<char> A)
        {
            //&& && 
            for (int i = 0; i < A.Count; i++)
            {
                if ((A[i] >= 'A' && A[i] <= 'Z') || (A[i] >= 'a' && A[i] <= 'z') || (A[i] >= '0' && A[i] <= '9'))
                {
                    continue;
                }
                else
                {
                    return 0;
                }
            }
            return 1;
        }

        public int AmazingSubarrays(string A)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != 'a' && A[i] != 'A' && A[i] != 'e' && A[i] != 'E' && A[i] != 'i' && A[i] != 'I' && A[i] != 'o' && A[i] != 'O' && A[i] != 'u' && A[i] != 'U')
                {
                    continue;
                }
                count = count + (A.Length - i);
            }
            return count % 10003;
        }

        public int SubArrayWith0Sum(List<int> A)
        {
            // Just write your code below to complete the function. Required input is available to you as the function arguments.
            // Do not print the result or any output. Just return the result via this function.
            for (int i = 0; i < A.Count; i++)
            {
                int sum = A[i];
                if (sum == 0)
                {
                    return 1;
                }
                for (int j = i + 1; j < A.Count; j++)
                {
                    sum += A[j];
                    if (sum == 0)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public string convertToTitle(int A)
        {
            List<char> titles = new List<char>();
            for (int i = 0; i < 26; i++)
            {
                if (titles.Count == 0)
                {
                    titles.Add('A');
                }
                else
                {
                    var newCh = Convert.ToInt32(titles[i - 1])+1;
                    titles.Add(Convert.ToChar(newCh));
                }
            }
            string est = "";
            while (A > 0)
            {
                int remainder = (A-1) % 26;
                est = titles[remainder] + est;
                A = (A - 1) / 26;
            }
            return est;
        }

        public int gcd(int A, int B)
        {
            if (B == 0)
            {
                return A;
            }
            return gcd(B, A % B);
        }

        public int DeleteOneGetmaxGCD(List<int> A)
        {
            List<int> pfGcd = new List<int>();
            List<int> sfGcd = new List<int>();
            pfGcd.Add(A[0]);
            for (int i = 1; i < A.Count; i++)
            {
                int gcdVal = gcd(A[i], pfGcd[i - 1]);
                pfGcd.Add(gcdVal);
            }
            sfGcd.Add(A[A.Count - 1]);
            for (int j = A.Count - 2, i=1 ; j >= 0; j--,i++)
            {
                int gcdVal = gcd(A[j], sfGcd[i-1]);
                sfGcd.Add(gcdVal);
            }
            sfGcd.Reverse();
            int maxGcd = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (i == 0)
                {
                    if (maxGcd < sfGcd[i + 1])
                    {
                        maxGcd = sfGcd[i + 1];
                       
                    }
                    continue;
                }
                if (i == A.Count - 1)
                {
                    if (maxGcd < pfGcd[i - 1])
                    {
                        maxGcd = pfGcd[i - 1];
                       
                    }
                    continue;
                }
                var lGcd = pfGcd[i - 1];
                var rGcd = sfGcd[i + 1];
                var common = gcd(lGcd, rGcd);
                if (common > maxGcd)
                {
                    maxGcd = common;
                }
            }
            return maxGcd;
        }

        public int TitleToNumber(string A)
        {
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result += Convert.ToInt32( Math.Pow(26, i) * (A[A.Length-1-i] - 'A'+1));
            }
            return result;
        }

        public void solve(int A)
        {
            printNum(A);
            Console.Write("\n");
        }
        public int printNum(int A)
        {
            if (A == 0)
            {
                return 1;
            }
            Console.Write(printNum(A - 1));
            Console.Write(" ");
            return A + 1;
        }

        public long subarraySum(List<int> A)
        {
            long sum = 0;
            for (int i = 0; i < A.Count; i++)
            {
                sum += A[i] * (i + 1) * (A.Count - i);
            }
            return sum;
        }


        public int MinimumSwaps(List<int> A, int B)
        {
            int i = 0, j = A.Count - 1;
            int count = 0;
            while (i <= j)
            {
                if (A[i] < B)
                {
                    i++;
                }
                if (A[j] > B)
                {
                    j--;
                }
                if (A[i] >= B && A[j] <= B)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                    i++; j--;
                    count++;
                }
            }
            return count;
        }

        public int MinSwap2(List<int> A, int B)
        {
            int count = 0;
            int totalMin = 0;
            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] <= B)
                {
                    totalMin++;
                }
            }
            int maxValues = 0;
            for (int i = 0; i < totalMin; i++)
            {
                if (A[i] > B)
                {
                    maxValues++;
                }
            }
            count = maxValues;
            int initial = 0;
            for (int i = totalMin; i < A.Count; i++)
            {
                if (A[initial] > B)
                {
                    maxValues--;
                }
                if (A[i] > B)
                {
                    maxValues++;
                }
                if (count > maxValues)
                {
                    count = maxValues;
                }
                initial++;
            }
            return count;
        }

        public int SubarrayWithLeastAverage(List<int> A, int B)
        {
            int index = 0;
            decimal sum = 0;
            for (int i = 0; i < B; i++)
            {
                sum += A[i];
            }
            decimal average =sum / B;
            int initial = 0;
            for (int j = B; j < A.Count; j++, initial++)
            {
                sum -= A[initial];
                sum += A[j];
                decimal avr = sum / B;
                if (average > avr)
                {
                    average = avr;
                    index = initial+1;
                }
            }
            return index;
        }


        public List<int> RangeDevisibiity(List<int> A, List<List<int>> B)
        {
            List<int> result = new List<int>();
            List<int> ps = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                int remainder = A[i] % 7;
                ps.Add(remainder);
            }

            for (int j = 0; j < B.Count; j++)
            {
                int count = 0;
                for (int k = B[j][0]; k <= B[j][1]; k++)
                {
                    if (ps[k] == 0)
                    {
                        count++;
                    }
                }
                result.Add(count);
            }
            return result;
        }


        public string AddBinary(string A, string B)
        {
            int carry = 0;
            int l1 = A.Length-1, l2 = B.Length-1;
            string ans  = string.Empty;
            while(l1>=0 || l2>=0|| carry > 0)
            {
                int sum = 0;
                if (l1 >= 0)
                {
                    sum += A[l1] - '0';
                    l1--;
                }
                if (l2 >= 0)
                {
                    sum += B[l2] - '0';
                    l2--;
                }
                sum += carry;
                int bit = sum % 2;
                carry = sum / 2;
                ans = (char)(bit + '0')+ ans;
            }
            return ans;
        }

    }
}
