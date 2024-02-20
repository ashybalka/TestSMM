using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private float bulletSpeed = 1.5f;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
        if (gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Damage();
            Destroy(gameObject);
        }
    }
}
