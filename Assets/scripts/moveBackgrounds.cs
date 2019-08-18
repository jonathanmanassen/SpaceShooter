using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackgrounds : MonoBehaviour {

    public Transform Higher;
    public Transform Lower;
    [Range(0f, 7f)]
    public float speed = 0.1f;

    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

	void Update ()
    {
        if (speed > 7f)
            speed = 7f;
        if (speed < 0f)
            speed = 0f;
        Vector3 move = new Vector3(0f, 0.1f * -speed, 0f);
        Lower.transform.localPosition += move;
        Higher.transform.localPosition += move;
		if (Lower.localPosition.y < -8)
        {
            Transform tmp;
            Lower.transform.localPosition += new Vector3(0f, 20f, 0f);
            tmp = Higher;
            Higher = Lower;
            Lower = tmp;
        }
	}
}
