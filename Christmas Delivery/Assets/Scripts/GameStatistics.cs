using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    public int highScore;
    public int presentsPackaged;
    public int toysBroken;
    public int emptyPresents;
    public int mismatchedPresents;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI presentsPackagedText;
    public TextMeshProUGUI toysBrokenText;
    public TextMeshProUGUI emptyPresentsText;
    public TextMeshProUGUI mismatchedPresentsText;

    // Start is called before the first frame update
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        presentsPackaged = PlayerPrefs.GetInt("PresentsPackaged", 0);
        toysBroken = PlayerPrefs.GetInt("ToysBroken", 0);
        emptyPresents = PlayerPrefs.GetInt("EmptyPresents", 0);
        mismatchedPresents = PlayerPrefs.GetInt("MismatchedPresents", 0);

        highScoreText.text = "High Score: " + highScore;
        presentsPackagedText.text = "Presents Packaged: " + presentsPackaged;
        toysBrokenText.text = "Toys Broken: " + toysBroken;
        emptyPresentsText.text = "Empty Presents Sent: " + emptyPresents;
        mismatchedPresentsText.text = "Mismatched Presents: " + mismatchedPresents;
    }

    public void ResetStatistics()
    {
        PlayerPrefs.DeleteAll();
        highScoreText.text = "High Score: 0";
        presentsPackagedText.text = "Presents Packaged: 0";
        toysBrokenText.text = "Toys Broken: 0";
        emptyPresentsText.text = "Empty Presents Sent: 0";
        mismatchedPresentsText.text = "Mismatched Presents: 0";
        
    }
    
    
}
