using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalEnemy : MonoBehaviour {
    public GameObject missile;

    int frame;
    float randomMove;
    float randomShoot;

    bool move = false;
    bool canShoot = true;
	
	void Start ()
    {
        randomMove = Random.Range(0.026f, 0.034f);
        randomShoot = Random.Range(0.2f, 2f);
        frame = Mathf.FloorToInt((Mathf.PI / 2f) / randomMove);
	}
	
	void Update () {
        if (Time.timeScale == 0)
            return;
        if (move == true)
        {
            transform.position = new Vector3(16f * Mathf.Sin(frame * randomMove), transform.position.y, 0);
            frame++;
            if (canShoot == true)
            {
                randomShoot -= Time.deltaTime;
                if (randomShoot < 0)
                    Shoot();
            }
        }
    }

    void Shoot()
    {
        canShoot = false;
        if (ShipController.Instance == null)
            return;
        Vector3 dir = ShipController.Instance.transform.position - transform.position;
        dir = ShipController.Instance.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Instantiate(missile, transform.position, Quaternion.Euler(0, 0, angle));
    }

    void OnBecameVisible()
    {
        move = true;
    }
}
