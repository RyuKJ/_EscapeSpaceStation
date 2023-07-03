using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlock : MonoBehaviour {

    private float angle = 90.0f;


    //==============================================================
    private float targetRotDirY, currentRotY;

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

    IEnumerator ResetCalibrateVal() {
        yield return testScript.YieldInstructionCache.WaitForSeconds(0.1f);
        CalibratingBoxDegree(0, 0);
    }


    public void RotateMyself(int dir) {
        // 1 : Y-,  2 : Y+
        if (dir == 1) {
            targetRotDirY = currentRotY - angle;
            //Debug.Log("targetRotDirY 1 : " + targetRotDirY);
            StartCoroutine(AxisYRotation());
        }
        else if (dir == 2) {
            targetRotDirY = currentRotY + angle;
            //Debug.Log("targetRotDirY 2 : " + targetRotDirY);
            StartCoroutine(AxisYRotation());
        }
	}

	private float percent, activeTime;

	IEnumerator AxisYRotation() {
        while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 2.5f;

			currentRotY = Mathf.Lerp(currentRotY, targetRotDirY, 5.0f * (1 + percent) * Time.smoothDeltaTime);
                //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, currentRotY, this.transform.localRotation.z);
            this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, currentRotY, this.transform.localRotation.z);
            yield return null;
		}

		if (percent >= 1) { activeTime = percent = 0;
            //Debug.Log("before Y calibrate: " + this.transform.localEulerAngles.x + ", " + targetRotDirY + ", " + this.transform.localEulerAngles.z);
            CalibratingBoxDegree(this.transform.localEulerAngles.x, 1);
            CalibratingBoxDegree(targetRotDirY, 2);
            CalibratingBoxDegree(this.transform.localEulerAngles.z, 3);
                //this.transform.localRotation = Quaternion.Euler(calibratedX, calibratedY, calibratedZ);
            this.transform.localEulerAngles = new Vector3(calibratedX, calibratedY, calibratedZ);
            //Debug.Log("calibrate Y done : " + calibratedX + ", " + calibratedY + ", " + calibratedZ);
            currentRotY = calibratedY;

            yield return testScript.YieldInstructionCache.WaitForSeconds(0.1f);
            CalibratingBoxDegree(0, 0);
            testScript.Instance.PVoverlap = true;
        }
	}

    public void AxisZRotation(float Zval) {
            //this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y, Zval);
        this.transform.localEulerAngles = new Vector3(this.transform.localRotation.x, this.transform.localRotation.y, Zval);
    }

    public void CalibratingZAxis(float Zcal) {
        //Debug.Log("before Z box calibrate: " + this.transform.localEulerAngles.x + ", " + this.transform.localEulerAngles.y + ", " + Zcal);
        CalibratingBoxDegree(this.transform.localEulerAngles.x, 1);
        CalibratingBoxDegree(this.transform.localEulerAngles.y, 2);
        CalibratingBoxDegree(Zcal, 3);
            //this.transform.localRotation = Quaternion.Euler(calibratedX, calibratedY, calibratedZ);
        this.transform.localEulerAngles = new Vector3(calibratedX, calibratedY, calibratedZ);
        //Debug.Log("calibrate Z box done : " + calibratedX + ", " + calibratedY + ", " + calibratedZ);
        StartCoroutine(ResetCalibrateVal());
    }

    //==============================================================
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