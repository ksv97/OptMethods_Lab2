using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMethods_Lab2
{
    class Program
    {
        const double err = 0.0001;
        static double a, b, c, d;
        static double alpha;
        enum DerivationParam { DERIVATE_BY_X, DERIVATE_BY_Y};
        static int countOfIterations;

        static void Main(string[] args)
        {
            char input;            
            do
            {
                Console.WriteLine("1 - Выполнить алгоритм,\n0 - Выход");
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1': EnterParameters(); break;
                    default: return;
                }
            } while (input != '0');
            
            //a = 4;
            //b = -1.1;
            //c = 0.16;
            //d = 0.14;
            //double x0 = 0;
            //double y0 = 0;
            //Console.WriteLine("Значение минимизированной функции: {0}", Minimize(x0, y0));
            //Console.WriteLine("Количество проделанных итераций: {0}", countOfIterations);
            //Console.ReadKey();
        }

        static void EnterParameters()
        {
            double x0;
            double y0;

            Console.Clear();
            Console.WriteLine("Введите параметр а: ");
            double.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Введите параметр b: ");
            double.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Введите параметр c: ");
            double.TryParse(Console.ReadLine(), out c);
            Console.WriteLine("Введите параметр d: ");
            double.TryParse(Console.ReadLine(), out d);
            Console.WriteLine("Введите начальное значение х: ");
            double.TryParse(Console.ReadLine(), out x0);
            Console.WriteLine("Введите начальное значение y: ");
            double.TryParse(Console.ReadLine(), out y0);
            Console.WriteLine("Введите начальное значение альфа: ");
            double.TryParse(Console.ReadLine(), out alpha);
            Console.WriteLine("Значение минимизированной функции: {0}", Minimize(x0, y0));
            Console.WriteLine("Количество проделанных итераций: {0}", countOfIterations);
            Console.ReadKey();
            Console.Clear();
        }

        // минимизация функции f(x,y) = ax + by + e^(cx*x + dy*y)   
        static double Minimize ( double x0 , double y0)
        {
            countOfIterations = 0;
            double xk = x0;
            double yk = y0;

            double prevFunc;

            do
            {                
                prevFunc = Function(xk, yk);
                double xNext = xk - alpha * Derivate(xk, yk, DerivationParam.DERIVATE_BY_X);
                double yNext = yk - alpha * Derivate(xk, yk, DerivationParam.DERIVATE_BY_Y);               

                if (Function(xNext, yNext) <= prevFunc)
                {
                    xk = xNext;
                    yk = yNext;
                }
                else alpha = alpha / 2;
                countOfIterations++;

            } while (Math.Abs(Derivate(xk, yk, DerivationParam.DERIVATE_BY_X)) >= err / 2 || Math.Abs(Derivate(xk, yk, DerivationParam.DERIVATE_BY_Y)) >= err / 2);

            return Function(xk, yk);
        }
        
        static double Derivate (double x, double y, DerivationParam param)
        {
            return (param == DerivationParam.DERIVATE_BY_X) ? (a + 2 * c * x * Math.Exp(c * x * x + d * y * y)) : (b + 2 * d * y * Math.Exp(c * x * x + d * y * y));
        }
        
        static double Function (double x, double y)
        {
            return a * x + b * y + Math.Exp(c * x * x + d * y * y);
        }

    }


}
