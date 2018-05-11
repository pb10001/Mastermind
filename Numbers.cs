using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Numbers
    {
        public Numbers(int[] nums)
        {
            this.nums = nums;
        }
        int[] nums;
        public Tuple<int, int> Check(int[] input)
        {
            var eat = 0;
            var bite = 0;
            var hash = new HashSet<int>();
            if (nums.Length != input.Length)
            {
                throw new ArgumentException("桁数が不正です");
            }
            foreach (var item in input)
            {
                if (!hash.Add(item)) throw new ArgumentException("同じ数字は使えません");
            }
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == input[i])
                {
                    eat++;
                }
                else
                {
                    foreach (var item in nums)
                    {
                        if (input[i] == item)
                        {
                            bite++;
                        }
                    }
                }
            }
            return new Tuple<int, int>(eat, bite);
        }
    }
}
