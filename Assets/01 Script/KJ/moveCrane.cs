using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrane : MonoBehaviour {

	public Transform pivotY, pivoyZ;
	//public int cubeName;
	//public GameObject myTag;
	private float moveDistance = 3.0f;
	private float rotAngle = 90f;
	private float moveDirX, moveDirY, moveDirZ, rotDirY, rotDirZ = 0;
	public Vector3 targetPos, myPos, targetRot;
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


	//==============================================================
	public void BlockRotateActive(int newRotation) {
		// 1 : Y+,  2 : Y-,  3 : Z+,  4 : Z-
		rotDirY = rotDirZ = 0;
		if (newRotation == 1) { PVoverlap = false;
			rotDirY = rotDirY + rotAngle;
			StartCoroutine(MoveRotation());
		}
		else if (newRotation == 2) { PVoverlap = false;
			//moveDirY = moveDirY - moveDistance;
			StartCoroutine(MoveRotation());
		}
		else if (newRotation == 3) { PVoverlap = false;
			rotDirZ = rotDirZ + rotAngle;
			StartCoroutine(MoveRotation());
		}
		else if (newRotation == 4) { PVoverlap = false;
			//moveDirX = moveDirX - moveDistance;
			StartCoroutine(MoveRotation());
		}
	}

	private float percent2, activeTime2 = 0;

	IEnumerator MoveRotation() {
		targetRot = new Vector3(0, rotDirY, rotDirZ); // Quaternion.Euler(0, rotDirY, rotDirZ);

        while (percent2 < 1) {
			activeTime2 += Time.smoothDeltaTime;
			percent2 = activeTime2 * 3.0f;
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(targetRot), 6.0f * Time.smoothDeltaTime);
			yield return null;
		}
		if (percent2 >= 1) {
            rotDirY = rotDirZ = 0;
			activeTime2 = percent2 = 0;
			this.transform.rotation = Quaternion.Euler(targetRot);
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