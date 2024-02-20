using System;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bulletprefab;
    private float attackSpeed = 1f;
    private float nextFire;

    public int score { get; private set; } = 0;
    [SerializeField] TMP_Text scoreText;
    private GameObject bulletPool;

    public bool isDead { get; private set; }
    public int healthPoint { get; private set; } = 12;
    void Start()
    {
        bulletPool = GameObject.Find("BulletPool");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (Time.time > nextFire && !isDead)
        {
            GameObject bullet = Instantiate(bulletprefab, gameObject.transform);
            bullet.transform.SetParent(bulletPool.transform);
            nextFire = Time.time + attackSpeed;
        }

        if (gameObject.transform.position.x > 2f)
        {
            gameObject.transform.position = new Vector3(2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x < -2f)
        {
            gameObject.transform.position = new Vector3(-2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

    }

    public void AddScore()
    {
        score += 10;
    }

    public void Damage()
    {
        healthPoint--;
        if (healthPoint <= 0)
        {
            isDead = true;
        }
    }

    public void Regen(int amount)
    {
        healthPoint += amount;
        if (healthPoint > 12 ) 
        { 
            healthPoint = 12;
        }
    }
}
