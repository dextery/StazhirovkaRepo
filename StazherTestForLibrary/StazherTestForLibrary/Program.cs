using StazherTest;

namespace Tester
{
    class Solution
    {
        private static void Main(string[] args)
        {
            Figure fig = new Figure();
            Figure fig1 = new Figure(30);
            Figure fig2 = new Figure(3,4,5);

            fig.FindArea();
            fig1.FindArea();
            fig2.FindArea();


            fig.PrintArea();
            fig2.PrintArea();
            fig1.PrintArea();
        }
    }
}