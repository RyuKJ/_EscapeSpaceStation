using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrane : MonoBehaviour {

	public Transform gripPivotY, cranePivotZ;
	//public int cubeName;
	//public GameObject myTag;
	private float moveDistance = 3.0f;
	private float rotAngle = 90f;
	private float moveDirX, moveDirY, moveDirZ, targetRotDirY, targetRotDirZ;
	//public Quaternion  // targetRot, currentRot
    private Vector3 targetPos, myPos;
	private bool PVoverlap = true;

	//=======================
	private bool myTerritory;

	//void Start() { myTag.SetActive(false); }

	//public void ShowMyName (bool on) { if (on) { myTag.SetActive(true); } else { myTag.SetActive(false); } }

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


	//==============================================================
	public void BlockMoveActive(int newDirection) {
		// 1 : Y+,  2 : Y-,  3 : X+,  4 : X-,  5 : Z+,  6 : Z-
		myPos = this.transform.position;
		moveDirY = moveDirX = moveDirZ = 0;

		if (newDirection == 1) { PVoverlap = false;
			moveDirY = moveDirY + moveDistance;
			StartCoroutine(MovePosition());
		}
		else if (newDirection == 2) { PVoverlap = false;
			moveDirY = moveDirY - moveDistance;
			StartCoroutine(MovePosition());
		}
		else if (newDirection == 3) { PVoverlap = false;
			moveDirX = moveDirX + moveDistance;
			StartCoroutine(MovePosition());
		}
		else if (newDirection == 4) { PVoverlap = false;
			moveDirX = moveDirX - moveDistance;
			StartCoroutine(MovePosition());
		}
		else if (newDirection == 5) { PVoverlap = false;
			moveDirZ = moveDirZ + moveDistance;
			StartCoroutine(MovePosition());
		}
		else if (newDirection == 6) { PVoverlap = false;
			moveDirZ = moveDirZ - moveDistance;
			StartCoroutine(MovePosition());
		}
	}

	private float percent, activeTime = 0;

	IEnumerator MovePosition() {
		targetPos = new Vector3(myPos.x + moveDirX, myPos.y + moveDirY, myPos.z + moveDirZ);
		while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 3.0f;
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 6.0f * Time.smoothDeltaTime);
            yield return null;
		}
		if (percent >= 1) {
			//CheckRightPosition();
			moveDirX = moveDirY = moveDirZ = 0;
			activeTime = percent = 0;
			this.transform.position = targetPos;
			myPos = this.transform.position;
			PVoverlap = true;
        }
	}

	private int whichAxis; // 1 : y, 2 : z

	//==============================================================
	public void BlockRotateActive(int newRotation) {
        // 1 : Y+,  2 : Y-,  3 : Z+,  4 : Z-

        if (newRotation == 1) { PVoverlap = false; // y로 상정중
            whichAxis = 1;
			targetRotDirY = targetRotDirY + 90.0f;
            //Quaternion.AngleAxis(90, Vector3.right);
            //currentRot = Quaternion.Euler(gripSomething.rotation.x, gripSomething.rotation.y, gripSomething.rotation.z);
            //targetRotDirY.y = targetRotDirY.y + rotAngle;
            StartCoroutine(AxisRotation());
		}
		else if (newRotation == 2) { PVoverlap = false;
			
			StartCoroutine(AxisRotation());
		}
		else if (newRotation == 3) { PVoverlap = false; // z로 상정중
            whichAxis = 2;
            targetRotDirZ = targetRotDirZ + 90.0f;
            //targetRotDirZ = Quaternion.AngleAxis(90, Vector3.forward);
            //targetRotDirZ.z = targetRotDirZ.z + rotAngle;
            StartCoroutine(AxisRotation());
		}
		else if (newRotation == 4) { PVoverlap = false;
			
			StartCoroutine(AxisRotation());
		}
	}

	private float percent2, activeTime2, currtRotY, currtRotZ = 0;

	IEnumerator AxisRotation() {
        //targetRot = new Vector3(0, targetRotDirY, targetRotDirZ); // Quaternion.Euler(0, targetRotDirY, targetRotDirZ);
        //currentRot = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);

        while (percent2 < 1) {
			activeTime2 += Time.smoothDeltaTime;
			percent2 = activeTime2 * 3.0f;
			if (whichAxis == 1) {
				currtRotY = Mathf.Lerp(currtRotY, targetRotDirY, 6.0f * Time.smoothDeltaTime);
				gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, currtRotY, gripPivotY.localRotation.z); }
			else if (whichAxis == 2) {
                currtRotZ = Mathf.Lerp(currtRotZ, targetRotDirZ, 6.0f * Time.smoothDeltaTime);
                cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y, currtRotZ); }
            yield return null;
		}
		if (percent2 >= 1) {
			activeTime2 = percent2 = 0;
            if (whichAxis == 1) { gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, targetRotDirY, gripPivotY.localRotation.z); }
            else if (whichAxis == 2) { cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y, targetRotDirZ); }

            if (currtRotY >= 360.0f) { currtRotY = 0; }
            if (currtRotZ >= 360.0f) { currtRotZ = 0; }
            if (targetRotDirY >= 360.0f) { targetRotDirY = 0; }
            if (targetRotDirZ >= 360.0f) { targetRotDirZ = 0; }
            PVoverlap = true;
        }
	}


	//==============================================================
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

}