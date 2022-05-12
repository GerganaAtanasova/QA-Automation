namespace Summator
{
    public static class Summator
    {
        public static int Sum(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }

            return result;
        }

    }
}