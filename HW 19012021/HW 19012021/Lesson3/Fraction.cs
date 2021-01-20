using System;

namespace Lesson3
{
    public class Fraction
    {
        public Fraction(int inputNumerator, int inputDenominator)
        {
            Numerator = inputNumerator;
            Denominator = inputDenominator;
        }
        
        public int Numerator { get; }
        
        private int _denominator;
        public int Denominator
        {
            get => _denominator;
            private set => _denominator = CheckDenominator(value);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            var greatestCommonFactor = 1;
            var newNumerator = 0;
            if (AreEqualDenominators(a, b))
            {
                newNumerator = a.Numerator + b.Numerator;
                greatestCommonFactor = GetGreatestCommonFactor(newNumerator, a.Denominator);
                return new Fraction(
                    newNumerator/greatestCommonFactor, 
                    a.Denominator/greatestCommonFactor);
            }
            
            var lowestCommonDenominator = GetLowestCommonDenominator(a, b);
            var numeratorA = lowestCommonDenominator / a.Denominator * a.Numerator;
            var numeratorB = lowestCommonDenominator / b.Denominator * b.Numerator;

            newNumerator = numeratorA + numeratorB;
            greatestCommonFactor = GetGreatestCommonFactor(newNumerator, lowestCommonDenominator);
            return new Fraction(
                newNumerator/greatestCommonFactor, 
                lowestCommonDenominator/greatestCommonFactor);
        }
        
        public static Fraction operator -(Fraction a, Fraction b)
        {
            var greatestCommonFactor = 1;
            var newNumerator = 0;
            if (AreEqualDenominators(a, b))
            {
                newNumerator = a.Numerator - b.Numerator;
                greatestCommonFactor = GetGreatestCommonFactor(newNumerator, a.Denominator);
                return new Fraction(
                    newNumerator/greatestCommonFactor, 
                    a.Denominator/greatestCommonFactor);
            }
            
            var lowestCommonDenominator = GetLowestCommonDenominator(a, b);
            var numeratorA = lowestCommonDenominator / a.Denominator * a.Numerator;
            var numeratorB = lowestCommonDenominator / b.Denominator * b.Numerator;
            newNumerator = numeratorA - numeratorB;

            greatestCommonFactor = GetGreatestCommonFactor(newNumerator, lowestCommonDenominator);
            return new Fraction(
                newNumerator/greatestCommonFactor, 
                lowestCommonDenominator/greatestCommonFactor);
        }
        
        public static Fraction operator *(Fraction a, Fraction b)
        {
            var newNumerator = a.Numerator * b.Numerator;
            var newDenominator = a.Denominator * b.Denominator;
            var greatestCommonFactor = GetGreatestCommonFactor(newNumerator, newDenominator);
            return new Fraction(
                newNumerator/greatestCommonFactor, 
                newDenominator / greatestCommonFactor);
        }
        
        public static Fraction operator /(Fraction a, Fraction b)
        {
            var newNumerator = a.Numerator * b.Denominator;
            var newDenominator = a.Denominator * b.Numerator;
            var greatestCommonFactor = GetGreatestCommonFactor(newNumerator, newDenominator);
            return new Fraction(
                newNumerator / greatestCommonFactor, 
                newDenominator / greatestCommonFactor);
        }

        public override string ToString()
        {
            return $"({Numerator}/{Denominator})";
        }

        private static int GetLowestCommonDenominator(Fraction a, Fraction b)
        {
            var highestDenominator = a.Denominator > b.Denominator ? a.Denominator : b.Denominator;
            var lowestDenominator= a.Denominator < b.Denominator ? a.Denominator : b.Denominator;
            var improveHighestDenominator = highestDenominator;

            for (var i = 2; i < int.MaxValue; i++)
            {
                if (improveHighestDenominator % lowestDenominator == 0)
                    return improveHighestDenominator;
                improveHighestDenominator = highestDenominator * i;
            }
            
            throw new ArgumentException("Наименьший общий знаменатель не найден");
        }

        private static bool AreEqualDenominators(Fraction a, Fraction b)
        {
            return a.Denominator.Equals(b.Denominator);
        }

        private static int CheckDenominator(int value)
        {
            if (value == 0)
                throw new ArgumentException("Знаменатель не может быть равен 0");
            return value;
        }

        private static int GetGreatestCommonFactor(int numerator, int denominator)
        {
            var greatestCommonFactor = 1;
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            if (numerator == 0)
                return denominator;
            if (denominator == 0)
                return numerator;
            if (numerator == denominator)
                return numerator;
            if (numerator == 1 || denominator == 1)
                return greatestCommonFactor;

            while (numerator != 0 && denominator != 0)
            {
                if (numerator % 2 == 0 && denominator % 2 == 0)
                {
                    greatestCommonFactor *= 2;
                    numerator /= 2;
                    denominator /= 2;
                    continue;
                }

                if (numerator % 2 == 0 && denominator % 2 != 0)
                {
                    numerator /= 2;
                    continue;
                }

                if (numerator % 2 != 0 && denominator % 2 == 0)
                {
                    denominator /= 2;
                    continue;
                }

                var tmp = 0;
                if (numerator > denominator)
                {
                    tmp = numerator;
                    numerator = denominator;
                    denominator = tmp;
                }

                tmp = numerator;
                numerator = (denominator - numerator) / 2;
                denominator = tmp;
            }

            return numerator == 0 ? greatestCommonFactor * denominator : greatestCommonFactor * numerator;
        }
    }
}