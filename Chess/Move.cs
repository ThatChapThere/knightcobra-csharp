namespace Chess;

class Move{

    private static int King = 5;
    private static int Pawn = 0;

    private int _startSquare;
    private int _endSquare;
    private int _pieceCode;
    private int _promotionPieceCode = -1;
    private bool _castling;

    public Move(int startSquare, int endSquare, int pieceCode, int promotionPieceCode){
        _startSquare = startSquare;
        _endSquare = endSquare;
        _pieceCode = pieceCode;
        _promotionPieceCode = promotionPieceCode;
        _castling = pieceCode % 6 == King && Math.Abs(startSquare - endSquare) == 2;
    }

    public void makeMove(ulong[] bitboards, ref int enPassantFile, bool[] castlingRights, ref bool playerToMove){
        togglePiece(bitboards, _pieceCode, _startSquare); // move piece away from square
        if(_promotionPieceCode == -1){
            togglePiece(bitboards, _pieceCode, _endSquare); // normal move
        }else{
            togglePiece(bitboards, _promotionPieceCode, _endSquare); // promotion
        }

        if(_castling){

        }
        
    }

    public void togglePiece(ulong[] bitboards, int pieceCode, int square) => bitboards[pieceCode] ^= 1ul << square;

    public void clearSquare(ulong[] bitboards, int square, bool sideColour) {
        
    }
}