using System;
namespace com.thoughtworks.refactoring{

public class Direction {
    private char direction;

    public Direction(char direction) {
        this.direction = direction;
    }

    public Direction turnRight() {
        switch (direction) {
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

    public Direction turnLeft() {
        switch (direction) {
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

    
    public override bool Equals(Object o) {
        if (this == o) return true;
			if (o == null || GetType() != o.GetType()) return false;

        Direction direction1 = (Direction) o;

        if (direction != direction1.direction) return false;

        return true;
    }

    
    public override int GetHashCode() {
        return (int) direction;
    }

    
    public override string ToString() {
        return "Direction{direction=" + direction + '}';
    }
}
}