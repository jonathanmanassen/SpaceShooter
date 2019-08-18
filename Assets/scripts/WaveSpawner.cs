using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public GameObject[] enemyWave;
    public GameObject boss;

    moveBackgrounds bg;

    float timer;
    float totalTime;

    bool bossSequence = false;


    void Start()
    {
        bg = GameObject.Find("backGround").GetComponent<moveBackgrounds>();
        timer = Time.time - 5;
        totalTime = Time.time;
    }

    float initSpeed;

    void Update()
    {
        float time = Time.time;

        if (bossSequence == true)
        {
            if (time < timer + 3)
            {
                bg.speed = initSpeed * ((3f - (time - timer)) / 3f);
            }
            else
            {
                bg.speed = 0;
                Instantiate(boss, transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
        else
        {
            if (time > totalTime + 30 && time > timer + 5)
            {
                bossSequence = true;
                timer = Time.time;
                initSpeed = bg.speed;
            }
            if (time > timer + 5 && time <= totalTime + 30)
            {
                int random = Random.Range(0, enemyWave.Length);

                Instantiate(enemyWave[random], transform.position, Quaternion.identity);
                timer = Time.time;
            }
        }
    }
}
