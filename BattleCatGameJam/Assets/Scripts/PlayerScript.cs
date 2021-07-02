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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        allowJump = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //jump
        if (allowJump && Input.GetKey(KeyCode.Space)){

            if (isOnGround)
            {
                playerRb.velocity = Vector2.up * jump;
                allowJump = false;
            }
            else
            {
                StartCoroutine(CheckForJump());
            } 


        }
        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.A))
        {
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //on collions stay
        allowJump = true;
        isOnGround = true;
    }

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

}
