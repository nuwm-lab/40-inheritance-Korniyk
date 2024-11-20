using System;

namespace LabWork
{
    class Fraction
    {
        protected double a;

        public virtual void SetCoefficients(double a)
        {
            this.a = a;
        }

        public virtual void DisplayCoefficients()
        {
            Console.WriteLine($"Коефiцiєнт a: {a}");
        }

        public virtual double ComputeValue(double x)
        {
            if (a * x == 0)
                throw new DivideByZeroException("Знаменник не може дорiвнювати нулю.");
            return 1 / (a * x);
        }
    }
    class ThreeDimensionalFraction : Fraction
    {
        private double a2, a3;

        public void SetCoefficients(double a1, double a2, double a3)
        {
            base.SetCoefficients(a1);
            this.a2 = a2;
            if (a3 == 0)
                throw new ArgumentException("Коефiцiєнт a3 не може дорiвнювати нулю.");
            this.a3 = a3;
        }

        public override void DisplayCoefficients()
        {
            Console.WriteLine($"Коефiцiєнт a1: {a}, a2: {a2}, a3: {a3}");
        }

        public override double ComputeValue(double x)
        {
            if (x == 0)
                throw new DivideByZeroException("Знаменник не може дорiвнювати нулю.");

            double denominator3 = a3 * x;
            double denominator2 = a2 * x + 1 / denominator3;
            double denominator1 = a * x + 1 / denominator2;

            return 1 / denominator1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fraction fraction = new Fraction();
                fraction.SetCoefficients(2);
                fraction.DisplayCoefficients();
                Console.WriteLine($"Значення дробу у точцi x = 1: {fraction.ComputeValue(1)}");

                ThreeDimensionalFraction threeDimFraction = new ThreeDimensionalFraction();
                threeDimFraction.SetCoefficients(1, 2, 3);
                threeDimFraction.DisplayCoefficients();
                Console.WriteLine($"Значення тривимiрного дробу у точцi x = 1: {threeDimFraction.ComputeValue(1)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

}
