using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    //public int currentSelectCubeNumber;
    public moveCrane mc;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Q)) { mc.BlockRotateActive(1); }
        if (Input.GetKeyDown(KeyCode.W)) { mc.BlockRotateActive(3); }
        if (Input.GetKeyDown(KeyCode.E)) { mc.DetachAttachModule(); }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { mc.BlockMoveActive(5); }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { mc.BlockMoveActive(6); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { mc.BlockMoveActive(3); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { mc.BlockMoveActive(4); }
        if (Input.GetKeyDown(KeyCode.A)) { mc.BlockMoveActive(1); }
        if (Input.GetKeyDown(KeyCode.Z)) { mc.BlockMoveActive(2); }

    }

}