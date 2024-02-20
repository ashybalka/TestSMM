using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Again()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    { 
        Application.Quit();
    }
}
