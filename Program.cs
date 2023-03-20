using System.Diagnostics;
using System.Numerics;

namespace app
{
    class Solution {         
        static void Main(string[] args)
        {
            //PollardsRho(2199023255867,3,1228035139812) 
            //PollardsRho(2305843009213699919,3,259893785866906004)
            //PollardsRho(1007149824486452497234736,3,2417851639229258349415043)
            PollardRho result = new PollardRho();
            int alpha = 3;
            BigInteger x = 1;
            BigInteger a = 0;
            BigInteger b = 0;
            BigInteger X = x;
            BigInteger A = a;
            BigInteger B = b; 

            string betaStr = "1007149824486452497234736";
            string NStr = "2417851639229258349415043";
            BigInteger beta = BigInteger.Parse(betaStr);
            BigInteger N = BigInteger.Parse(NStr);
            BigInteger n = N-1;                 

            var timer = new Stopwatch();
            timer.Start();
            for(BigInteger i = 0; i < n; i++){
                List<BigInteger> t1 = result.PollardRhoAlgorithm(x, a, b, n, N, alpha, beta);
                List<BigInteger> t2 = result.PollardRhoAlgorithm(X, A, B, n, N, alpha, beta);
                List<BigInteger> t3 = result.PollardRhoAlgorithm(t2[0], t2[1], t2[2], n, N, alpha, beta);
                x = t1[0]; a = t1[1]; b = t1[2];
                X = t3[0]; A = t3[1]; B = t3[2];
                if(x == X){
                    BigInteger NumA = a - A;
                    BigInteger DenB = B - b;
                    List<BigInteger> mulInvB = result.ModInverse(DenB, n);
                    result.verifyBeta(NumA, DenB, i, x, a, b, X, A, B, alpha, beta, N, n);
                    timer.Stop();
                    TimeSpan timeTaken = timer.Elapsed;
                    Console.WriteLine("Solution computed in {0}", timeTaken);
                    timer.Reset();
                    timer.Start();                    
                }
            }
        }
    }
}