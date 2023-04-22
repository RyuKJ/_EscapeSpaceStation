using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrane : MonoBehaviour {

	public Transform gripPivotY, cranePivotZ, detachSpot, sensorPos, targetPos, originPos;
    public bool PVoverlap = true;

    private float moveDirX, moveDirY, moveDirZ, targetRotDirY, targetRotDirZ, currtRotY, currtRotZ;
    private Vector3 myPos;

    // 내가 정한 수치
    private float moveDistance = 3.0f;
	private float rotAngle = 90f;


    //=======================
	/*
	void Start() { myTag.SetActive(false); }

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
		//targetPos = new Vector3(myPos.x + moveDirX, myPos.y + moveDirY, myPos.z + moveDirZ);
		while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 3.0f;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos.position, 6.0f * (1 + percent) * Time.smoothDeltaTime);
            yield return null;
		}
		if (percent >= 1) {
			//CheckRightPosition();
			moveDirX = moveDirY = moveDirZ = 0;
			activeTime = percent = 0;
			this.transform.position = targetPos.position;
			myPos = targetPos.position;
			PVoverlap = true;
        }
	}

	private int whichAxis; // 1 : y, 2 : z

	//==============================================================
	public void BlockRotateActive(int newRotation) {
        // 1 : Y+,  2 : Y-,  3 : Z+,  4 : Z-
		if (PVoverlap) {
		    if (newRotation == 1) { PVoverlap = false; // y로 상정중
			    whichAxis = 1;
                targetRotDirY = targetRotDirY - 90.0f;
                StartCoroutine(AxisRotation());
			}
			else if (newRotation == 2) { PVoverlap = false;
                whichAxis = 1;
                StartCoroutine(AxisRotation());
			}
			else if (newRotation == 3) { PVoverlap = false; // z로 상정중
			    whichAxis = 2;
                targetRotDirZ = targetRotDirZ - 90.0f;
			    StartCoroutine(AxisRotation());
			}
			else if (newRotation == 4) { PVoverlap = false;
                whichAxis = 2;
                StartCoroutine(AxisRotation());
			}
		}
	}

	public float percent2, activeTime2;

	IEnumerator AxisRotation() {
        while (percent2 < 1) {
			activeTime2 += Time.smoothDeltaTime;
			percent2 = activeTime2 * 2.5f;

			if (whichAxis == 1) {
				currtRotY = Mathf.Lerp(currtRotY, targetRotDirY, 5.0f * (1 + percent2) * Time.smoothDeltaTime);
                gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, currtRotY, gripPivotY.localRotation.z); }
			else if (whichAxis == 2) {
                currtRotZ = Mathf.Lerp(currtRotZ, targetRotDirZ, 5.0f * (1 + percent2) * Time.smoothDeltaTime);
                cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y + 90, currtRotZ); }
            yield return null;
		}
		if (percent2 >= 1) { activeTime2 = percent2 = 0;

				 if (whichAxis == 1) { gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, targetRotDirY, gripPivotY.localRotation.z); }
            else if (whichAxis == 2) { cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y + 90, targetRotDirZ); }

            if (currtRotY >= 269.9f || currtRotY <= -269.9f) {
				currtRotY = targetRotDirY = 0;
                gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, 0, gripPivotY.localRotation.z); }
            if (currtRotZ >= 269.9f || currtRotZ <= -269.9f) {
                currtRotZ = targetRotDirZ = 0;
                cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y + 90, 0);
            }
            PVoverlap = true;
        }
	}


    private bool holding;
    //private int layerMask = 1 << 8;
    private float detectLine = 0.5f;
    private RaycastHit hitSensor;

    public void DetachAttachModule() {
		Debug.DrawRay(sensorPos.position, sensorPos.forward * detectLine, Color.red, 0.5f);
        if (Physics.Raycast(sensorPos.position, sensorPos.forward, out hitSensor, detectLine)) {
			if (!hitSensor.collider.CompareTag("Modules")) { Debug.Log("it's not module"); return; }

			if (!holding && hitSensor.collider.CompareTag("Modules")) { holding = true;
                Debug.Log("attach");
                hitSensor.collider.gameObject.transform.parent.parent = gripPivotY;
				originPos = hitSensor.collider.gameObject.transform.parent.transform;
            }
			else if (holding && hitSensor.collider.CompareTag("Modules")) { holding = false;
				Debug.Log("detach");
                //PositionCorrectionSystem();
                gripPivotY.GetChild(0).gameObject.transform.parent = detachSpot;


				// 기존 localTransform을 어떻게 저장하고 어느 순간에 붙여야할지 연구 필요
                gripPivotY.GetChild(0).gameObject.transform.parent.transform.localPosition = originPos.localPosition;
                gripPivotY.GetChild(0).gameObject.transform.parent.transform.localRotation = originPos.localRotation;
                gripPivotY.GetChild(0).gameObject.transform.parent.transform.localScale = originPos.localScale;


                
                //gripPivotY.localRotation = Quaternion.Euler(0, 0, 0);
            }
		}
	}


	// 이게 해결책이 아닐 수 있음
	private float cRv_X, cRv_Y, cRv_Z;//, cPv_X, cPv_Y, cPv_Z;

    void PositionCorrectionSystem() {
		gripPivotY.GetChild(0).gameObject.transform.parent.localScale = new Vector3(1, 1, 1);

		gripPivotY.GetChild(0).gameObject.transform.parent.localPosition = targetPos.position;

        cRv_X = gripPivotY.GetChild(0).gameObject.transform.parent.localRotation.x;
        cRv_Y = gripPivotY.GetChild(0).gameObject.transform.parent.localRotation.y;
        cRv_Z = gripPivotY.GetChild(0).gameObject.transform.parent.localRotation.z;

			 if (cRv_X > 0 && cRv_X < 45) { cRv_X = 0; }		else if (cRv_X > 45 && cRv_X < 90) { cRv_X = 90; }
        else if (cRv_X > 90 && cRv_X < 135) { cRv_X = 90; }		else if (cRv_X > 135 && cRv_X < 180) { cRv_X = 180; }
        else if (cRv_X > 180 && cRv_X < 225) { cRv_X = 180; }	else if (cRv_X > 225 && cRv_X < 270) { cRv_X = 270; }
        else if (cRv_X > 270 && cRv_X < 315) { cRv_X = 270; }	else if (cRv_X > 315 && cRv_X <= 360) { cRv_X = 0; }

    }


    //private void OnTriggerStay(Collider other) { }


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