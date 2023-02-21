using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scr_dragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 storePos;
    public scr_Movement movement;
    private void OnMouseDown() {
        storePos = transform.position;
        offset = transform.position - (Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void OnMouseDrag() {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void OnMouseUp() {
        int oldIndex = Int32.Parse(transform.parent.name);
        int newIndex = Mathf.FloorToInt((transform.localPosition.x + 4 + transform.parent.position.x) + (8 * (8 - (transform.localPosition.y + 4 + transform.parent.position.y))));
        if (transform.position.x >=-4.4&&transform.position.x <3.5f&&transform.position.y>-3.5&&transform.position.y <= 4.4){
            int[,] moves = movement.GetPieceMoves(new int[0], oldIndex);
            bool found = false;
            Debug.Log(moves.Length);
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                if (moves[i, 1] == newIndex)
                {
                    try
                    {
                        Destroy(GameObject.Find(newIndex.ToString()).transform.GetChild(0).gameObject);
                    } catch { }
                    transform.position = snap(transform.position);
                    transform.parent = GameObject.Find(newIndex.ToString()).transform;
                    found = true;
                }
            }
            if (!found)
            {
                transform.position = storePos;
            }
        } else {
            transform.position = storePos;
        }
    }
    public Vector2 snap(Vector2 input){
        return new Vector2(Mathf.Round(input.x), Mathf.Round(input.y));
    }
}
