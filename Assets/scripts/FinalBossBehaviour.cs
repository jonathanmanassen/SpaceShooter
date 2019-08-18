using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBehaviour : MonoBehaviour {

    public GameObject missile;
    public GameObject explosion;
    public RectTransform healthBar;
    public float speed = 7f;
    public int maxHealth = 15;

    private int health;

    private Transform Core;
    private Transform WeakPoints;

    Vector3 destination;
    bool arrivedAtDest = false;

    int weakPointsHit = 0;

    float CoreActivationTime = 0;

    int index = 0;
    float time;
    float timeBeforeNextFiring;

    float startPlayingTime;

    Vector3[] moving = { new Vector3(-2, 0, 0), new Vector3(0, 1, 0), new Vector3(2, 0, 0), new Vector3(0, -1, 0),
                         new Vector3(-2, 0.5f, 0), new Vector3(0, -1, 0), new Vector3(2, 0.5f, 0), new Vector3(0, -1, 0)};

    // Use this for initialization
    void Start ()
    {
        GameObject dest = GameObject.Find("bossDest");
        destination = dest.transform.position;
        Destroy(dest);
        Core = transform.Find("Core");
        WeakPoints = transform.Find("WeakPoints");
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (arrivedAtDest == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, destination) < 0.1f)
            {
                arrivedAtDest = true;
                time = Time.time - 1f;
                timeBeforeNextFiring = Time.time + Random.Range(0.5f, 2f);
                WeakPoints.gameObject.SetActive(true);
                startPlayingTime = Time.time;
            }
        }
        else
        {
            if (Time.time > time + ((index % 2 == 0) ? 2 : 1))
            {
                index = (index + 1) % moving.Length;
                time = Time.time;
            }
            transform.position += moving[index] * Time.deltaTime * speed;
            if (transform.position.y < destination.y)
                transform.position = new Vector3(transform.position.x, destination.y, 0);

            if (CoreActivationTime != 0 && Time.time > CoreActivationTime + 4f)
            {
                CoreActivationTime = 0;
                WeakPoints.gameObject.SetActive(true);
                Core.gameObject.SetActive(false);
            }

            if (Time.time > timeBeforeNextFiring)
                Shoot();
        }
    }

    void Shoot()
    {
        timeBeforeNextFiring = Time.time + Random.Range(0.5f, 2f);
        if (ShipController.Instance == null)
            return;
        Vector3 dir = ShipController.Instance.transform.position - transform.position;
        dir = ShipController.Instance.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Instantiate(missile, transform.position, Quaternion.Euler(0, 0, angle));
    }

    public void PartHit(bool core)
    {
        if (core == false)
        {
            weakPointsHit++;
            if (weakPointsHit >= 2)
            {
                weakPointsHit = 0;
                for (int i = 0; i < WeakPoints.childCount; i++)
                {
                    WeakPoints.GetChild(i).gameObject.SetActive(true);
                }
                WeakPoints.gameObject.SetActive(false);
                Core.gameObject.SetActive(true);
                CoreActivationTime = Time.time;
            }
        }
        else
        {
            health--;
            healthBar.sizeDelta = new Vector2(health * (2.5f / maxHealth), healthBar.sizeDelta.y);
            if (health == 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, Quaternion.identity);
                ScoreManager.Instance.ChangeScore(20000 / (int)(Time.time - startPlayingTime));
                PauseMenu.instance.timeBeforeEnd = Time.time + 2f;
            }
        }
    }
}