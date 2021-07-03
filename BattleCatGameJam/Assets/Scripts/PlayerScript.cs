using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jump = 5;
    [SerializeField] bool allowJump;
    Rigidbody2D playerRb;
    bool isOnGround;
    BattleCat.Menus menu;
    Animator animator;
    public float moveing;
    Rewind rewind;
    public float latestDirection = 0;
    AudioSource audioUwU;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        menu = GameObject.Find("MenuHandler").GetComponent<BattleCat.Menus>();
        allowJump = true;
        animator = GetComponent<Animator>();
        rewind = GetComponent<Rewind>();
        audioUwU = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
            animator.SetFloat("Move X", moveing);
    }

    private void FixedUpdate()
    {
        //jump
        if (allowJump && Input.GetKey(KeyCode.Space) && menu.playing){

            if (isOnGround)
            {
                playerRb.velocity = Vector2.up * jump;
                allowJump = false;
                
                if (latestDirection == -0.25)
                {
                    animator.SetTrigger("Jump");
                }
                else
                {
                    animator.SetTrigger("Jump left");
                }

            }
            else
            {
                StartCoroutine(CheckForJump());
            } 


        }
        //walk right
        if (Input.GetKey(KeyCode.D) && menu.playing && !rewind.isRewinding)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            moveing = 1;
            latestDirection = 0.025f;
        }
        else if (Input.GetKey(KeyCode.A) && menu.playing && !rewind.isRewinding)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            moveing = 0;
            latestDirection = -0.025f;
        }
        else if (!rewind.isRewinding)
        {
            moveing = 0.5f + latestDirection;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //on collions stay
 
        isOnGround = true;
        allowJump = true;    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //when you exit the collion
        StartCoroutine(CoyoteTime());
        isOnGround = false;
    }

    IEnumerator CheckForJump()
    {
        //remeber jumps if they are 1 frame befor you can jump
        
        yield return new WaitForSeconds(0.1666f);
        if (allowJump)
        {
            playerRb.velocity = Vector2.up * jump;
            allowJump = false;
        }
    }

    //allows jumps for 3 more frames after they jumped 
    IEnumerator CoyoteTime()
    {
        yield return new WaitForSeconds(0.05f);
        allowJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //stops your verlociy on collion with an object
        playerRb.velocity = Vector2.up * 0;
      
    }

    public void PlaySound(AudioClip sound)
    {
        audioUwU.PlayOneShot(sound);
    }
}
