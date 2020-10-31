using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverOverlay;

    public bool isGameActive = false;
    
    private int score;
    
    public Vector3 boxSpawnPosition = new Vector3(0, 0.5f, -12);
    public float spawnRangeLeft = -6f;
    public float spawnRangeRight = 9.5f;
    public float spawnHeight = 10.5f;

    public float startDelay = 1;
    public float spawnInterval = 3;
    public float spawnIntervalRatioLowerBound = 0.95f;
    public float spawnIntervalRatioUpperBound = 0.99f;

    public GameObject[] boxPrefabs;
    public GameObject[] toyPrefabs;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore", 0);
        StartCoroutine(SpawnToys());
    }
 
 /*   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBox1();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnBox2();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnBox3();
    
        }
    }
*/    
    IEnumerator SpawnToys()
    {
        yield return new WaitForSeconds(startDelay);
        while (isGameActive)
        {
            SpawnRandomToy();
            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    public void SpawnBox1()
    {
        if (isGameActive)
        {
            FindObjectOfType<AudioManager>().Play("Spawn SFX");
            Instantiate(boxPrefabs[0], boxSpawnPosition, boxPrefabs[0].transform.rotation);
        }
    }
    
    public void SpawnBox2()
    {
        if (isGameActive)
        {
            FindObjectOfType<AudioManager>().Play("Spawn SFX");
            Instantiate(boxPrefabs[1], boxSpawnPosition, boxPrefabs[1].transform.rotation);
        }
    }
    
    public void SpawnBox3()
    {
        if (isGameActive)
        {
            FindObjectOfType<AudioManager>().Play("Spawn SFX");
            Instantiate(boxPrefabs[2], boxSpawnPosition, boxPrefabs[2].transform.rotation);
        }
    }
    
    public void SpawnRandomToy()
    {
        if (isGameActive)
        {
            Vector3 spawnPosition = new Vector3(0, spawnHeight, Random.Range(spawnRangeLeft, spawnRangeRight));
            GameObject toy = toyPrefabs[Random.Range(0, toyPrefabs.Length)];
            Instantiate(toy, spawnPosition, toy.transform.rotation);
            spawnInterval *= Random.Range(spawnIntervalRatioLowerBound, spawnIntervalRatioUpperBound);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            highScoreText.text = "Best: " + score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      //  isGameActive = true;
      //  score = 0;
      //  UpdateScore(0);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GameOver()
    {
        SetHighScore(score);
        
        isGameActive = false;
        gameOverOverlay.SetActive(true);
    }

    void SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void IncreasePresentsPackaged(int i)
    {
        PlayerPrefs.SetInt("PresentsPackaged", PlayerPrefs.GetInt("PresentsPackaged", 0) + i);
    }
    
    public void IncreaseToysBroken(int i)
    {
        PlayerPrefs.SetInt("ToysBroken", PlayerPrefs.GetInt("ToysBroken", 0) + i);
    }
    
    public void IncreaseEmptyPresents(int i)
    {
        PlayerPrefs.SetInt("EmptyPresents", PlayerPrefs.GetInt("EmptyPresents", 0) + i);
    }
    
    public void IncreaseMismatchedPresents(int i)
    {
        PlayerPrefs.SetInt("MismatchedPresents", PlayerPrefs.GetInt("MismatchedPresents", 0) + i);
    }

}
