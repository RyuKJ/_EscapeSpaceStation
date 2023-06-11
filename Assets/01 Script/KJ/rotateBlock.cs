using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBlock : MonoBehaviour {

    private float angle = 90.0f;


    //==============================================================
    private float targetRotDirY, targetRotDirZ, currtRotY, currtRotZ;

	public void RotateMyself(int dir) {
        // 1 : Y+,  2 : Y-
        if (dir == 1) {
            targetRotDirY = targetRotDirY - 90.0f;
            StartCoroutine(AxisRotation());
        }
        else if (dir == 2) {
            targetRotDirY = targetRotDirY + 90.0f;
            StartCoroutine(AxisRotation());
        }
	}

	private float percent, activeTime;

	IEnumerator AxisRotation() {
        while (percent < 1) {
			activeTime += Time.smoothDeltaTime;
			percent = activeTime * 2.5f;

			currtRotY = Mathf.Lerp(currtRotY, targetRotDirY, 5.0f * (1 + percent) * Time.smoothDeltaTime);
            this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, currtRotY, this.transform.localRotation.z);
            yield return null;
		}
		if (percent >= 1) { activeTime = percent = 0;

            this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, targetRotDirY, this.transform.localRotation.z);

            if (currtRotY >= 269.9f || currtRotY <= -269.9f) { currtRotY = targetRotDirY = 0; Debug.Log("rot Y calibrated");
                this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, 0, this.transform.localRotation.z); }
            testScript.Instance.PVoverlap = true;
        }
	}

    public void AxisZRotation(float angle) {
        this.transform.localRotation = Quaternion.Euler(this.transform.localRotation.x, this.transform.localRotation.y + 90, angle);
    }

}