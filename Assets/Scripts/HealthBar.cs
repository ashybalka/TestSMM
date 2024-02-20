using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject[] HealthPoints;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < HealthPoints.Length; i++) 
        {
            if (i < playerController.healthPoint)
            {
                HealthPoints[i].SetActive(true);
            }
            else
            {
                HealthPoints[i].SetActive(false);
            }
        }
    }
}
