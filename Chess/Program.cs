namespace Chess;

internal class Program
{
    static string startingPositionString = "rnbqkbnrpppppppp                                PPPPPPPPRNBQKBNR";

    static void Main(string[] args)
    {
        var startingPosition = new Position(
            startingPositionString,
            Position.CannotEnPassant,
            new bool[] { true, true, true, true },
            Position.WhiteToMove);
        startingPosition.printPosition();
    }
}
