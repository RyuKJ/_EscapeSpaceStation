using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactSensor : MonoBehaviour {

    public string contactName;
    private float detectLine = 0.5f;
    private RaycastHit hitSensor;

    public void GetContactModulePivot() {
        Debug.DrawRay(this.transform.position, this.transform.forward * detectLine, UnityEngine.Color.red, 0.5f);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitSensor, detectLine)) {
            if (hitSensor.collider.CompareTag("Modules")) {
                contactName = hitSensor.collider.gameObject.name;
            }
        }
    }
}