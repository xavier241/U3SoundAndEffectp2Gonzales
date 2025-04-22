using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody PlayerRb;
    public float jumpForce;
    public float gravityModifier;
    // Start is called before the first frame update
    void Start()
    {
       PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        }
    }
}
