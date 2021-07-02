using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{

    public bool isRewinding;

    List<Vector2> positions;

    Rigidbody2D rb;

    [SerializeField] float recordTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -4)
        {
            StartRewind();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewinding()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            RewindLol();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        if (positions.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
        positions.Insert(0, transform.position);
    }

    void RewindLol()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
            rb.velocity = Vector2.up * 0;
            rb.velocity = Vector2.left * 0;
        }
        else
        {
            StopRewinding();
        }

    }
}
