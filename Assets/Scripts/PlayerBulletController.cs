using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float bulletSpeed = 2;
    private PlayerController playerController; 
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        if (gameObject.transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerController.AddScore();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
