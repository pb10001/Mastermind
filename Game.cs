using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Game
    {
        public Game()
        {
        }
        Numbers n;
        int num;
        int count = 0;
        int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private bool Init()
        {
            Console.Write("桁数を入力してください(1-9): ");
            var input = Console.ReadLine();
            return int.TryParse(input, out num);
        }
        public void Play()
        {
            if (!Init()) return;
            Shuffle(digits);
            var arr = digits.Take(num).ToArray();
            n = new Numbers(arr);
            bool end = false;
            while (!end)
            {
                int[] array;
                Console.Write("予想: ");
                try
                {
                    var line = Console.ReadLine();
                    count++;
                    if (line.Equals("exit"))
                    {
                        return;
                    }
                    array = line.Select(x => int.Parse(x.ToString())).ToArray();
                }
                catch
                {
                    return;
                }
                try
                {
                    var result = n.Check(array);
                    Console.WriteLine("{0} eats, {1} bites", result.Item1, result.Item2);
                    if (result.Item1 == num)
                    {
                        end = true;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("クリア！ {0}回", count);
        }
        private void Shuffle(int[] digits)
        {
            Random r = new Random();
            for (int i = 9; i > 0; i--)
            {
                var index = r.Next(i);
                var tmp = digits[index];
                digits[index] = digits[i];
                digits[i] = tmp;
            }
        }
    }
}
