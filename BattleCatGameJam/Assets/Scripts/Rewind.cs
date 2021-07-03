using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{

    public bool isRewinding;

    List<MultiValueForRewind> multiValueForRewinds;

    Rigidbody2D rb;

    [SerializeField] float recordTime = 3f;

    private BattleCat.Menus menus;

    PlayerScript player;
    [SerializeField] AudioClip rewindSound;
    bool hasPlayedSound;
    
    // Start is called before the first frame update
    void Start()
    {
        multiValueForRewinds = new List<MultiValueForRewind>();
        rb = GetComponent<Rigidbody2D>();
        menus = GameObject.Find("MenuHandler").GetComponent<BattleCat.Menus>();
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //start to rewind when your att y -4
        if (transform.position.y < -4 || transform.position.y > 15)
        {
            StartRewind();
        }
    }

    public void StartRewind()
    {
        //starting rewind
        isRewinding = true;
        rb.isKinematic = true;
        if (!hasPlayedSound)
        {
            player.PlaySound(rewindSound);
            hasPlayedSound = true;
        }
    }

    public void StopRewinding()
    {
        //stoprewinding
        isRewinding = false;
        rb.isKinematic = false;
        hasPlayedSound = false;
    }

    private void FixedUpdate()
    {
        //rewind or record
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
        //gets thier position
        if (menus.playing)
        {
            if (multiValueForRewinds.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            {
                multiValueForRewinds.RemoveAt(multiValueForRewinds.Count - 1);
            }
            multiValueForRewinds.Insert(0, new MultiValueForRewind(transform.position, player.moveing, player.latestDirection));
        }

    }

    void RewindLol()
    {

    
        //rewinds the player position
        if (menus.playing)
        {
            if (multiValueForRewinds.Count > 0)
            {
                MultiValueForRewind value = multiValueForRewinds[0];
                transform.position = value.positions;
                multiValueForRewinds.RemoveAt(0);
                rb.velocity = Vector2.up * 0;
                rb.velocity = Vector2.left * 0;
                player.moveing = value.moveing;
                player.latestDirection = value.lastDirections;
            }
            else
            {
                //stops the rewind if thier isnt anything more to rewind
                StopRewinding();
            }
        }


    }

}
