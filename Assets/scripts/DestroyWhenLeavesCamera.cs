using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenLeavesCamera : MonoBehaviour {
    public bool parent = false;

    void OnBecameInvisible()
    {
        if (parent != false)
            Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
