using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemySpeed = 0.5f;
    [SerializeField] GameObject bulletprefab;
    private float attackSpeed = 5f;
    private float nextFire = 2f;
    private GameObject bulletPool;
    private PlayerController playerController;

    void Start()
    {
        bulletPool = GameObject.Find("BulletPool");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
        if (gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
        }

        if (Time.time > nextFire)
        {
            GameObject bullet = Instantiate(bulletprefab, gameObject.transform);
            bullet.transform.SetParent(bulletPool.transform);
            nextFire = Time.time + attackSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.Damage();
        }
    }
}
