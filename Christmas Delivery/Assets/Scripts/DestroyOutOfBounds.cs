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
        if (transform.position.z > rightBound)
        {
            if (!gameObject.CompareTag("Boxed"))
            {
                FindObjectOfType<AudioManager>().Play("Mismatch Toy SFX");
                gameMananger.IncreaseEmptyPresents(1);
                gameMananger.GameOver();
                
            }
            Destroy(gameObject);
        }
    }
}
