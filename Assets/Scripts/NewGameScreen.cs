using UnityEngine;

public class NewGameScreen : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] GameObject HighScore; 
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.isDead)
        {
            HighScore.SetActive(true);
        }
        else
        {
            HighScore.SetActive(false);
        }
    }
}
