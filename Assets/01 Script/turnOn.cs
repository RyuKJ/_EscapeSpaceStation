using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOn : MonoBehaviour {

    public GameObject cubeResult;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == ("GrabObj"))
        {
            cubeResult.SetActive(true);
            Destroy(coll.gameObject);
        }

    }

}