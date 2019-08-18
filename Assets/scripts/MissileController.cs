using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
	public float speed;

    public GameObject EnemyExplosion;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            EnemyController tmp;
            if (tmp = col.gameObject.transform.parent.GetComponent<EnemyController>())
                tmp.ShipDestroyed(col.transform.position, col.transform.name);
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}
