// SOURCE:  ?
// PURPOSE: "sorting" algorithms
namespace codebycandle.util.algo
{
    static public class Sort
    {
        #region bubble-sort
        static public void DoBubbleSort(int[] data)
        {
            bool flag = true;
            int temp;
            int length = data.Length;

            // sort array
            for(int i = 1; i <= (length - 1); i++)
            {
                flag = false;
                for (int j = 0; j < (length - 1) ; j++)
                {
                    if(data[j + 1] < data[j])
                    {
                        temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;

                        flag = true;
                    }
                }

                // if => no further sorting needed, exit
                if (flag == false) return;
            }
        }
        #endregion

        #region selection-sort
        static public void DoSelectionSort(int[] data)
        {
            int posMin;         // position of minimum
            int temp;
            int length = data.Length;
            int finalIndex = length - 1;

            for(int i = 0; i < finalIndex; i++)
            {
                // set to current array index
                posMin = i;

                for(int j = i + 1; j < length; j++)
                {
                    if(data[j] < data[posMin])
                    {
                        // keep track of index that min is in; needed when swap occurs
                        posMin = j;
                    }
                }

                /*
                 * if pos-min no longer equals i, 
                 * then smaller value must have been found; 
                 * so swap must occur!
                 */
                if(posMin != i)
                {
                    temp = data[i];
                    data[i] = data[posMin];
                    data[posMin] = temp;
                }
            }
        }
        #endregion

        #region insertion-sort
        static public void DoInsertionSort(int[] data)
        {
            int temp, j;
            int length = data.Length;

            for(int i = 1; i < length; i++)
            {
                temp = data[i];
                j = i - 1;

                while (j >= 0 && data[j] > temp)
                {
                    data[j + 1] = data[j];

                    j--;
                }

                data[j + 1] = temp;
            }
        }
        #endregion

        #region quick-sort
        static public void DoQuickSortRecursive(/*IComparable*/int[] data, int left, int right)
        {
            int i = left, j = right;
            /*IComparable*/ int pivot = data[(left + right) / 2];

            while(i <= j)
            {
                while(data[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while(data[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if(i <= j)
                {
                    // swap
                    /*IComparable*/ int tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;

                    i++;
                    j--;
                }
            }

            // recursive calls
            if(left < j)
            {
                DoQuickSortRecursive(data, left, j);
            }

            if(i < right)
            {
                DoQuickSortRecursive(data, i, right);
            }
        }
        #endregion

        #region merge-sort
        static public void DoMergeSortRecursive(int[] data, int left, int right)
        {
            int mid;

            if(right > left)
            {
                mid = (right + left) / 2;
                DoMergeSortRecursive(data, left, mid);
                DoMergeSortRecursive(data, (mid + 1), right);

                DoMerge(data, left, (mid + 1), right);
            }
        }

        static private void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, leftEnd, elementCount, tmpPos;

            leftEnd = (mid - 1);
            tmpPos = left;
            elementCount = (right - left + 1);

            while((left <= leftEnd) && (mid <= right))
            {
                if(numbers[left] <= numbers[mid])
                {
                    temp[tmpPos++] = numbers[left++];
                }
                else
                {
                    temp[tmpPos++] = numbers[mid++];
                }
            }

            while(left <= leftEnd)
            {
                temp[tmpPos++] = numbers[left++];
            }

            while(mid <= right)
            {
                temp[tmpPos++] = numbers[mid++];
            }

            for(i = 0; i < elementCount; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        #endregion
    }
}