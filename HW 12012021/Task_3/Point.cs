namespace HW_12012021.Task_3
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }
        
        public int Y
        {
            get => _y;
            set => _y = value;
        }
    }
}