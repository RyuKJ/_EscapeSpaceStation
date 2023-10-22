using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

    public static testScript Instance;
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

        if (Input.GetKeyDown(KeyCode.Q) && PVoverlap) { PVoverlap = false; mc.BlockRotateActive(1); } //Y-
        if (Input.GetKeyDown(KeyCode.W) && PVoverlap) { PVoverlap = false; mc.BlockRotateActive(2); } //Y+
        if (Input.GetKeyDown(KeyCode.O) && PVoverlap) { PVoverlap = false; mc.BlockRotateActive(3); } //Z-
        if (Input.GetKeyDown(KeyCode.P) && PVoverlap) { PVoverlap = false; mc.BlockRotateActive(4); } //Z+

        if (Input.GetKeyDown(KeyCode.G) && PVoverlap) { PVoverlap = false; mc.DetachAttachModule(); } //grab

        if (Input.GetKeyDown(KeyCode.LeftArrow) && PVoverlap) { PVoverlap = false; gp.GetDirection(4); }
        if (Input.GetKeyDown(KeyCode.RightArrow) && PVoverlap) { PVoverlap = false; gp.GetDirection(3); }
        if (Input.GetKeyDown(KeyCode.UpArrow) && PVoverlap) { PVoverlap = false; gp.GetDirection(5); }
        if (Input.GetKeyDown(KeyCode.DownArrow) && PVoverlap) { PVoverlap = false; gp.GetDirection(6); }
        if (Input.GetKeyDown(KeyCode.A) && PVoverlap) { PVoverlap = false; gp.GetDirection(1); } //up
        if (Input.GetKeyDown(KeyCode.Z) && PVoverlap) { PVoverlap = false; gp.GetDirection(2); } //down
    }
}