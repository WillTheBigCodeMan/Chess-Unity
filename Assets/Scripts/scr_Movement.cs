using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Movement : MonoBehaviour
{
    private scr_CreateBoard createBoard;
    private void Start() {
        createBoard = gameObject.GetComponent<scr_CreateBoard>();
    }
    
    public int[][] GetMoves(int[] board, bool isWhiteMove){
        int[][] moves = new int[0][2];
        for(int i = 0; i < board.length; i++){
            if(board[i] != 0&&(isWhiteMove&&board[i]>=8)||(!isWhiteMove&&board[i]<8)){
                moves.Concat(GetPieceMoves(board, i)).ToArray();
            }
        }
    }
    
    public int[][] GetPieceMoves(int[] board, int pieceIndex){
    
    }
}
