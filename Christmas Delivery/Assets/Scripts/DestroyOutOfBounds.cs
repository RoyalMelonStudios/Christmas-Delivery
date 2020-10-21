using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameManager gameMananger;

    public int rightBound = 11;
    // Start is called before the first frame update
    void Start()
    {
        gameMananger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.z > rightBound && gameObject)|| transform.position.y < -4)
        {
            if (!gameObject.CompareTag("Boxed"))
            {
                gameMananger.GameOver();
            }
            Destroy(gameObject);
        }
    }
}
