using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(transform.position.x >=-4&&transform.position.x <3.5f&&transform.position.y>-3.5&&transform.position.y <= 4){
            transform.position = snap(transform.position);
            transform.parent = GameObject.Find(((transform.localPosition.x + 4 + transform.parent.position.x) + (8* (8-(transform.localPosition.y + 4+ transform.parent.position.y)))).ToString()).transform;
        } else {
            transform.position = storePos;
        }
    }
    public Vector2 snap(Vector2 input){
        return new Vector2(Mathf.Round(input.x), Mathf.Round(input.y));
    }
}
