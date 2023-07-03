using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;


public class moveCrane : MonoBehaviour {

	public Transform cranePivotZ, detachSpot, sensorPos, targetPos, originPos;
	public float targetRotDirZ, childTargetRotDirZ, currtRotZ, localRotSaveX, localRotSaveY;//, localRotSaveZ;

    // 내가 정한 수치
	private float angle = 90.0f;

	
	void Start() { RotationValueBackup(); }


	void RotationValueBackup() {
		localRotSaveX = cranePivotZ.localEulerAngles.x;
		localRotSaveY = cranePivotZ.localEulerAngles.y;
        currtRotZ = cranePivotZ.localEulerAngles.z;
    }

	/*
    public void ShowMyName (bool on) { if (on) { myTag.SetActive(true); } else { myTag.SetActive(false); } }

    private bool myTerritory;

    void CheckMyTerritory() {
		RaycastHit hit;
		if (Physics.Raycast(this.transform.position, Vector3.forward, out hit)) {
			if (hit.collider.gameObject.tag == this.gameObject.tag) {
				myTerritory = true;
			}
			else if (hit.collider.gameObject.tag != this.gameObject.tag) {
				myTerritory = false;
			}
		}
	}
	*/

	//==============================================================
	public void BlockMoveActive(Transform target) {
		// 1 : Y+,  2 : Y-,  3 : X+,  4 : X-,  5 : Z+,  6 : Z-

		targetPos = target;
		StartCoroutine(MovePosition());
    }

	private float percent, activeTime = 0;

	IEnumerator MovePosition() {
		while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 3.0f;
            cranePivotZ.position
				= Vector3.Lerp(cranePivotZ.position, targetPos.position, 6.0f * (1 + percent) * Time.smoothDeltaTime);
            yield return null;
		}
		if (percent >= 1) {
			activeTime = percent = 0;
            cranePivotZ.position = targetPos.position;
			testScript.Instance.PVoverlap = true;
        }
	}


    //==============================================================
    public rotateBlock robl; // private로 수정

    public void BlockRotateActive(int direction) { testScript.Instance.PVoverlap = false;
		// 1 : Y+,  2 : Y-,  3 : Z+,  4 : Z-

		if (robl != null && direction == 1) {
			robl.RotateMyself(1);
			Debug.Log("Y rot");
		}
		else if (robl != null && direction == 2) {
			robl.RotateMyself(2);
			Debug.Log("wrong 1");
		}
		else if (direction == 3) {
			targetRotDirZ = currtRotZ + angle;
			StartCoroutine(CraneRotation());
			Debug.Log("Z rot");
		}
		else if (direction == 4) {
			targetRotDirZ = currtRotZ - angle;
			StartCoroutine(CraneRotation());
			Debug.Log("wrong 2");
		}
		else { Debug.Log("rotateBlock is null"); testScript.Instance.PVoverlap = true; }
	}


    private float percent2, activeTime2 = 0;

	IEnumerator CraneRotation() {
		while (percent2 < 1) {
			activeTime2 += Time.smoothDeltaTime;
			percent2 = activeTime2 * 2.5f;

			currtRotZ = Mathf.Lerp(currtRotZ, targetRotDirZ, 5.0f * (1 + percent) * Time.smoothDeltaTime);
				//cranePivotZ.localRotation = Quaternion.Euler(localRotSaveX, localRotSaveY, currtRotZ);
            cranePivotZ.localEulerAngles = new Vector3(localRotSaveX, localRotSaveY, currtRotZ);

            if (robl != null) { robl.AxisZRotation(currtRotZ); }
            yield return null;
		}
		if (percent2 >= 1) { activeTime2 = percent2 = 0;

            //Debug.Log("before Z crane calibrate: " + cranePivotZ.localEulerAngles.x + ", " + cranePivotZ.localEulerAngles.y + ", " + targetRotDirZ);
            CalibratingCraneDegree(targetRotDirZ, 3);
			if (robl != null) { robl.CalibratingZAxis(calibratedZ); }
            CalibratingCraneDegree(cranePivotZ.localEulerAngles.x, 1);
            CalibratingCraneDegree(cranePivotZ.localEulerAngles.y, 2);
				//cranePivotZ.localRotation = Quaternion.Euler(calibratedX, calibratedY, calibratedZ);
            cranePivotZ.localEulerAngles = new Vector3(calibratedX, calibratedY, calibratedZ);
            //Debug.Log("calibrate Z crane done : " + calibratedX + ", " + calibratedY + ", " + calibratedZ);
            currtRotZ = calibratedZ;

            yield return testScript.YieldInstructionCache.WaitForSeconds(0.1f);
            CalibratingCraneDegree(0, 0);
            testScript.Instance.PVoverlap = true;
		}
	}


	//==============================================================
    private float Common, calibratedX, calibratedY, calibratedZ;

    private void CalibratingCraneDegree(float val, int axis) {
        if (axis == 0) { Common = calibratedX = calibratedY = calibratedZ = 0;
            return; }

        if (val >= 0) {
                 if (val > 315.0f || val < 45.0f) { Common = 0;  }
            else if (val >= 45.0f && val < 135.0f) { Common = 90.0f; }
            else if (val >= 135.0f && val < 225.0f) { Common = 180.0f; }
            else if (val >= 225.0f && val <= 315.0f) { Common = 270.0f; }
        }

        else  if (val < 0) {
                 if (val < -315.0f || val > -45.0f) { Common = 0; }
            else if (val <= -45.0f && val > -135.0f) { Common = -90.0f; }
            else if (val <= -135.0f && val > -225.0f) { Common = -180.0f; }
            else if (val <= -225.0f && val >= -315.0f) { Common = -270.0f; }
        }

             if (axis == 1) { calibratedX = Common; }
        else if (axis == 2) { calibratedY = Common; }
        else if (axis == 3) { calibratedZ = Common; }
    }


    //==============================================================
    private bool holding;
    //private int layerMask = 1 << 8;
    private float detectLine = 0.5f;
    private RaycastHit hitSensor;

    public void DetachAttachModule() {
		Debug.DrawRay(sensorPos.position, sensorPos.forward * detectLine, UnityEngine.Color.red, 0.5f);
        if (Physics.Raycast(sensorPos.position, sensorPos.forward, out hitSensor, detectLine)) {
			if (!hitSensor.collider.CompareTag("Modules")) { Debug.Log("this is not a module"); return; }

			if (!holding && hitSensor.collider.CompareTag("Modules")) { holding = true;
                robl = hitSensor.collider.gameObject.transform.parent.GetComponent<rotateBlock>();
                Debug.Log("attach O");
            }
			else if (holding && hitSensor.collider.CompareTag("Modules")) { holding = false;
                //Debug.Log("GGG");
                robl = null;
                Debug.Log("detach X");
            }
		}
	}


    //==============================================================
    /*
	void CheckRightPosition() {
		RaycastHit hit;
		if (Physics.Raycast(this.transform.position, Vector3.forward, out hit)) {
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.yellow);
			if (hit.collider.gameObject.tag == this.gameObject.tag) {
				if (!myTerritory) { myTerritory = true;
				}
			}
			else if (hit.collider.gameObject.tag != this.gameObject.tag) {
				if (myTerritory) { myTerritory = false;
				}
			}
		}
	}
	*/

}