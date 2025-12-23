using System;

class SearchWithGoto
{
    static void Main()
    {
        /*
         * Uses goto to exit nested loops instantly
         */

        int[,] arr = { { 1, 2 }, { 3, 4 } };
        int key = 4;

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                if (arr[i, j] == key)
                    goto Found;

        Console.WriteLine("Not Found");
        return;

    Found:
        Console.WriteLine("Element Found using goto");
    }
}
