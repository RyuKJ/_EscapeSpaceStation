using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    public static testScript Instance;
    //public int currentSelectCubeNumber;
    public bool PVoverlap = true;
    public moveCrane mc;
    public GridPosition gp;

    void Awake() { if (Instance == null) { Instance = this; } }

    internal static class YieldInstructionCache {
        public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
        private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new Dictionary<float, WaitForSeconds>();

        public static WaitForSeconds WaitForSeconds(float seconds) {
            WaitForSeconds wfs;
            if (!waitForSeconds.TryGetValue(seconds, out wfs))
                waitForSeconds.Add(seconds, wfs = new WaitForSeconds(seconds));
            return wfs;
        }
    }

    void Update() {

        if (PVoverlap == true) {
            if (Input.GetKeyDown(KeyCode.Q)) { mc.BlockRotateActive(1); }
            if (Input.GetKeyDown(KeyCode.W)) { mc.BlockRotateActive(3); }
            if (Input.GetKeyDown(KeyCode.E)) { mc.DetachAttachModule(); }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { gp.GetDirection(4); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { gp.GetDirection(3); }
            if (Input.GetKeyDown(KeyCode.UpArrow)) { gp.GetDirection(5); }
            if (Input.GetKeyDown(KeyCode.DownArrow)) { gp.GetDirection(6); }
            if (Input.GetKeyDown(KeyCode.A)) { gp.GetDirection(1); }
            if (Input.GetKeyDown(KeyCode.Z)) { gp.GetDirection(2); }
        }

    }

}