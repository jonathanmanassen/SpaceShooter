using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellTeleporter : MonoBehaviour {
    public int teleportations = 3;

    void OnBecameInvisible()
    {
        if (teleportations == 0 || GameManager.instance.bulletHell == false)
        {
            Destroy(transform.parent.gameObject);
            return;
        }

        if (transform.parent.position.y < -11 || transform.parent.position.y > 11)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y * -1, 0);
        }
        if (transform.parent.position.x < -19.5f || transform.parent.position.x > 19.5f)
        {
            transform.parent.position = new Vector3(transform.parent.position.x * -1, transform.parent.position.y, 0);
        }
        teleportations--;
    }
}
