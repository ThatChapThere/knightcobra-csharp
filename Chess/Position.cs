namespace Chess;
using System.Collections.Generic;

class Position{
    public static int BlackQueenside = 0;
    public static int BlackKingside = 1;
    public static int WhiteQueenside = 2;
    public static int WhiteKingside = 3;
    public static int CannotEnPassant = 8;
    public static bool WhiteToMove = true;
    public static bool BlackToMove = false;

    private int _enPassantFile;
    private bool[] _castlingRights;
    private bool _playerToMove;
    private ulong[] _bitboards = new ulong[]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // for every piece type (a8 = 1, h8 = 2^7)
    private ulong[] _sideBitboards = new ulong[]{0, 0}; // for either side, removes the need for loops in many cases
    private const int _whiteSideBitboard = 0;
    private const int _blackSideBitboard = 1;
    private string _pieceTypes = "PRNBQKprnbqk";
    private List<Move> _legalMoves = new List<Move>();

    // position initialiser for when the starting position is created
    public Position(string boardString, int enPassantFile, bool[] castlingRights, bool playerToMove){
        setupBoardFromString(boardString);
        _enPassantFile = enPassantFile;
        _castlingRights = castlingRights;
        _playerToMove = playerToMove;
        setupSideBitboards();
    }

    // position intitialiser to be called within this class
    public Position(ulong[] bitboards, int enPassantFile, bool[] castlingRights, bool playerToMove){
        _bitboards = (ulong[]) bitboards.Clone();
        _enPassantFile = enPassantFile;
        _castlingRights = (bool[]) castlingRights.Clone();
        _playerToMove = playerToMove;
        setupSideBitboards();
    }

    public void printPosition() {
        char[] printString = new char[64];
        for(int i = 0; i < 64; i++) {
            if(((i % 16 - i % 8) - 8 * (i % 2)) == 0){
                printString[i] = '\u2588';
            }else{
                printString[i] = ' ';
            }
            for(int j = 0; j < 12; j++){
                if((_bitboards[j] >> i & 1) == 1ul){
                    printString[i] = _pieceTypes[j];
                }
            }
        }
        
        for(int i = 0; i < 8; i++){
            Console.WriteLine(new string(printString).Substring(i * 8, 8));
        }
    }

    // toggle whether or not a piece exists on a certain square
    public void togglePiece(int startSquare, int pieceCode) => _bitboards[pieceCode] ^= 1ul << startSquare;

    private void generateLegalMoves(){

    }

    private void setupSideBitboards(){
        for(int i = 0; i < 12; i++){
            if(i < 6){
                _sideBitboards[_whiteSideBitboard] |= _bitboards[i];
            }else{
                _sideBitboards[_blackSideBitboard] |= _bitboards[i];
            }
        }
    }

    private void setupBoardFromString(string boardString){
        char pieceCharacter;
        for(int i = 0; i < 64; i++) {
            pieceCharacter = boardString[i];
            if(pieceCharacter == ' ') continue;
            _bitboards[_pieceTypes.IndexOf(pieceCharacter)] |= 1ul << i;
        }
    }
}