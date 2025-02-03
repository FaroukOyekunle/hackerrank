namespace Problems.Solution
{
    public class LongestStrictlyIncreasingorStrictlyDecreasingSubarray
    {
        public int LongestMonotonicSubarray(int[] nums)
        {
            if (nums.Length == 1) 
            {
                return 1;
            }

            int maxLength = 1;
            int increaseLength = 1, decreaseLength = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    increaseLength++;
                    decreaseLength = 1; 
                }
                else if (nums[i] < nums[i - 1])
                {
                    decreaseLength++;
                    increaseLength = 1; 
                }
                else
                {
                    increaseLength = 1;
                    decreaseLength = 1;
                }

                maxLength = Math.Max(maxLength, Math.Max(increaseLength, decreaseLength));
            }

            return maxLength;
        }
    }
}