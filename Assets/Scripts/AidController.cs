using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidController : MonoBehaviour
{
    private float aidSpeed = 0.4f;
    private PlayerController playerController;
    private void Start()
    {
        playerController= GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * aidSpeed * Time.deltaTime);
        if (gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("SmallAid"))
            {
                playerController.Regen(2);
            }
            else if (gameObject.CompareTag("LargeAid"))
            {
                playerController.Regen(12);
            }
            Destroy(gameObject);
        }    
    }
}
