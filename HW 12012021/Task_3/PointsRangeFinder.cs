using System;

namespace HW_12012021.Task_3
{
    public class PointsRangeFinder
    {
        private Point _firstPoint;
        private Point _secondPoint;

        public PointsRangeFinder(Point firstPoint, Point secondPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
        }

        public void ShowPointsRange()
        {
            var pointsRange = GetPointsRange();
            Console.WriteLine($"Расстояние между точками [{_firstPoint.X},{_firstPoint.Y}] и " +
                              $"[{_secondPoint.X},{_secondPoint.Y}]: {pointsRange:F}");
        }

        private double GetPointsRange()
        {
            return Math.Sqrt(Math.Pow(_secondPoint.X - _firstPoint.X, 2) + Math.Pow(_secondPoint.Y - _firstPoint.Y, 2));
        }
    }
}