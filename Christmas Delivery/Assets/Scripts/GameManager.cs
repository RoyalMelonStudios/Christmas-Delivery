using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public bool isGameActive = false;
    private int score;
    
    public Vector3 boxSpawnPosition = new Vector3(0, 0.5f, -9);
    public GameObject boxPrefab;

    public float startDelay = 2;
    public float spawnInterval = 3;

    public GameObject[] toyPrefabs;
    public float spawnRangeLeft = -3.5f;
    public float spawnRangeRight = 9.5f;
    private float spawnHeight = 9;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(boxPrefab, boxSpawnPosition, boxPrefab.transform.rotation);
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
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void RestartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnToys());
        score = 0;
        UpdateScore(0);
    }
    
}
