using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    float speed = 1;
    float jump = 5;
    bool allowJump;
    Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (allowJump && Input.GetKeyDown(KeyCode.Space)){

            playerRb.velocity = Vector2.up * jump;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
