using System;

namespace rover_direction
{
    public class Direction
    {
        private readonly char direction;

        public Direction(char direction)
        {
            this.direction = direction;
        }

        public Direction TurnRight()
        {
            switch (direction)
            {
                case 'N':
                    return new Direction('E');
                case 'S':
                    return new Direction('W');
                case 'E':
                    return new Direction('N');
                case 'W':
                    return new Direction('S');
                default:
                    throw new ArgumentException();
            }
        }

        public Direction TurnLeft()
        {
            switch (direction)
            {
                case 'N':
                    return new Direction('W');
                case 'S':
                    return new Direction('E');
                case 'E':
                    return new Direction('N');
                case 'W':
                    return new Direction('S');
                default:
                    throw new ArgumentException();
            }
        }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;

            var direction1 = (Direction) o;

            if (direction != direction1.direction) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return direction;
        }

        public override string ToString()
        {
            return "Direction{direction=" + direction + '}';
        }
    }
}