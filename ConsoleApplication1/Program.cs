using System;

using Untitled1Native;

using Untitled1;

using BHahaPrjNative;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            test2();
        }

        private static void test2()
        {
            BHahaPrjNative.Class1 class1 = new BHahaPrjNative.Class1();
            Object[] ret1 = class1.BHahaSMyAdd(1, 2, 3);
            Object ret2 = class1.BHahaMyAdd();

            Int32[,] ret1Arr = (Int32[,])ret1[0];
            Double[,] ret2Arr = (Double[,])(ret2);

            Console.WriteLine(ret1Arr.GetValue(0, 0));
            Console.WriteLine(ret2Arr.GetValue(0, 0));


            Console.ReadKey();

        }

        private static void test1()
        {
            Console.WriteLine("test1() for c# to invoke matlab !");

            Double[] x = new Double[] { 2, 3, 5 };
            Double[] y = new Double[] { 1, 2, 3 };

            //using Untitled1.dll
            Console.WriteLine("using Untitled1.dll !");
            Untitled1.Class1 class1 = new Untitled1.Class1();
            MWArray ret1 = class1.MyFunc((MWNumericArray)x, (MWNumericArray)y);

            Console.WriteLine("ret1.ArrayType:" + ret1.ArrayType);
            Console.WriteLine("ret1:" + ret1);
            Console.WriteLine("ret1.Dimensions:" + ret1.Dimensions);

            Console.WriteLine("ret1.GetType():" + ret1.GetType());
            Console.WriteLine("ret1.ToArray():" + ret1.ToArray());
            ret1.Dispose();

            //using Untitled1Native.dll
            Console.WriteLine("\n" + "using Untitled1Native.dll !");
            Untitled1Native.Class1 class2 = new Untitled1Native.Class1();
            object ret2 = class2.MyFunc(x, y);

            Console.WriteLine("ret2.GetType():" + ret2.GetType());
            Console.WriteLine("ret2:" + ret2);
            Double[,] ret2Arr = (Double[,])ret2;
            Console.WriteLine("ret2Arr:" + ret2Arr[0, 1]);
            
            Console.ReadKey();
        }
    }
}
