namespace Sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];

            //入力
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "] = ");
                array[i] = int.Parse(Console.ReadLine());
            }

            //集計
            //int sum = 0;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum += array[i];
            //}


            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]:");
                astOut(array[i]);
            }

            Console.WriteLine("合計:" + array.Sum(n => n % 2));

        }
            //出力
            static void astOut(int num)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
    }
}