using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovveLeft : MonoBehaviour
{
    private float leftBound = -15;
    private PlayerContoller playercontollerscript;
    private float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        playercontollerscript = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playercontollerscript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
             Destroy(gameObject);
        }        
    }
}
