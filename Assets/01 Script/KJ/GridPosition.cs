using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridPosition : MonoBehaviour {

    public moveCrane mc;

    private void Start() {
        GetChild();
        GetAllPositionName();
        SetDefaultPosition();
        CombineDirection();
    }

    public GameObject gr1, gr2, gr3;
    private Transform[] y1, y2, y3; // private 으로
    private Transform   y1x1z1, y1x1z2, y1x1z3, y1x1z4, y1x1z5,
                        y1x2z1, y1x2z2, y1x2z3, y1x2z4, y1x2z5,
                        y1x3z1, y1x3z2, y1x3z3, y1x3z4, y1x3z5,
                        y1x4z1, y1x4z2, y1x4z3, y1x4z4, y1x4z5,
                        y1x5z1, y1x5z2, y1x5z3, y1x5z4, y1x5z5,

                        y2x1z1, y2x1z2, y2x1z3, y2x1z4, y2x1z5,
                        y2x2z1, y2x2z2, y2x2z3, y2x2z4, y2x2z5,
                        y2x3z1, y2x3z2, y2x3z3, y2x3z4, y2x3z5,
                        y2x4z1, y2x4z2, y2x4z3, y2x4z4, y2x4z5,
                        y2x5z1, y2x5z2, y2x5z3, y2x5z4, y2x5z5,

                        y3x1z1, y3x1z2, y3x1z3, y3x1z4, y3x1z5,
                        y3x2z1, y3x2z2, y3x2z3, y3x2z4, y3x2z5,
                        y3x3z1, y3x3z2, y3x3z3, y3x3z4, y3x3z5,
                        y3x4z1, y3x4z2, y3x4z3, y3x4z4, y3x4z5,
                        y3x5z1, y3x5z2, y3x5z3, y3x5z4, y3x5z5;


    void GetChild() {
        y1 = gr1.GetComponentsInChildren<Transform>();
        y2 = gr2.GetComponentsInChildren<Transform>();
        y3 = gr3.GetComponentsInChildren<Transform>();
    }

    void GetAllPositionName() {
		foreach (Transform tr1 in y1) {
			if (tr1.name == "x1z1") { y1x1z1 = tr1; }
            if (tr1.name == "x1z2") { y1x1z2 = tr1; }
            if (tr1.name == "x1z3") { y1x1z3 = tr1; }
            if (tr1.name == "x1z4") { y1x1z4 = tr1; }
            if (tr1.name == "x1z5") { y1x1z5 = tr1; }
            if (tr1.name == "x2z1") { y1x2z1 = tr1; }
            if (tr1.name == "x2z2") { y1x2z2 = tr1; }
            if (tr1.name == "x2z3") { y1x2z3 = tr1; }
            if (tr1.name == "x2z4") { y1x2z4 = tr1; }
            if (tr1.name == "x2z5") { y1x2z5 = tr1; }
            if (tr1.name == "x3z1") { y1x3z1 = tr1; }
            if (tr1.name == "x3z2") { y1x3z2 = tr1; }
            if (tr1.name == "x3z3") { y1x3z3 = tr1; }
            if (tr1.name == "x3z4") { y1x3z4 = tr1; }
            if (tr1.name == "x3z5") { y1x3z5 = tr1; }
            if (tr1.name == "x4z1") { y1x4z1 = tr1; }
            if (tr1.name == "x4z2") { y1x4z2 = tr1; }
            if (tr1.name == "x4z3") { y1x4z3 = tr1; }
            if (tr1.name == "x4z4") { y1x4z4 = tr1; }
            if (tr1.name == "x4z5") { y1x4z5 = tr1; }
            if (tr1.name == "x5z1") { y1x5z1 = tr1; }
            if (tr1.name == "x5z2") { y1x5z2 = tr1; }
            if (tr1.name == "x5z3") { y1x5z3 = tr1; }
            if (tr1.name == "x5z4") { y1x5z4 = tr1; }
            if (tr1.name == "x5z5") { y1x5z5 = tr1; }
        }
        foreach (Transform tr2 in y2) {
			if (tr2.name == "x1z1") { y2x1z1 = tr2; }
            if (tr2.name == "x1z2") { y2x1z2 = tr2; }
            if (tr2.name == "x1z3") { y2x1z3 = tr2; }
            if (tr2.name == "x1z4") { y2x1z4 = tr2; }
            if (tr2.name == "x1z5") { y2x1z5 = tr2; }
            if (tr2.name == "x2z1") { y2x2z1 = tr2; }
            if (tr2.name == "x2z2") { y2x2z2 = tr2; }
            if (tr2.name == "x2z3") { y2x2z3 = tr2; }
            if (tr2.name == "x2z4") { y2x2z4 = tr2; }
            if (tr2.name == "x2z5") { y2x2z5 = tr2; }
            if (tr2.name == "x3z1") { y2x3z1 = tr2; }
            if (tr2.name == "x3z2") { y2x3z2 = tr2; }
            if (tr2.name == "x3z3") { y2x3z3 = tr2; }
            if (tr2.name == "x3z4") { y2x3z4 = tr2; }
            if (tr2.name == "x3z5") { y2x3z5 = tr2; }
            if (tr2.name == "x4z1") { y2x4z1 = tr2; }
            if (tr2.name == "x4z2") { y2x4z2 = tr2; }
            if (tr2.name == "x4z3") { y2x4z3 = tr2; }
            if (tr2.name == "x4z4") { y2x4z4 = tr2; }
            if (tr2.name == "x4z5") { y2x4z5 = tr2; }
            if (tr2.name == "x5z1") { y2x5z1 = tr2; }
            if (tr2.name == "x5z2") { y2x5z2 = tr2; }
            if (tr2.name == "x5z3") { y2x5z3 = tr2; }
            if (tr2.name == "x5z4") { y2x5z4 = tr2; }
            if (tr2.name == "x5z5") { y2x5z5 = tr2; }
        }



    }

    //==================================
    public int currentPosX, currentPosY, currentPosZ;
    public Transform targetPos;

    // 7 : x,  8 : y,  9 : z  ( 예시 : 71 = x1, 95 = z5 )
    void SetDefaultPosition() {
        currentPosY = 2;
        currentPosX = 3;
        currentPosZ = 1;
    }

    public void GetDirection(int dir) { mc.PVoverlap = false;
        // 1 : Y+,  2 : Y-,  3 : X+,  4 : X-,  5 : Z+,  6 : Z-
        if (dir == 1) { currentPosY++; }
        else if (dir == 2) { currentPosY--; }
        else if (dir == 3) { currentPosX++; }
        else if (dir == 4) { currentPosX--; }
        else if (dir == 5) { currentPosZ++; }
        else if (dir == 6) { currentPosZ--; }
        else if (dir == -1) { SetDefaultPosition(); }

        if (currentPosY > 2) { currentPosY = 2; }
        else if (currentPosY < 1) { currentPosY = 1; }

        if (currentPosX > 5) { currentPosX = 5; }
        else if (currentPosX < 1) { currentPosX = 1; }

        if (currentPosZ > 5) { currentPosZ = 5; }
        else if (currentPosZ < 1) { currentPosZ = 1; }

        CombineDirection();
    }

    void CombineDirection() {
        if (currentPosY == 1) {
            if(currentPosX == 1 ) {
                     if (currentPosZ == 1) { targetPos = y1x1z1; }
                else if (currentPosZ == 2) { targetPos = y1x1z2; }
                else if (currentPosZ == 3) { targetPos = y1x1z3; }
                else if (currentPosZ == 4) { targetPos = y1x1z4; }
                else if (currentPosZ == 5) { targetPos = y1x1z5; }
            }
            else if(currentPosX == 2 ) {
                     if (currentPosZ == 1) { targetPos = y1x2z1; }
                else if (currentPosZ == 2) { targetPos = y1x2z2; }
                else if (currentPosZ == 3) { targetPos = y1x2z3; }
                else if (currentPosZ == 4) { targetPos = y1x2z4; }
                else if (currentPosZ == 5) { targetPos = y1x2z5; }
            }
            else if(currentPosX == 3 ) {
                     if (currentPosZ == 1) { targetPos = y1x3z1; }
                else if (currentPosZ == 2) { targetPos = y1x3z2; }
                else if (currentPosZ == 3) { targetPos = y1x3z3; }
                else if (currentPosZ == 4) { targetPos = y1x3z4; }
                else if (currentPosZ == 5) { targetPos = y1x3z5; }
            }
            else if(currentPosX == 4 ) {
                     if (currentPosZ == 1) { targetPos = y1x4z1; }
                else if (currentPosZ == 2) { targetPos = y1x4z2; }
                else if (currentPosZ == 3) { targetPos = y1x4z3; }
                else if (currentPosZ == 4) { targetPos = y1x4z4; }
                else if (currentPosZ == 5) { targetPos = y1x4z5; }
            }
            else if(currentPosX == 5 ) {
                     if (currentPosZ == 1) { targetPos = y1x5z1; }
                else if (currentPosZ == 2) { targetPos = y1x5z2; }
                else if (currentPosZ == 3) { targetPos = y1x5z3; }
                else if (currentPosZ == 4) { targetPos = y1x5z4; }
                else if (currentPosZ == 5) { targetPos = y1x5z5; }
            }
        }
        else if (currentPosY == 2) {
            if(currentPosX == 1 ) {
                     if (currentPosZ == 1) { targetPos = y2x1z1; }
                else if (currentPosZ == 2) { targetPos = y2x1z2; }
                else if (currentPosZ == 3) { targetPos = y2x1z3; }
                else if (currentPosZ == 4) { targetPos = y2x1z4; }
                else if (currentPosZ == 5) { targetPos = y2x1z5; }
            }
            else if(currentPosX == 2 ) {
                     if (currentPosZ == 1) { targetPos = y2x2z1; }
                else if (currentPosZ == 2) { targetPos = y2x2z2; }
                else if (currentPosZ == 3) { targetPos = y2x2z3; }
                else if (currentPosZ == 4) { targetPos = y2x2z4; }
                else if (currentPosZ == 5) { targetPos = y2x2z5; }
            }
            else if(currentPosX == 3 ) {
                     if (currentPosZ == 1) { targetPos = y2x3z1; }
                else if (currentPosZ == 2) { targetPos = y2x3z2; }
                else if (currentPosZ == 3) { targetPos = y2x3z3; }
                else if (currentPosZ == 4) { targetPos = y2x3z4; }
                else if (currentPosZ == 5) { targetPos = y2x3z5; }
            }
            else if(currentPosX == 4 ) {
                     if (currentPosZ == 1) { targetPos = y2x4z1; }
                else if (currentPosZ == 2) { targetPos = y2x4z2; }
                else if (currentPosZ == 3) { targetPos = y2x4z3; }
                else if (currentPosZ == 4) { targetPos = y2x4z4; }
                else if (currentPosZ == 5) { targetPos = y2x4z5; }
            }
            else if(currentPosX == 5 ) {
                     if (currentPosZ == 1) { targetPos = y2x5z1; }
                else if (currentPosZ == 2) { targetPos = y2x5z2; }
                else if (currentPosZ == 3) { targetPos = y2x5z3; }
                else if (currentPosZ == 4) { targetPos = y2x5z4; }
                else if (currentPosZ == 5) { targetPos = y2x5z5; }
            }
        }

        mc.BlockMoveActive(targetPos);
    }



    void MoveCrane() {

    }




}