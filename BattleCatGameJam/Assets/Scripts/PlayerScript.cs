using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jump = 5;
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
        allowJump = true;
    }

    private void FixedUpdate()
    {
        //jump
        if (allowJump && Input.GetKeyDown(KeyCode.Space)){

            playerRb.velocity = Vector2.up * jump;
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

}
