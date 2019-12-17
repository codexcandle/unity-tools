using UnityEngine;
using codebycandle.util.algo;

public class TestAlgo:MonoBehaviour
{
    private int[] dataSorted = {1, 2, 5, 77};
    private int[] dataUnsorted = {99, 7, 6, 33};

	void Start()
    {
        RunTests();
	}

    private void RunTests()
    {
        // algo
        // RunFibonacciTests();
        RunSearchTests(dataSorted);
        // RunShuffleTests(dataSorted);
        // RunSortTests(dataUnsorted);
    }

    private void RunFibonacciTests()
    {
        // ******************* value
        // header
        string s = GetDebugTestHeader("fibonacci (value)") + "\n";

        // question
        int val = 8;
        s += "Q:\n";
        s += "what is the [" + val + "]th value in the Fibonacci series?\n";

        // answer
        s += "\nA:\n";
        // ... method #1
        s += "METHOD: " + "GetValueIterative" + "\n";
        s += "RESULT: " + Fibonacci.GetValueIterative(val);
        s += "\n\n";
        // ... method #2
        s += "METHOD: " + "DoBinarySearchRecursive" + "\n";
        s += "RESULT: " + Fibonacci.GetValueRecursive(val - 1);
        s += "\n";

        // display
        Debug.Log(s);

        // ******************* series
        // header
        s = GetDebugTestHeader("fibonacci (series)") + "\n";

        // question
        s += "Q:\n";
        s += "what are the first [" + val + "] values in the Fibonacci series?\n";

        // answer
        s += "\nA:\n";
        // ... method #1
        s += "METHOD: " + "GetSeriesIterative" + "\n";
        s += "RESULT: " + GetListString(Fibonacci.GetSeriesIterative(val));
        s += "\n\n";
        // ... method #2
        s += "METHOD: " + "PrintSeriesRecursive" + "\n";
        s += "RESULT: [TODO: GET THIS WORKING!]";

        // TODO - get this working!
        // Fibonacci.PrintSeriesRecursive(val);

        // display
        Debug.Log(s);
    }

    private void RunSearchTests(int[] data)
    {
        // header
        string s = GetDebugTestHeader("search") + "\n";

        // question
        int val = 5;
        s += "Q:\n";
        s += "what pos-index does [" + val + "] appear in the following set?\n";
        s += GetListString(data);

        // answer
        s += "\nA:\n";
        // ... method #1
        s += "METHOD: " + "DoBinarySearchIterative" + "\n";
        s += "RESULT: " + Search.BinarySearchIterative(data, val);
        s += "\n\n";
        // ... method #2
        s += "METHOD: " + "DoBinarySearchRecursive" + "\n";
        s += "RESULT: " + Search.BinarySearchRecursive(dataSorted, val, 0, data.Length - 1);
        s += "\n\n";
        // ... method #3
        s += "METHOD: " + "SearchForDupes" + "\n";
        s += "RESULT: " + Search.SearchForDupes(dataUnsorted);
        s += "\n";

        // display
        Debug.Log(s);
    }

    private void RunShuffleTests(int[] data)
    {
        // header
        string s = GetDebugTestHeader("shuffle") + "\n";

        // question
        s += "Q:\n";
        s += "shuffle the following.... \n";
        s += GetListString(data);

        // answer
        s += "\nA:\n";
        // ... method #1
        s += "METHOD: " + "DoShuffle" + "\n";
        Shuffle.DoShuffle(data);
        s += "RESULT: " + GetListString(data);
        s += "\n";

        // display
        Debug.Log(s);
    }

    private void RunSortTests(int[] data)
    {
        // header
        string s = GetDebugTestHeader("sort") + "\n";
        int[] dataClone;

        // question
        s += "Q:\n";
        s += "sort the following.... \n";
        s += GetListString(data);

        // answer
        s += "\nA:\n";

        // ... method #1
        s += "METHOD: " + "DoBubbleSort" + "\n";
        dataClone = data.Clone() as int[];
        Sort.DoBubbleSort(dataClone);
        s += "RESULT: " + GetListString(dataClone) + "\n";

        // ... method #2
        s += "METHOD: " + "DoSelectionSort" + "\n";
        dataClone = data.Clone() as int[];
        Sort.DoSelectionSort(dataClone);
        s += "RESULT: " + GetListString(dataClone) + "\n";

        // ... method #3
        s += "METHOD: " + "DoInsertionSort" + "\n";
        dataClone = data.Clone() as int[];
        Sort.DoInsertionSort(dataClone);
        s += "RESULT: " + GetListString(dataClone) + "\n";

        // ... method #4
        s += "METHOD: " + "DoQuickSortRecursive" + "\n";
        dataClone = data.Clone() as int[];
        Sort.DoQuickSortRecursive(dataClone, 0, dataClone.Length - 1);
        s += "RESULT: " + GetListString(dataClone) + "\n";

        // ... method #5
        s += "METHOD: " + "DoMergeSortRecursive" + "\n";
        dataClone = data.Clone() as int[];
        Sort.DoMergeSortRecursive(dataClone, 0, dataClone.Length - 1);
        s += "RESULT: " + GetListString(dataClone) + "\n";

        // display
        Debug.Log(s);
    }

    private string GetDebugTestHeader(string testName)
    {
        return "<color=#0000ff>*** " + testName.ToUpper() + " ******************************</color>";
    }

    private string GetListString(int[] data)
    {
        string s = string.Empty;

        int count = data.Length;
        for (int i = 0; i < count; i++)
        {
            s += data[i].ToString();

            if (i < (count - 1))
            {
                s += ", ";
            }
            else
            {
                s += "\n";
            }
        }

        return s;
    }
}
