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

    public GameObject gr1, gr2, gr3, gr4, gr5;
    private Transform[] y1, y2, y3, y4, y5; // private 으로
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
                        y3x5z1, y3x5z2, y3x5z3, y3x5z4, y3x5z5,

                        y4x1z1, y4x1z2, y4x1z3, y4x1z4, y4x1z5,
                        y4x2z1, y4x2z2, y4x2z3, y4x2z4, y4x2z5,
                        y4x3z1, y4x3z2, y4x3z3, y4x3z4, y4x3z5,
                        y4x4z1, y4x4z2, y4x4z3, y4x4z4, y4x4z5,
                        y4x5z1, y4x5z2, y4x5z3, y4x5z4, y4x5z5,

                        y5x1z1, y5x1z2, y5x1z3, y5x1z4, y5x1z5,
                        y5x2z1, y5x2z2, y5x2z3, y5x2z4, y5x2z5,
                        y5x3z1, y5x3z2, y5x3z3, y5x3z4, y5x3z5,
                        y5x4z1, y5x4z2, y5x4z3, y5x4z4, y5x4z5,
                        y5x5z1, y5x5z2, y5x5z3, y5x5z4, y5x5z5;


    void GetChild() {
        y1 = gr1.GetComponentsInChildren<Transform>();
        y2 = gr2.GetComponentsInChildren<Transform>();
        y3 = gr3.GetComponentsInChildren<Transform>();
        y4 = gr4.GetComponentsInChildren<Transform>();
        y5 = gr5.GetComponentsInChildren<Transform>();
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
        foreach (Transform tr3 in y3) {
			if (tr3.name == "x1z1") { y3x1z1 = tr3; }
            if (tr3.name == "x1z2") { y3x1z2 = tr3; }
            if (tr3.name == "x1z3") { y3x1z3 = tr3; }
            if (tr3.name == "x1z4") { y3x1z4 = tr3; }
            if (tr3.name == "x1z5") { y3x1z5 = tr3; }
            if (tr3.name == "x2z1") { y3x2z1 = tr3; }
            if (tr3.name == "x2z2") { y3x2z2 = tr3; }
            if (tr3.name == "x2z3") { y3x2z3 = tr3; }
            if (tr3.name == "x2z4") { y3x2z4 = tr3; }
            if (tr3.name == "x2z5") { y3x2z5 = tr3; }
            if (tr3.name == "x3z1") { y3x3z1 = tr3; }
            if (tr3.name == "x3z2") { y3x3z2 = tr3; }
            if (tr3.name == "x3z3") { y3x3z3 = tr3; }
            if (tr3.name == "x3z4") { y3x3z4 = tr3; }
            if (tr3.name == "x3z5") { y3x3z5 = tr3; }
            if (tr3.name == "x4z1") { y3x4z1 = tr3; }
            if (tr3.name == "x4z2") { y3x4z2 = tr3; }
            if (tr3.name == "x4z3") { y3x4z3 = tr3; }
            if (tr3.name == "x4z4") { y3x4z4 = tr3; }
            if (tr3.name == "x4z5") { y3x4z5 = tr3; }
            if (tr3.name == "x5z1") { y3x5z1 = tr3; }
            if (tr3.name == "x5z2") { y3x5z2 = tr3; }
            if (tr3.name == "x5z3") { y3x5z3 = tr3; }
            if (tr3.name == "x5z4") { y3x5z4 = tr3; }
            if (tr3.name == "x5z5") { y3x5z5 = tr3; }
        }
        foreach (Transform tr4 in y4) {
			if (tr4.name == "x1z1") { y4x1z1 = tr4; }
            if (tr4.name == "x1z2") { y4x1z2 = tr4; }
            if (tr4.name == "x1z3") { y4x1z3 = tr4; }
            if (tr4.name == "x1z4") { y4x1z4 = tr4; }
            if (tr4.name == "x1z5") { y4x1z5 = tr4; }
            if (tr4.name == "x2z1") { y4x2z1 = tr4; }
            if (tr4.name == "x2z2") { y4x2z2 = tr4; }
            if (tr4.name == "x2z3") { y4x2z3 = tr4; }
            if (tr4.name == "x2z4") { y4x2z4 = tr4; }
            if (tr4.name == "x2z5") { y4x2z5 = tr4; }
            if (tr4.name == "x3z1") { y4x3z1 = tr4; }
            if (tr4.name == "x3z2") { y4x3z2 = tr4; }
            if (tr4.name == "x3z3") { y4x3z3 = tr4; }
            if (tr4.name == "x3z4") { y4x3z4 = tr4; }
            if (tr4.name == "x3z5") { y4x3z5 = tr4; }
            if (tr4.name == "x4z1") { y4x4z1 = tr4; }
            if (tr4.name == "x4z2") { y4x4z2 = tr4; }
            if (tr4.name == "x4z3") { y4x4z3 = tr4; }
            if (tr4.name == "x4z4") { y4x4z4 = tr4; }
            if (tr4.name == "x4z5") { y4x4z5 = tr4; }
            if (tr4.name == "x5z1") { y4x5z1 = tr4; }
            if (tr4.name == "x5z2") { y4x5z2 = tr4; }
            if (tr4.name == "x5z3") { y4x5z3 = tr4; }
            if (tr4.name == "x5z4") { y4x5z4 = tr4; }
            if (tr4.name == "x5z5") { y4x5z5 = tr4; }
        }
        foreach (Transform tr5 in y5) {
			if (tr5.name == "x1z1") { y5x1z1 = tr5; }
            if (tr5.name == "x1z2") { y5x1z2 = tr5; }
            if (tr5.name == "x1z3") { y5x1z3 = tr5; }
            if (tr5.name == "x1z4") { y5x1z4 = tr5; }
            if (tr5.name == "x1z5") { y5x1z5 = tr5; }
            if (tr5.name == "x2z1") { y5x2z1 = tr5; }
            if (tr5.name == "x2z2") { y5x2z2 = tr5; }
            if (tr5.name == "x2z3") { y5x2z3 = tr5; }
            if (tr5.name == "x2z4") { y5x2z4 = tr5; }
            if (tr5.name == "x2z5") { y5x2z5 = tr5; }
            if (tr5.name == "x3z1") { y5x3z1 = tr5; }
            if (tr5.name == "x3z2") { y5x3z2 = tr5; }
            if (tr5.name == "x3z3") { y5x3z3 = tr5; }
            if (tr5.name == "x3z4") { y5x3z4 = tr5; }
            if (tr5.name == "x3z5") { y5x3z5 = tr5; }
            if (tr5.name == "x4z1") { y5x4z1 = tr5; }
            if (tr5.name == "x4z2") { y5x4z2 = tr5; }
            if (tr5.name == "x4z3") { y5x4z3 = tr5; }
            if (tr5.name == "x4z4") { y5x4z4 = tr5; }
            if (tr5.name == "x4z5") { y5x4z5 = tr5; }
            if (tr5.name == "x5z1") { y5x5z1 = tr5; }
            if (tr5.name == "x5z2") { y5x5z2 = tr5; }
            if (tr5.name == "x5z3") { y5x5z3 = tr5; }
            if (tr5.name == "x5z4") { y5x5z4 = tr5; }
            if (tr5.name == "x5z5") { y5x5z5 = tr5; }
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

    public void GetDirection(int dir) { testScript.Instance.PVoverlap = false;
        // 1 : Y+,  2 : Y-,  3 : X+,  4 : X-,  5 : Z+,  6 : Z-
             if (dir == 1) { currentPosY++; }
        else if (dir == 2) { currentPosY--; }
        else if (dir == 3) { currentPosX++; }
        else if (dir == 4) { currentPosX--; }
        else if (dir == 5) { currentPosZ++; }
        else if (dir == 6) { currentPosZ--; }
        else if (dir == -1) { SetDefaultPosition(); }

             if (currentPosY > 5) { currentPosY = 5; testScript.Instance.PVoverlap = true; return; }
        else if (currentPosY < 1) { currentPosY = 1; testScript.Instance.PVoverlap = true; return; }

             if (currentPosX > 5) { currentPosX = 5; testScript.Instance.PVoverlap = true; return; }
        else if (currentPosX < 1) { currentPosX = 1; testScript.Instance.PVoverlap = true; return; }

             if (currentPosZ > 5) { currentPosZ = 5; testScript.Instance.PVoverlap = true; return; }
        else if (currentPosZ < 1) { currentPosZ = 1; testScript.Instance.PVoverlap = true; return; }

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

        else if (currentPosY == 3) {
            if(currentPosX == 1 ) {
                     if (currentPosZ == 1) { targetPos = y3x1z1; }
                else if (currentPosZ == 2) { targetPos = y3x1z2; }
                else if (currentPosZ == 3) { targetPos = y3x1z3; }
                else if (currentPosZ == 4) { targetPos = y3x1z4; }
                else if (currentPosZ == 5) { targetPos = y3x1z5; }
            }
            else if(currentPosX == 2 ) {
                     if (currentPosZ == 1) { targetPos = y3x2z1; }
                else if (currentPosZ == 2) { targetPos = y3x2z2; }
                else if (currentPosZ == 3) { targetPos = y3x2z3; }
                else if (currentPosZ == 4) { targetPos = y3x2z4; }
                else if (currentPosZ == 5) { targetPos = y3x2z5; }
            }
            else if(currentPosX == 3 ) {
                     if (currentPosZ == 1) { targetPos = y3x3z1; }
                else if (currentPosZ == 2) { targetPos = y3x3z2; }
                else if (currentPosZ == 3) { targetPos = y3x3z3; }
                else if (currentPosZ == 4) { targetPos = y3x3z4; }
                else if (currentPosZ == 5) { targetPos = y3x3z5; }
            }
            else if(currentPosX == 4 ) {
                     if (currentPosZ == 1) { targetPos = y3x4z1; }
                else if (currentPosZ == 2) { targetPos = y3x4z2; }
                else if (currentPosZ == 3) { targetPos = y3x4z3; }
                else if (currentPosZ == 4) { targetPos = y3x4z4; }
                else if (currentPosZ == 5) { targetPos = y3x4z5; }
            }
            else if(currentPosX == 5 ) {
                     if (currentPosZ == 1) { targetPos = y3x5z1; }
                else if (currentPosZ == 2) { targetPos = y3x5z2; }
                else if (currentPosZ == 3) { targetPos = y3x5z3; }
                else if (currentPosZ == 4) { targetPos = y3x5z4; }
                else if (currentPosZ == 5) { targetPos = y3x5z5; }
            }
        }

        else if (currentPosY == 4) {
            if(currentPosX == 1 ) {
                     if (currentPosZ == 1) { targetPos = y4x1z1; }
                else if (currentPosZ == 2) { targetPos = y4x1z2; }
                else if (currentPosZ == 3) { targetPos = y4x1z3; }
                else if (currentPosZ == 4) { targetPos = y4x1z4; }
                else if (currentPosZ == 5) { targetPos = y4x1z5; }
            }
            else if(currentPosX == 2 ) {
                     if (currentPosZ == 1) { targetPos = y4x2z1; }
                else if (currentPosZ == 2) { targetPos = y4x2z2; }
                else if (currentPosZ == 3) { targetPos = y4x2z3; }
                else if (currentPosZ == 4) { targetPos = y4x2z4; }
                else if (currentPosZ == 5) { targetPos = y4x2z5; }
            }
            else if(currentPosX == 3 ) {
                     if (currentPosZ == 1) { targetPos = y4x3z1; }
                else if (currentPosZ == 2) { targetPos = y4x3z2; }
                else if (currentPosZ == 3) { targetPos = y4x3z3; }
                else if (currentPosZ == 4) { targetPos = y4x3z4; }
                else if (currentPosZ == 5) { targetPos = y4x3z5; }
            }
            else if(currentPosX == 4 ) {
                     if (currentPosZ == 1) { targetPos = y4x4z1; }
                else if (currentPosZ == 2) { targetPos = y4x4z2; }
                else if (currentPosZ == 3) { targetPos = y4x4z3; }
                else if (currentPosZ == 4) { targetPos = y4x4z4; }
                else if (currentPosZ == 5) { targetPos = y4x4z5; }
            }
            else if(currentPosX == 5 ) {
                     if (currentPosZ == 1) { targetPos = y4x5z1; }
                else if (currentPosZ == 2) { targetPos = y4x5z2; }
                else if (currentPosZ == 3) { targetPos = y4x5z3; }
                else if (currentPosZ == 4) { targetPos = y4x5z4; }
                else if (currentPosZ == 5) { targetPos = y4x5z5; }
            }
        }

        else if (currentPosY == 5) {
            if(currentPosX == 1 ) {
                     if (currentPosZ == 1) { targetPos = y5x1z1; }
                else if (currentPosZ == 2) { targetPos = y5x1z2; }
                else if (currentPosZ == 3) { targetPos = y5x1z3; }
                else if (currentPosZ == 4) { targetPos = y5x1z4; }
                else if (currentPosZ == 5) { targetPos = y5x1z5; }
            }
            else if(currentPosX == 2 ) {
                     if (currentPosZ == 1) { targetPos = y5x2z1; }
                else if (currentPosZ == 2) { targetPos = y5x2z2; }
                else if (currentPosZ == 3) { targetPos = y5x2z3; }
                else if (currentPosZ == 4) { targetPos = y5x2z4; }
                else if (currentPosZ == 5) { targetPos = y5x2z5; }
            }
            else if(currentPosX == 3 ) {
                     if (currentPosZ == 1) { targetPos = y5x3z1; }
                else if (currentPosZ == 2) { targetPos = y5x3z2; }
                else if (currentPosZ == 3) { targetPos = y5x3z3; }
                else if (currentPosZ == 4) { targetPos = y5x3z4; }
                else if (currentPosZ == 5) { targetPos = y5x3z5; }
            }
            else if(currentPosX == 4 ) {
                     if (currentPosZ == 1) { targetPos = y5x4z1; }
                else if (currentPosZ == 2) { targetPos = y5x4z2; }
                else if (currentPosZ == 3) { targetPos = y5x4z3; }
                else if (currentPosZ == 4) { targetPos = y5x4z4; }
                else if (currentPosZ == 5) { targetPos = y5x4z5; }
            }
            else if(currentPosX == 5 ) {
                     if (currentPosZ == 1) { targetPos = y5x5z1; }
                else if (currentPosZ == 2) { targetPos = y5x5z2; }
                else if (currentPosZ == 3) { targetPos = y5x5z3; }
                else if (currentPosZ == 4) { targetPos = y5x5z4; }
                else if (currentPosZ == 5) { targetPos = y5x5z5; }
            }
        }
        mc.BlockMoveActive(targetPos);
    }

}