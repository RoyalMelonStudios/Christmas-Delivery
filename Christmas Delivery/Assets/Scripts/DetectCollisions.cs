﻿using System;
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
        if (gameObject.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Break SFX");
            gameMananger.IncreaseToysBroken(1);
            gameMananger.GameOver();
        }

        else if (IsCorrectBoxing(other) && !gameObject.CompareTag("Boxed"))
        {
            Destroy(other.gameObject);
            gameObject.tag = "Boxed";
            FindObjectOfType<AudioManager>().Play("Right Toy SFX");
            gameMananger.IncreasePresentsPackaged(1);
            gameMananger.UpdateScore(1);
        }
        
        else if (!IsCorrectBoxing(other) && !gameObject.CompareTag("Boxed"))
        {
            FindObjectOfType<AudioManager>().Play("Mismatch Toy SFX");
            gameMananger.IncreaseMismatchedPresents(1);
            gameMananger.GameOver();
        }
    }

    private bool IsCorrectBoxing(Collider other)
    {
        if (gameObject.CompareTag("Box1"))
        {
            if (other.gameObject.CompareTag("Toy1"))
            {
                return true;
            }
        }
        else if (gameObject.CompareTag("Box2"))
        {
            if (other.gameObject.CompareTag("Toy2"))
            {
                return true;
            }
        }
        else if (gameObject.CompareTag("Box3"))
        {
            if (other.gameObject.CompareTag("Toy3"))
            {
                return true;
            }
        }
        return false;
    }
    
    
}
