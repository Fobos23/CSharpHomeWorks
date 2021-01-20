using System;

namespace Lesson3
{
    public struct Complex
    {
        public int Re { get; }
        public int Im { get; }

        public Complex(int re, int im)
        {
            Im = im;
            Re = re;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(
                a.Im + b.Im, 
                a.Re + b.Re);
        }
        
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(
                a.Im - b.Im, 
                a.Re - b.Re);
        }
        
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(
                a.Re * b.Re - a.Im * b.Im,
                a.Re * b.Im + a.Im * b.Re);
        }
        
        public static Complex operator /(Complex a, Complex b)
        {
            var denominator = Math.Pow(b.Re, 2) + Math.Pow(b.Im, 2);
            if (denominator == 0)
                throw new DivideByZeroException();
            return new Complex(
                (int)((a.Re * b.Re + a.Im * b.Im)/denominator),
                (int)((a.Im * b.Re - a.Re * b.Im)/denominator));
        }

        public override string ToString()
        {
            var sign = Im > 0 ? "+" : "-";
            return $"({Re} {sign} {Math.Abs(Im)}i)";
        }
    }
}