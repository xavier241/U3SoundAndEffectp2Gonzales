using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public bool gameOver;
    private Rigidbody PlayerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
       PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }


}
    