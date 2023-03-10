using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    public int currentSelectCubeNumber;
    public moveBlock mb1, mb2;

    void Update() {

        if (Input.GetKeyDown(KeyCode.Q)) { currentSelectCubeNumber = 1; mb1.ShowMyName(true); mb2.ShowMyName(false); }
        if (Input.GetKeyDown(KeyCode.W)) { currentSelectCubeNumber = 2; mb1.ShowMyName(false); mb2.ShowMyName(true); }

        if (currentSelectCubeNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { mb1.BlockMoveActive(5); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { mb1.BlockMoveActive(6); }
            if (Input.GetKeyDown(KeyCode.UpArrow)) { mb1.BlockMoveActive(3); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { mb1.BlockMoveActive(4); }
            if (Input.GetKeyDown(KeyCode.A)) { mb1.BlockMoveActive(1); }
            if (Input.GetKeyDown(KeyCode.Z)) { mb1.BlockMoveActive(2); }
        }
        else if (currentSelectCubeNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { mb2.BlockMoveActive(5); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { mb2.BlockMoveActive(6); }
            if (Input.GetKeyDown(KeyCode.UpArrow)) { mb2.BlockMoveActive(3); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { mb2.BlockMoveActive(4); }
            if (Input.GetKeyDown(KeyCode.A)) { mb2.BlockMoveActive(1); }
            if (Input.GetKeyDown(KeyCode.Z)) { mb2.BlockMoveActive(2); }
        }
    }

}