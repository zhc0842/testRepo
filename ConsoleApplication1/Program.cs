using System;

using BHahaPrjNative;

using Untitled1Native;

using Untitled1;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace ConsoleApplication1
{
    class Program
    {
        /*
         * C#只能调用matlab编写的function，不能直接操作matlab的class
         * 但是可以在matlab的function中编写操作matlab class的代码，间接达到C#调用matlab class的效果
         */
        static void Main(string[] args)
        {
            test1();
            test2();
            test3();
        }

        /*MyFunc.m
         * 
         function ret = MyFunc( x, y )
            ret = power(x, y);
         end
         * 
         */
        private static void test1()
        {
            //using Untitled1Native.dll
            Console.WriteLine("using Untitled1Native.dll !");

            Untitled1Native.Class1 class1 = new Untitled1Native.Class1();
            Double[] x = new Double[] { 2, 3, 5 };
            Double[] y = new Double[] { 3, 4, 5 };

            Object ret1 = class1.MyFunc(x, y);
            Console.WriteLine("ret1.GetType():" + ret1.GetType());
            Double[,] ret1Arr = (Double[,])ret1;

            for (int i = 0; i < ret1Arr.GetLength(0); i++)
            {
                for (int j = 0; j < ret1Arr.GetLength(1); j++)
                {
                    Console.WriteLine(ret1Arr.GetValue(i, j) + " ");
                }
            }
        }
        /*
         * MyFunc.m
         */
        private static void test2()
        {
            //using Untitled1.dll 和 MWArray.dll 
            Console.WriteLine("using Untitled1.dll 和 MWArray.dll !");

            Double[] x = new Double[] { 2, 3, 5 };
            Double[] y = new Double[] { 1, 2, 3 };

            
            Untitled1.Class1 class1 = new Untitled1.Class1();
            MWArray ret1 = class1.MyFunc((MWNumericArray)x, (MWNumericArray)y);

            Console.WriteLine("ret1.ArrayType:" + ret1.ArrayType);
            Console.WriteLine("ret1:" + ret1);
            Console.WriteLine("ret1.Dimensions:" + ret1.Dimensions);

            Console.WriteLine("ret1.GetType():" + ret1.GetType());
            Console.WriteLine("ret1.ToArray():" + ret1.ToArray());
            ret1.Dispose();
        }

        /*
         * BHaha.m BHahaMyAdd.m BHahaSMyAdd.m
         */
        private static void test3()
        {
            Console.WriteLine("using BHahaPrjNative.dll !");
            BHahaPrjNative.Class1 class1 = new BHahaPrjNative.Class1();
            Object[] ret1 = class1.BHahaSMyAdd(1, 2, 3);
            Object ret2 = class1.BHahaMyAdd();

            Int32[,] ret1Arr = (Int32[,])ret1[0];
            Double[,] ret2Arr = (Double[,])(ret2);

            Console.WriteLine(ret1Arr.GetValue(0, 0));
            Console.WriteLine(ret2Arr.GetValue(0, 0));

        }

    }
}
