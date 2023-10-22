using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class rotateBlock : MonoBehaviour {

    private float angle = 90.0f;


    //==============================================================
    //private float targetRotDirY, currentRotY;

    /*
    public void GetStartRotVal() {
        Debug.Log("before calibrate : " + this.transform.localEulerAngles.x + ", " + this.transform.localEulerAngles.y + ", " + this.transform.localEulerAngles.z);
        CalibratingBoxDegree(this.transform.localEulerAngles.x, 1);
        CalibratingBoxDegree(this.transform.localEulerAngles.y, 2);
        CalibratingBoxDegree(this.transform.localEulerAngles.z, 3);
        //this.transform.localRotation = Quaternion.Euler(calibratedX, calibratedY, calibratedZ);
        this.transform.localEulerAngles = new Vector3(calibratedX, calibratedY, calibratedZ);
        Debug.Log("calibrate done : " + calibratedX + ", " + calibratedY + ", " + calibratedZ);
        StartCoroutine(ResetCalibrateVal());
        testScript.Instance.PVoverlap = true;
    }
    */

    public int armPP, contactPP;//private으로
    public float chosenContactAxis, targetContactDir, chosenArmAxis, targetArmDir;//private으로
    public Vector3 contactOriginPivot, armOriginPivot;//private으로

    // armPP & contactPP
    // 1 : xp ( -to+, R : x- )  2 : xm ( +to-, R : x+ )
    // 3 : yp ( -to+, R : y- )  4 : ym ( +to-, R : y+ )
    // 5 : zp ( -to+, R : z- )  6 : zm ( +to-, R : z+ )

    public void GetAttachPivotPoints(int arm, int contact) { 
        if (arm == -1 && contact == -1) { chosenContactAxis = targetContactDir = 0; } // -1, -1 : reset
        armPP = arm;
        contactPP = contact;
        //Debug.Log("armPP : " + armPP + " / contactPP : " + contactPP);
        DirectionDesignateMachine();
    }

    void DirectionDesignateMachine() {
             if (armPP == 1) { } // X-축 isArmPivot targetArmPivotRM
        else if (armPP == 2) { } // X+축 isArmPivot targetArmPivotRP
        else if (armPP == 3) { } // Y-축 isArmPivot targetArmPivotRM
        else if (armPP == 4) { } // Y+축 isArmPivot targetArmPivotRP
        else if (armPP == 5) { } // Z-축 isArmPivot targetArmPivotRM
        else if (armPP == 6) { } // Z+축 isArmPivot targetArmPivotRP

        contactOriginPivot = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);

        if (contactPP == 1 || contactPP == 2) { chosenContactAxis = contactOriginPivot.x; }
        else if (contactPP == 3 || contactPP == 4) { chosenContactAxis = contactOriginPivot.y; }
        else if (contactPP == 5 || contactPP == 6) { chosenContactAxis = contactOriginPivot.z; }
    }

    public void RotateContactPivot(int dir) { // 1 : - left,  2 : + right
        if (dir == 1) {
            //targetContactDir = chosenContactAxis - angle;
                 if (contactPP == 1 || contactPP == 3 || contactPP == 5) { targetContactDir = -chosenContactAxis - angle; }
            else if (contactPP == 2 || contactPP == 4 || contactPP == 6) { targetContactDir =  chosenContactAxis - angle; }
            //Debug.Log("targetRotDirY 1 : " + targetRotDirY);
            StartCoroutine(ContactAxisRotation());
        }
        else if (dir == 2) {
            //targetContactDir = chosenContactAxis + angle;
                 if (contactPP == 1 || contactPP == 3 || contactPP == 5) { targetContactDir = -chosenContactAxis + angle; }
            else if (contactPP == 2 || contactPP == 4 || contactPP == 6) { targetContactDir =  chosenContactAxis + angle; }
            //Debug.Log("targetRotDirY 2 : " + targetRotDirY);
            StartCoroutine(ContactAxisRotation());
        }
	}

	private float percent, activeTime;

	IEnumerator ContactAxisRotation() {
        while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 2.5f;

            //currentRotY = Mathf.Lerp(currentRotY, targetRotDirY, 5.0f * (1 + percent) * Time.smoothDeltaTime);
            //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, currentRotY, this.transform.localRotation.z);
            //this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, currentRotY, this.transform.localRotation.z);

            chosenContactAxis = Mathf.Lerp(chosenContactAxis, targetContactDir, 5.0f * (1 + percent) * Time.smoothDeltaTime);

                 if (contactPP == 1) { this.transform.localEulerAngles
                    = new Vector3(-chosenContactAxis, contactOriginPivot.y, contactOriginPivot.z); } //-를 해주는게 맞는지는 확인 필요
            else if (contactPP == 2) { this.transform.localEulerAngles
                    = new Vector3( chosenContactAxis, contactOriginPivot.y, contactOriginPivot.z); }
            else if (contactPP == 3) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, -chosenContactAxis, contactOriginPivot.z); }
            else if (contactPP == 4) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x,  chosenContactAxis, contactOriginPivot.z); }
            else if (contactPP == 5) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, contactOriginPivot.y, -chosenContactAxis); }
            else if (contactPP == 6) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, contactOriginPivot.y,  chosenContactAxis); }

            yield return null;
		}

		if (percent >= 1) { activeTime = percent = 0;
                 if (contactPP == 1) { this.transform.localEulerAngles
                    = new Vector3(-targetContactDir, contactOriginPivot.y, contactOriginPivot.z); } //-를 해주는게 맞는지는 확인 필요
            else if (contactPP == 2) { this.transform.localEulerAngles
                    = new Vector3( targetContactDir, contactOriginPivot.y, contactOriginPivot.z); }
            else if (contactPP == 3) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, -targetContactDir, contactOriginPivot.z); }
            else if (contactPP == 4) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x,  targetContactDir, contactOriginPivot.z); }
            else if (contactPP == 5) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, contactOriginPivot.y, -targetContactDir); }
            else if (contactPP == 6) { this.transform.localEulerAngles
                    = new Vector3(contactOriginPivot.x, contactOriginPivot.y,  targetContactDir); }

            chosenContactAxis = targetContactDir;
            //CalibratingMyself();
            testScript.Instance.PVoverlap = true;
        }
	}

    public void RotateArmPivot(float val) {
            //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y, Zval);
        this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, val);
    }
    //암피벗에도 어느 축을 기준으로 할지 정해주는 함수 필요


    //==============================================================
    public void CalibratingMyself() { // 문제 많음
        //Debug.Log("before calibrate box : " + this.transform.localEulerAngles.x + ", " + this.transform.localEulerAngles.y + ", " + this.transform.localEulerAngles.z);
        CalibratingBoxDegree(this.transform.localEulerAngles.x, 1);
        CalibratingBoxDegree(this.transform.localEulerAngles.y, 2);
        CalibratingBoxDegree(this.transform.localEulerAngles.y, 3);
        StartCoroutine(CalibratingMyselff());
    }

    IEnumerator CalibratingMyselff() {
        yield return testScript.YieldInstructionCache.WaitForSeconds(0.1f);
        //this.transform.localRotation = Quaternion.Euler(calibratedX, calibratedY, calibratedZ);
        this.transform.localEulerAngles = new Vector3(calibratedX, calibratedY, calibratedZ);
        //Debug.Log("box calibrate done : " + this.transform.localEulerAngles.x + ", " + this.transform.localEulerAngles.y + ", " + this.transform.localEulerAngles.z);
        yield return testScript.YieldInstructionCache.WaitForSeconds(0.1f);
        CalibratingBoxDegree(0, 0);
    }

    private float Common, calibratedX, calibratedY, calibratedZ;

    private void CalibratingBoxDegree(float val, int axis) {
        if (axis == 0) { Common = calibratedX = calibratedY = calibratedZ = 0;
            //Debug.Log("reset calibrate Val : " + Common + ", " + calibratedX + ", " + calibratedY + ", " + calibratedZ);
            return; }

        if (val >= 0) { //Debug.Log("+ before calibrate : " + val);
                 if (val > 315.0f || val < 45.0f) { Common = 0;  }
            else if (val >= 45.0f && val < 135.0f) { Common = 90.0f; }
            else if (val >= 135.0f && val < 225.0f) { Common = 180.0f; }
            else if (val >= 225.0f && val <= 315.0f) { Common = 270.0f; }
            //Debug.Log("+ calibrated : " + Common);
        }

        else  if (val < 0) {
            //Debug.Log("- before calibrate : " + val);
                 if (val < -315.0f || val > -45.0f) { Common = 0; }
            else if (val <= -45.0f && val > -135.0f) { Common = -90.0f; }
            else if (val <= -135.0f && val > -225.0f) { Common = -180.0f; }
            else if (val <= -225.0f && val >= -315.0f) { Common = -270.0f; }
            //Debug.Log("- calibrated : " + Common);
        }

             if (axis == 1) { calibratedX = Common; }
        else if (axis == 2) { calibratedY = Common; }
        else if (axis == 3) { calibratedZ = Common; }
    }
}