using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehaviour : MonoBehaviour {

    float var = 0f;
    float time;

    void Start()
    {
        transform.position -= new Vector3(0, 1, 0);
        time = Time.time + 10;
    }

	void Update () {
        var += 2f;
        transform.rotation = Quaternion.Euler(0, var, var);
        if (Time.time > time)
            Destroy(gameObject);
	}
}
