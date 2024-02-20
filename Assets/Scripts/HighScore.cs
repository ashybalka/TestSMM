using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System;

public class HighScore : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] Image planeBG;
    [SerializeField] TMP_Text bestText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text againText;

    // Start is called before the first frame update
    void Awake()
    {
        SerializibleScore score = new SerializibleScore();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        string fileResPath = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(fileResPath))
        {
            score = JsonUtility.FromJson<SerializibleScore>(File.ReadAllText(fileResPath));
        }
        else
        {
            score.highScore = 0;
        }


        if (playerController.score > score.highScore)
        {
            score.highScore = playerController.score;
            string SaveData = JsonUtility.ToJson(score);
            File.WriteAllText(fileResPath, SaveData);
            planeBG.sprite = Resources.Load<Sprite>("text_box02");
            againText.text = "new best score!";
        }
        else 
        {
            planeBG.sprite = Resources.Load<Sprite>("text_box01");
            againText.text = "plane crushed!";
        }

        bestText.text = score.highScore.ToString();
        scoreText.text = playerController.score.ToString();
    }
}

[Serializable]
public class SerializibleScore
{ 
    public int highScore;
}
