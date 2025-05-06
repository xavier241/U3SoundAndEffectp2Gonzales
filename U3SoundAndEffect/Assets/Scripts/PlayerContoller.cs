using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public bool canDoubleJump = false;
    private AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpsound;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private Animator playerAnim;
    public bool gameOver;
    private Rigidbody PlayerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
       PlayerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
 
    
        void Update()
        {
            //single jump if
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpsound, 1.0f);
                canDoubleJump = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Time.timeScale = 1.7f;
            }
            else Time.timeScale = 1f;


        }

            //double jump if
            if (Input.GetKeyDown(KeyCode.Space) && PlayerRb.velocity.y > 0f && canDoubleJump && !gameOver)
            {
                canDoubleJump = false;

                PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


                playerAnim.SetTrigger("Jump_trig");
                playerAudio.PlayOneShot(jumpsound, 1);


            }

        }
        private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Ground")) 
        {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }


}
    