using System;

namespace Algorithms.Sorts
{
    class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            char[] sArr = s.ToCharArray();
            char[] tArr = t.ToCharArray();

            if (SelectionSort(sArr) == SelectionSort(tArr))
                return true;

            return false;
        }

        private string InsertionSort(char[] charArr)
        {
            for (int i = 1; i < charArr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                    if (charArr[j] < charArr[j - 1])
                    {
                        char s = charArr[j];
                        charArr[j] = charArr[j - 1];
                        charArr[j - 1] = s;
                    }
            }

            return new string(charArr);
        }

        private string SelectionSort(char[] charArr)
        {
            for (int i = 0; i < charArr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < charArr.Length; j++)
                {
                    if (charArr[min] > charArr[j])
                        min = j;
                }

                char minChar = charArr[min];
                charArr[min] = charArr[i];
                charArr[i] = minChar;
            }

            return new string(charArr);
        }


        private string EfficientSort(char[] charArr)
        {
            Array.Sort(charArr);

            return new string(charArr);
        }
    }
}
