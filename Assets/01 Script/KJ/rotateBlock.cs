using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlock : MonoBehaviour {

    private float angle = 90.0f;


    //==============================================================
    private float targetRotDirY, targetRotDirZ, currtRotY, currtRotZ;

    private int whichAxis; // 1 : y, 2 : z

	public void RotateMyself(int dir) {
        // 1 : Y+,  2 : Y-,  3 : Z+,  4 : Z-
        if (dir == 1) { // y로 상정중
            whichAxis = 1;
            targetRotDirY = targetRotDirY - 90.0f;
            StartCoroutine(AxisRotation());
        }
        else if (dir == 2) {
            whichAxis = 1;
            StartCoroutine(AxisRotation());
        }
        else if (dir == 3) {  // z로 상정중
            whichAxis = 2;
            targetRotDirZ = targetRotDirZ - 90.0f;
            StartCoroutine(AxisRotation());
        }
        else if (dir == 4) {
            whichAxis = 2;
            StartCoroutine(AxisRotation());
        }
	}

	private float percent, activeTime;

	IEnumerator AxisRotation() {
        while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 2.5f;

			if (whichAxis == 1) {
				currtRotY = Mathf.Lerp(currtRotY, targetRotDirY, 5.0f * (1 + percent) * Time.smoothDeltaTime);
                this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, currtRotY, this.transform.localRotation.z); }
			else if (whichAxis == 2) {
                currtRotZ = Mathf.Lerp(currtRotZ, targetRotDirZ, 5.0f * (1 + percent) * Time.smoothDeltaTime);
                this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y + 90, currtRotZ); }
            yield return null;
		}
		if (percent >= 1) { activeTime = percent = 0;

				 if (whichAxis == 1) { this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, targetRotDirY, this.transform.localRotation.z); }
            else if (whichAxis == 2) { this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y + 90, targetRotDirZ); }

            if (currtRotY >= 269.9f || currtRotY <= -269.9f) { currtRotY = targetRotDirY = 0; Debug.Log("rot Y calibrated");
                this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, 0, this.transform.localRotation.z); }
            if (currtRotZ >= 269.9f || currtRotZ <= -269.9f) { currtRotZ = targetRotDirZ = 0; Debug.Log("rot Z calibrated");
                this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y + 90, 0);
            }
            testScript.Instance.PVoverlap = true;
        }
	}



}