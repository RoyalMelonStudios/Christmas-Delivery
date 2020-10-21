using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverOverlay;

    public bool isGameActive = false;
    
    private int score;
    
    public Vector3 boxSpawnPosition = new Vector3(0, 0.5f, -12);
    public float spawnRangeLeft = -6f;
    public float spawnRangeRight = 9.5f;
    private float spawnHeight = 9;

    public float startDelay = 2;
    public float spawnInterval = 3;
    public float spawnIntervalRatioLowerBound = 0.95f;
    public float spawnIntervalRatioUpperBound = 0.99f;

    public GameObject[] boxPrefabs;
    public GameObject[] toyPrefabs;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnToys());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive && Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(boxPrefabs[0], boxSpawnPosition, boxPrefabs[0].transform.rotation);
        }
        else if (isGameActive && Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(boxPrefabs[1], boxSpawnPosition, boxPrefabs[1].transform.rotation);
        }
        else if (isGameActive && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(boxPrefabs[2], boxSpawnPosition, boxPrefabs[2].transform.rotation);
        }
    }
    
    IEnumerator SpawnToys()
    {
        while (isGameActive)
        {
            SpawnRandomToy();
            yield return new WaitForSeconds(spawnInterval);
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      //  isGameActive = true;
      //  score = 0;
      //  UpdateScore(0);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverOverlay.SetActive(true);
    }
    
}
