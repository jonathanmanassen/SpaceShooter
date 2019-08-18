using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public static ShipController Instance;

    public bool invincibleDebug = false;
    public float speed = 2f;
    public GameObject missile;
    public GameObject explosionPlayer;
    public GameObject explosionEnemy;
    public GameObject powerUpParticles;

    private float invincibleTime = 0;

    private int PowerLevel = 1;
    private AudioSource Audio;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Instance = this;
    }

	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * Time.deltaTime * speed;

        if (transform.position.y + movement.y > 9.5f ||
            transform.position.y + movement.y < -9.5f)
            movement.y = 0f;
        if (transform.position.x + movement.x > 19f ||
            transform.position.x + movement.x < -19f)
            movement.x = 0f;
        transform.position += movement;

        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            FireBullets();
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.I))
            invincibleDebug = !invincibleDebug;
    }

    void FireBullets()
    {
        Audio.Play();

        Vector3 launcherPos = transform.position + new Vector3(0, 2, 0);
        if (PowerLevel != 2)
        {
            Instantiate(missile, launcherPos, Quaternion.identity);
        }
        if (PowerLevel == 2)
        {
            Instantiate(missile, launcherPos + new Vector3(-0.5f, 0f, 0f), Quaternion.identity);
            Instantiate(missile, launcherPos + new Vector3(0.5f, 0f, 0f), Quaternion.identity);
        }
        if (PowerLevel >= 3)
        {
            Instantiate(missile, launcherPos, Quaternion.Euler(0f, 0f, 15f));
            Instantiate(missile, launcherPos, Quaternion.Euler(0f, 0f, -15f));
        }
    }

    void DecreasePowerLevel()
    {
        if (invincibleTime > Time.time + 1)
            return;
        invincibleTime = Time.time + 1;
        PowerLevel--;
        if (invincibleDebug == true && PowerLevel <= 0)
            PowerLevel = 1;
        if (PowerLevel == 0)
        {
            Instantiate(explosionPlayer, transform.position, Quaternion.identity);
            Destroy(gameObject);
            PauseMenu.instance.PauseGame(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PowerUp"))
        {
            Instantiate(powerUpParticles, col.transform.position, Quaternion.identity);
            if (PowerLevel < 3)
                PowerLevel++;
        }
        else if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Missile") || col.gameObject.CompareTag("Boss"))
        {
            Instantiate(explosionEnemy, transform.position, Quaternion.identity);
            DecreasePowerLevel();
        }
        if (!col.gameObject.CompareTag("Boss"))
            Destroy(col.gameObject);
    }
}
