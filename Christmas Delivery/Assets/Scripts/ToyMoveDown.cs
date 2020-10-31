using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMoveDown : MonoBehaviour
{
    private GameManager gameManager;
    
    public float toyFallSpeed = 3;

    public float toyRotationSpeedMin = 100;

    public float toyRotationSpeedMax = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.down * (toyFallSpeed * Time.deltaTime), Space.World);
            transform.Rotate(Vector3.up * (Random.Range(toyRotationSpeedMin, toyRotationSpeedMax) * Time.deltaTime), Space.World);
        }
    }
}
