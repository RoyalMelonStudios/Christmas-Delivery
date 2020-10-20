using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    
    public Vector3 bagSpawnPosition = new Vector3(0, 0.5f, -9);
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
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnToys", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(boxPrefab, bagSpawnPosition, boxPrefab.transform.rotation);
        }
        
    }

    public void SpawnToys()
    {
        if (gameManager.isGameActive)
        {
            Vector3 spawnPosition = new Vector3(0, spawnHeight, Random.Range(spawnRangeLeft, spawnRangeRight));
            GameObject toy = toyPrefabs[Random.Range(0, toyPrefabs.Length)];
            Instantiate(toy, spawnPosition, toy.transform.rotation);
        }

    }
    
    
}
