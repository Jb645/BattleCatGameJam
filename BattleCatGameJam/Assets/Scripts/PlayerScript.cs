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
        if (allowJump && Input.GetKey(KeyCode.Space)){

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        allowJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(CoyoteTime());
    }

    IEnumerator CoyoteTime()
    {
        yield return new WaitForSeconds(0.05f);
        allowJump = false;
    }

}
