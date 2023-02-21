using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scr_Movement : MonoBehaviour
{
    private scr_CreateBoard createBoard;
    private void Start() {
        createBoard = gameObject.GetComponent<scr_CreateBoard>();
    }
    
    public int[ , ] GetMoves(int[] board, bool isWhiteMove){
        int[ , ] moves = new int[1, 2];
        for(int i = 0; i < board.Length; i++){
            if(board[i] != 0&&(isWhiteMove&&board[i]>=8)||(!isWhiteMove&&board[i]<8)){
                int [,] currentMoves = GetPieceMoves(board, i);
                int[,] combined = new int[moves.Length + currentMoves.Length,2];
                Array.Copy(moves, combined, moves.Length);
                Array.Copy(currentMoves, 0, combined, moves.Length, currentMoves.Length);
                moves = combined;
            }
        }
        return moves;
    }

    public int[ , ] GetPieceMoves(int[] board, int pieceIndex) {
        Debug.Log(new int[1, 2] { { pieceIndex, 0 } });
        int[,] outArray;
        if(board.Length == 0)
        {
            board = gameObject.GetComponent<scr_CreateBoard>().board;
        }
        switch (board[pieceIndex])
        {
            case 1:
                outArray = blackPawn(board, pieceIndex);
                break;
        }
        return new int[1,2]{ { pieceIndex, 0} };
    }

    private int[,] blackPawn(int[] board, int pieceIndex)
    {
        return null;
    }
}
