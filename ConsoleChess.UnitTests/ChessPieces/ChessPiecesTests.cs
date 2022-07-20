﻿using System.Drawing;
using ConsoleChess.ChessPieces;

namespace ConsoleChess.UnitTests.ChessPieces;

public class BishopTests
{
    private static readonly ChessBoard Board = new();

    private static object[] _validateMoveCases =
    {
        #region bishop
        // 6, 2 to 1, 7
        new object?[] {new Bishop(Color.White), Board[6, 2], Board[1, 7], true, null},
        // 3, 3 to 4, 4
        new object?[] {new Bishop(Color.White), Board[3, 3], Board[4, 4], true, null},
        // 3, 3 to 6, 6
        new object?[] {new Bishop(Color.White), Board[3, 3], Board[6, 6], true, null},
        // 1, 1 to 0, 0
        new object?[] {new Bishop(Color.White), Board[1, 1], Board[0, 0], true, null},
        // 0, 5 to 3, 2 with obstacle in destination
        new object?[] {new Bishop(Color.White), Board[0, 5], Board[3, 2], false, Board[3, 2]},
        // 0, 5 to 3, 2 with obstacle in the way
        new object?[] {new Bishop(Color.White), Board[0, 5], Board[3, 2], false, Board[2, 3]},
        // 1, 3 to 6, 3
        new object?[] {new Bishop(Color.White), Board[1, 3], Board[6, 3], false, null},
        // 1, 3 to 6, 2
        new object?[] {new Bishop(Color.White), Board[1, 3], Board[6, 2], false, null},
        #endregion
        #region king
        // 4, 5 to 3, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 4], true, null},
        // 4, 5 to 4, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 4], true, null},
        // 4, 5 to 5, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 4], true, null},
        // 4, 5 to 5, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 5], true, null},
        // 4, 5 to 5, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 6], true, null},
        // 4, 5 to 4, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 6], true, null},
        // 4, 5 to 3, 6
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 6], true, null},
        // 4, 5 to 3, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[3, 5], true, null},
        // 4, 5 to 4, 4 with obstacle in destination
        new object?[] {new King(Color.White), Board[4, 5], Board[4, 4], false, Board[4, 4]},
        // 4, 5 to 5, 6 with non-colliding piece in 4, 4
        new object?[] {new King(Color.White), Board[4, 5], Board[5, 6], true, Board[4, 4]},
        // 4, 5 to 6, 5
        new object?[] {new King(Color.White), Board[4, 5], Board[6, 5], false, null},
        // 4, 5 to 6, 3
        new object?[] {new King(Color.White), Board[4, 5], Board[6, 3], false, null},
        #endregion
    };

    [TestCaseSource(nameof(_validateMoveCases))]
    public void ValidateMove(ChessPiece piece, Cell from, Cell to, bool expectedResult, Cell? obstacleCell = null)
    {
        for (var i = 0; i < 8; i++)
            for (var j = 0; j < 8; j++)
                Board[i, j].Piece = null;
        
        from.Piece = piece;

        if (obstacleCell is not null)
            obstacleCell.Piece = new Pawn(Color.White);

        Assert.That(from.Piece.ValidateMove(from, to, Board), Is.EqualTo(expectedResult));
    }
}