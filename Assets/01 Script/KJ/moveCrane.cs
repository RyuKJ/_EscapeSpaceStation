using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrane : MonoBehaviour {

	public Transform gripPivotY, cranePivotZ, detachSpot, sensorPos;
    private bool PVoverlap = true;

    private float moveDirX, moveDirY, moveDirZ, targetRotDirY, targetRotDirZ, currtRotY, currtRotZ;
    private float moveDistance = 3.0f;
	private float rotAngle = 90f;
    private Vector3 targetPos, myPos;


    //=======================
    //void Start() { myTag.SetActive(false); }

    //public void ShowMyName (bool on) { if (on) { myTag.SetActive(true); } else { myTag.SetActive(false); } }

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


	//==============================================================
	public void BlockMoveActive(int newDirection) {
		// 1 : Y+,  2 : Y-,  3 : X+,  4 : X-,  5 : Z+,  6 : Z-
		myPos = this.transform.position;
		moveDirY = moveDirX = moveDirZ = 0;

		if (PVoverlap) {
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
	            //targetRotDirZ = Quaternion.AngleAxis(90, Vector3.forward);
		        //targetRotDirZ.z = targetRotDirZ.z + rotAngle;
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
		if (percent2 >= 1) {
			activeTime2 = percent2 = 0;

				 if (whichAxis == 1) { gripPivotY.localRotation = Quaternion.Euler(gripPivotY.localRotation.x, targetRotDirY, gripPivotY.localRotation.z); }
            else if (whichAxis == 2) { cranePivotZ.localRotation = Quaternion.Euler(cranePivotZ.localRotation.x, cranePivotZ.localRotation.y + 90, targetRotDirZ); }

	        //     if (whichAxis == 1) { gripPivotY.localRotation = Quaternion.Euler(adjustX, targetRotDirY, adjustZ); }
            //else if (whichAxis == 2) { cranePivotZ.localRotation = Quaternion.Euler(adjustX, adjustY + 90, targetRotDirZ); }


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



	public float adjustX, adjustY, adjustZ;

    public void PreciseRotation() {
		Debug.Log("AAA : " + gripPivotY.localRotation.x);
			 if (gripPivotY.localRotation.x > 0 && gripPivotY.localRotation.x < 45) { adjustX = 0; }
        else if (gripPivotY.localRotation.x > 45 && gripPivotY.localRotation.x < 90) { adjustX = 90; }
        else if (gripPivotY.localRotation.x > 90 && gripPivotY.localRotation.x < 135) { adjustX = 90; }
        else if (gripPivotY.localRotation.x > 135 && gripPivotY.localRotation.x < 180) { adjustX = 180; }
        else if (gripPivotY.localRotation.x > 180 && gripPivotY.localRotation.x < 225) { adjustX = 180; }
        else if (gripPivotY.localRotation.x > 225 && gripPivotY.localRotation.x < 270) { adjustX = 270; }
        else if (gripPivotY.localRotation.x > 270 && gripPivotY.localRotation.x < 315) { adjustX = 270; }
        else if (gripPivotY.localRotation.x > 315 && gripPivotY.localRotation.x < 360) { adjustX = 0; }
		else if (gripPivotY.localRotation.x >= 360) { adjustX = 0; }
        Debug.Log("BBB : " + gripPivotY.localRotation.x);
    }



    private bool holding;
    //private int layerMask = 1 << 8;
    private float detectLine = 0.5f;
    private RaycastHit hitSensor;

    public void DetachAttachModule() {
		Debug.DrawRay(sensorPos.position, sensorPos.forward * detectLine, Color.red, 0.5f);
        if (Physics.Raycast(sensorPos.position, sensorPos.forward, out hitSensor, detectLine)) {
			if (!hitSensor.collider.CompareTag("Modules")) return;

			if (!holding && hitSensor.collider.CompareTag("Modules")) { holding = true;
                Debug.Log("attach");
                hitSensor.collider.gameObject.transform.parent.parent = gripPivotY;
            }
			else if (holding && hitSensor.collider.CompareTag("Modules")) { holding = false;
				Debug.Log("detach");
                gripPivotY.GetChild(0).gameObject.transform.parent = detachSpot;
            }
		}
	}

    //private void OnTriggerStay(Collider other) { }
    //void CheckGrapOrNot() { }


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