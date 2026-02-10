namespace power
{
    public class Test
    {
        public static int powerGame(int N, int[] A)
        {
            int? current = null;
            foreach(int strength in A)
            {
                if(current == null)
                {
                    current = strength;
                }
                else
                {
                    if(strength >= current)
                    {
                        current = null;
                    }else
                    {
                        current = current + strength;
                    }
                }
            }
            if(current == null)
            {
                Console.WriteLine("NO");
                return 0;
            }
            else
            {
                Console.WriteLine("YES " + current);
                return current.Value;
            }

        }
        public static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[] A = new int[N];

            string[] tokens = Console.ReadLine().Split();
            // int i;
            for(int i = 0; i<N; i++)
            {
                A[i] = Convert.ToInt32(tokens[i]);
                Console.WriteLine(powerGame(N,A));
            }
        }
    }
}