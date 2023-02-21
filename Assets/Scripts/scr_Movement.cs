using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Movement : MonoBehaviour
{
    private scr_CreateBoard createBoard;
    private void Start() {
        createBoard = gameObject.GetComponent<scr_CreateBoard>();
    }
}
