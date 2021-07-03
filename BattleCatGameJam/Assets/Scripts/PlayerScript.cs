﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        menu = GameObject.Find("MenuHandler").GetComponent<BattleCat.Menus>();
        allowJump = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //jump
        if (allowJump && Input.GetKey(KeyCode.Space) && menu.playing){

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
        if (Input.GetKey(KeyCode.D) && menu.playing)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        }
        else if (Input.GetKey(KeyCode.A) && menu.playing)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); 
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

}
