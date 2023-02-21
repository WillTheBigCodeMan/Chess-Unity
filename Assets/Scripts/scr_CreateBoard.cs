using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class scr_CreateBoard : MonoBehaviour
{
    public GameObject lightSquare;
    public GameObject darkSquare;

    private static string initialBoardState = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w - - 0 1";

    public Sprite[] sprites = new Sprite[15];

    public int[] board = new int[64];
    void Start()
    {
        for(int i = 8; i >= 1; i--){
            for(int j = 0; j < 8; j++){
                GameObject _ = Instantiate(((i+j)%2 == 1) ? lightSquare : darkSquare, new Vector3(j - 4,i - 4,0), Quaternion.identity);
                _.transform.parent = gameObject.transform;
                _.GetComponent<SpriteRenderer>().enabled = true;
                _.name = (j + ((8-i)*8)).ToString();
            }
        }
        generateBoardFromFEN(initialBoardState);
        Debug.Log(board);
        generatePieces(board);
    }

    public void generateBoardFromFEN(string FEN){
        int square = 0;
        char[] splitFEN = FEN.ToCharArray();
        foreach (char c in splitFEN) {
            if(c == ' '){
                break;
            }
            if(c != '/'){
                try {
                    square += Int32.Parse(c.ToString());
                }
                catch {
                    switch(c.ToString().ToLower()){
                        case "p":
                            board[square] = 1 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                        case "n":
                            board[square] = 2 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                        case "b":
                            board[square] = 3 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                        case "r":
                            board[square] = 4 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                        case "q":
                            board[square] = 5 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                        case "k":
                            board[square] = 6 + (8 * (Char.IsUpper(c) ? 1 : 0));
                            break;
                    }
                    square++;
                }
            }
        }
    }
    public void generatePieces(int[] board){
        for(int i = 0; i < board.Length; i++){
            if(board[i] > 0){
                GameObject newPiece = new GameObject();
                newPiece.AddComponent<SpriteRenderer>();
                if(board[i] / 8f >=1f){
                    newPiece.AddComponent<scr_dragAndDrop>();
                    newPiece.AddComponent<BoxCollider2D>();
                    newPiece.GetComponent<BoxCollider2D>().size = new Vector2(3,3);
                }
                newPiece.transform.parent = GameObject.Find(i.ToString()).transform;
                newPiece.name = "Piece";
                newPiece.GetComponent<SpriteRenderer>().sprite = sprites[board[i]];
                newPiece.GetComponent<SpriteRenderer>().sortingOrder = 1;
                newPiece.transform.localPosition = new Vector2(0,0);
                newPiece.transform.localScale = new Vector3(0.3f,0.3f,1);
                newPiece.tag = "Piece";
                newPiece.GetComponent<scr_dragAndDrop>().movement = gameObject.getComponent<scr_Movement>();
            }
        }
    }
}
