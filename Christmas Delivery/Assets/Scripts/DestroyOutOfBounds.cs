using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameManager gameMananger;

    public int rightBound = 11;

    public float lowerBound = 0.27f;
    // Start is called before the first frame update
    void Start()
    {
        gameMananger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.z > rightBound && gameObject)|| transform.position.y < 0.27f)
        {
            if (!gameObject.CompareTag("Boxed"))
            {
                if (gameObject.CompareTag("Toy1") || gameObject.CompareTag("Toy2") || gameObject.CompareTag("Toy3"))
                {
                    FindObjectOfType<AudioManager>().Play("Break SFX");
                    gameMananger.IncreaseToysBroken(1);
                }
                else if (gameObject.CompareTag("Box1") || gameObject.CompareTag("Box2") ||
                         gameObject.CompareTag("Box3"))
                {
                    FindObjectOfType<AudioManager>().Play("Mismatch Toy SFX");
                    gameMananger.IncreaseEmptyPresents(1);
                }

                gameMananger.GameOver();
                
            }
            FindObjectOfType<AudioManager>().Play("Scan SFX");
            Destroy(gameObject);
        }
    }
}
