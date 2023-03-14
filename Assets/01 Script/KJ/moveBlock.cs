using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlock : MonoBehaviour {

	//public int cubeName;
	public GameObject myTag;
	private float moveDistance = 3.0f;
	private float moveDirX = 0;
	private float moveDirY = 0;
	private float moveDirZ = 0;
	private Vector3 TargetPosition, myPosition;
	private bool PVoverlap = true;

	//=======================
	private bool myTerritory;

	void Start() { myTag.SetActive(false); }

	public void ShowMyName (bool on) { if (on) { myTag.SetActive(true); } else { myTag.SetActive(false); } }

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
		myPosition = this.transform.position;

		if (newDirection == 1) { PVoverlap = false;
			moveDirY = moveDirY + moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
		else if (newDirection == 2) { PVoverlap = false;
			moveDirY = moveDirY - moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
		else if (newDirection == 3) { PVoverlap = false;
			moveDirX = moveDirX + moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
		else if (newDirection == 4) { PVoverlap = false;
			moveDirX = moveDirX - moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
		else if (newDirection == 5) { PVoverlap = false;
			moveDirZ = moveDirZ + moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
		else if (newDirection == 6) { PVoverlap = false;
			moveDirZ = moveDirZ - moveDistance;
			StartCoroutine(MovePosition());
			newDirection = 0;
		}
	}

	private float percent, activeTime = 0;

	IEnumerator MovePosition() {
		TargetPosition = new Vector3(myPosition.x + moveDirX, myPosition.y + moveDirY, myPosition.z + moveDirZ);
		while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 10.0f;
			this.transform.position = Vector3.Lerp(this.transform.position, TargetPosition, 7.0f * Time.smoothDeltaTime);
			yield return null;
		}
		if (percent >= 1) {
			//CheckRightPosition();
			moveDirX = moveDirY = moveDirZ = 0;
			activeTime = percent = 0;
			this.transform.position = TargetPosition;
			myPosition = this.transform.position;
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