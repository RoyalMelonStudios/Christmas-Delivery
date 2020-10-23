using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    public int highScore;
    public int presentsPackaged;
    public int toysBroken;
    public int emptyPresents;
    public int mismatchedPresents;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        presentsPackaged = PlayerPrefs.GetInt("PresentsPackaged", 0);
        toysBroken = PlayerPrefs.GetInt("ToysBroken", 0);
        emptyPresents = PlayerPrefs.GetInt("EmptyPresents", 0);
        mismatchedPresents = PlayerPrefs.GetInt("MismatchedPresents", 0);
    }
}
