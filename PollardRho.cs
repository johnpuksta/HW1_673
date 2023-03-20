using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace app
{
    public class PollardRho
    {
        static class Globals
        {
        public static BigInteger xt, at, bt;
        public static BigInteger x_euc = 0;
        public static BigInteger y_euc = 1;      

        }
        public List<BigInteger> PollardRhoAlgorithm(BigInteger x, BigInteger a, BigInteger b, BigInteger n, BigInteger N, int alpha, BigInteger beta){
            List<BigInteger> ret = new List<BigInteger>();
            BigInteger switchNum = x % 3;
            if(switchNum == 0){
                Globals.xt = x * x % N;
                Globals.at = a*2  % n;
                Globals.bt = b*2  % n;
            }
            else if(switchNum == 1){
                Globals.xt = x * alpha % N;
                Globals.at = (a+1) % n;
                Globals.bt = b;   
            }
            else{
                Globals.xt = x * beta % N;
                Globals.at = a;
                Globals.bt = (b+1) % n;               
            }
            /*
            switch(x % 3){
                case 0:
                    Globals.xt = x * x % N;
                    Globals.at =  a*2  % n;
                    Globals.bt =  b*2  % n;
                    break;
                case 1:
                    Globals.xt = x * alpha % N;
                    Globals.at = (a+1) % n;
                    Globals.bt = b;    
                    break;
                case 2:
                    Globals.xt = x * beta % N;
                    Globals.at = a;
                    Globals.bt = (b+1) % n;
                    break;
            } */
            ret.Add(Globals.xt);           
            ret.Add(Globals.at);
            ret.Add(Globals.bt);
            return ret;
        }
        private BigInteger gcdExtended(BigInteger aGcd, BigInteger bGcd){
            if(aGcd == 0){
                Globals.x_euc = 0;
                Globals.y_euc = 1;
                return bGcd;
            }
            BigInteger gcd = gcdExtended(bGcd % aGcd, aGcd);
            BigInteger x1 = Globals.x_euc;
            BigInteger y1 = Globals.y_euc;

            Globals.x_euc = y1 - (bGcd/aGcd) * x1;
            Globals.y_euc = x1;

            return gcd;  
        }
        public List<BigInteger> ModInverse(BigInteger At, BigInteger Mt){
            List<BigInteger> resList = new List<BigInteger>();
            if(At < 0){
            At =At % Mt;
            }
            BigInteger g = BigInteger.Abs(gcdExtended(At,Mt));
            resList.Add(((Globals.x_euc) % (Mt/g) + (Mt/g)) % (Mt/g));            
            resList.Add(g);
            return resList;
        }

        public void verifyBeta(BigInteger Num, BigInteger Den, BigInteger i, BigInteger x, BigInteger a, BigInteger b, BigInteger X, BigInteger A, BigInteger B, int alpha, BigInteger beta, BigInteger N, BigInteger n){
            if(Den < 0){
                Den = Den + n;
            }
            List<BigInteger> DenInv = ModInverse(Den, n);
            if(Num < 0){
                Num = Num + n;
            }
            BigInteger Gamma = Num * DenInv[0] % (N-1)/DenInv[1];
            BigInteger val = BigInteger.ModPow(alpha, Gamma, N);
            if(val == beta){
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",i, x, a, b, X, A, B);
                Console.WriteLine("Res:{0} B:{1} - Success", val, beta);
            }
            else{
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}",i, x, a, b, X, A, B);
                Console.WriteLine("Res:{0} B:{1} - Failure", val, beta);
            }
            Globals.x_euc = 0;
            Globals.y_euc = 1;
        }
    }
}

            
