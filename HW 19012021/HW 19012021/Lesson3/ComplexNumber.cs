using System;

namespace Lesson3
{
    public class ComplexNumber
    {
        public int Im { get; }
        public int Re { get; }

        public ComplexNumber(int re, int im)
        {
            Im = im;
            Re = re;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(
                a.Im + b.Im, 
                a.Re + b.Re);
        }
        
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(
                a.Im - b.Im, 
                a.Re - b.Re);
        }
        
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(
                a.Re * b.Re - a.Im * b.Im,
                a.Re * b.Im + a.Im * b.Re);
        }
        
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            var denominator = Math.Pow(b.Re, 2) + Math.Pow(b.Im, 2);
            if (denominator == 0)
                throw new DivideByZeroException();
            return new ComplexNumber(
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