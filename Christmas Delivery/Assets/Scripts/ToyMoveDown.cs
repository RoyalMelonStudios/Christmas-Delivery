﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMoveDown : MonoBehaviour
{
    private GameManager gameManager;
    
    public float toyFallSpeed = 5;
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
            transform.Translate(Vector3.down * toyFallSpeed * Time.deltaTime);
        }
    }
}
