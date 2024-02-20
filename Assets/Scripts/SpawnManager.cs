using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject smallAid;
    [SerializeField] GameObject largeAid;
    private float enemySpawnSpeed = 2.5f;
    private float nextEnemy;
    private float nextSmallAid = 15f;
    private float nextLargeAid = 45f;

    private Vector3 nextSpawnPoint;
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SmallAid());
        StartCoroutine(LargeAid());
        StartCoroutine(Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!playerController.isDead)
        {
            if (Time.time > nextEnemy)
            {
                nextSpawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y, transform.position.z);
                Instantiate(enemyPrefab, nextSpawnPoint, enemyPrefab.transform.rotation);
                nextEnemy = Time.time + enemySpawnSpeed;
            }
            if (Time.time > nextSmallAid)
            {
                Instantiate(smallAid, nextSpawnPoint, smallAid.transform.rotation);
                nextSpawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y, transform.position.z);
                nextSmallAid = Time.time + Random.Range(15, 30);
            }
            if (Time.time > nextLargeAid)
            {
                Instantiate(largeAid, nextSpawnPoint, largeAid.transform.rotation);
                nextSpawnPoint = new Vector3(Random.Range(-2.3f, 2.3f), transform.position.y, transform.position.z);
                nextLargeAid = Time.time + Random.Range(45, 120);
            }
        }
        */
    }

    IEnumerator SmallAid()
    {
        yield return new WaitForSeconds(Random.Range(15, 30));
        if (!playerController.isDead)
        {
            Instantiate(smallAid, nextSpawnPoint, smallAid.transform.rotation);
            nextSpawnPoint = new Vector3(Random.Range(-2f, 2f), transform.position.y, transform.position.z);
            
        }
        StartCoroutine(SmallAid());
    }
    IEnumerator LargeAid()
    {
        yield return new WaitForSeconds(Random.Range(45, 120));
        if (!playerController.isDead)
        {
            Instantiate(largeAid, nextSpawnPoint, largeAid.transform.rotation);
            nextSpawnPoint = new Vector3(Random.Range(-2f, 2f), transform.position.y, transform.position.z);
        }
        StartCoroutine(LargeAid());
    }
    IEnumerator Enemy()
    {
        yield return new WaitForSeconds(2f);
        if (!playerController.isDead)
        {
            nextSpawnPoint = new Vector3(Random.Range(-2f, 2f), transform.position.y, transform.position.z);
            Instantiate(enemyPrefab, nextSpawnPoint, enemyPrefab.transform.rotation);
        }
        StartCoroutine(Enemy());
    }
}
