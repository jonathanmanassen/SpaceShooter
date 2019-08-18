using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public int ScoreToAdd;
    public GameObject PowerUp;

    int shipsDestroyed = 0;
    List<string> destroyed = new List<string>();

    void Update()
    {
        if (transform.childCount == 0)
            Destroy(gameObject);
        transform.position += new Vector3(0, -1f * Time.deltaTime * speed, 0);
    }

    public void ShipDestroyed(Vector3 position, string name)
    {
        if (destroyed.Contains(name))
            return;
        destroyed.Add(name);
        shipsDestroyed++;
        ScoreManager.Instance.ChangeScore(ScoreToAdd);
        if (shipsDestroyed == 5)
        {
            ScoreManager.Instance.ChangeScore(ScoreToAdd * 5);
            Instantiate(PowerUp, position, Quaternion.identity);
        }
    }
}