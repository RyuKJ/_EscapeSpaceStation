using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOn : MonoBehaviour {

    // 이게 뭐하는 스크립트지??

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