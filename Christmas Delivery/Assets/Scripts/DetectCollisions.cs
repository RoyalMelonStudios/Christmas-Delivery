using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameMananger;
    
    // Start is called before the first frame update
    void Start()
    {
        gameMananger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy") && !gameObject.CompareTag("Boxed"))
        {
            Destroy(other.gameObject);
            gameObject.tag = "Boxed";
            gameMananger.UpdateScore(1);
        }
    }
}
