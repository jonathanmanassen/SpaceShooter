using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColliderOnEntrance : MonoBehaviour {

    void OnBecameVisible()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}