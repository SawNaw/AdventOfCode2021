namespace AdventOfCode.Day2.Algorithms
{
    public class Submarine
    {
        private Position _currentPosition;
        public Position CurrentPosition => _currentPosition;
        public int HorizontalPositionTimesDepth => _currentPosition.HorizontalPosition * _currentPosition.Depth;
        public int Aim { get; set; } = 0;

        public Submarine()
        {
            _currentPosition = new Position();
        }

        public void Forward(int displacment)
        {
            if (displacment < 1) throw new ArgumentException("Displacement cannot be less than 1.");

            _currentPosition.HorizontalPosition += displacment;
            _currentPosition.Depth += (Aim * displacment);
        }

        public void Down(int displacment)
        {
            if (displacment < 1) throw new ArgumentException("Displacement cannot be less than 1.");

            Aim += displacment;
        }

        public void Up(int displacment)
        {
            if (displacment < 1) throw new ArgumentException("Displacement cannot be less than 1.");

            Aim -= displacment;
        }
    }
}