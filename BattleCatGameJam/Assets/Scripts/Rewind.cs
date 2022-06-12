using System.Collections.Generic;
using UnityEngine;

namespace BattleCat
{
    public class Rewind : MonoBehaviour
    {

        public bool isRewinding;

        private List<MultiValueForRewind> _multiValueForRewinds;

        private Rigidbody2D _rb;

        [SerializeField] private float recordTime = 3f;

        private BattleCat.Menus _menus;

        private PlayerScript _player;
        [SerializeField]private  AudioClip rewindSound;
        private bool _hasPlayedSound;
    
    
        // Start is called before the first frame update
        private void Start()
        {
            _multiValueForRewinds = new List<MultiValueForRewind>();
            _rb = GetComponent<Rigidbody2D>();
            _menus = GameObject.Find("MenuHandler").GetComponent<BattleCat.Menus>();
            _player = GetComponent<PlayerScript>();
        
        }

        // Update is called once per frame
        private void Update()
        {
            var position = transform.position;
            var youFall = position.y < -4 || position.y > 15;
        
            if (youFall)
            {
                StartRewind();
            }
        }

        private void StartRewind()
        {
            //starting rewind
            isRewinding = true;
            _rb.isKinematic = true;
        
            if (_hasPlayedSound) return;
            _player.PlaySound(rewindSound);
            _hasPlayedSound = true;
        }

        private void StopRewinding()
        {
            //stop rewinding
            isRewinding = false;
            _rb.isKinematic = false;
            _hasPlayedSound = false;
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

        private void Record()
        {
            //gets thier position
            if (!_menus.playing) return;
            if (_multiValueForRewinds.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            {
                _multiValueForRewinds.RemoveAt(_multiValueForRewinds.Count - 1);
            }
            _multiValueForRewinds.Insert(0, new MultiValueForRewind(transform.position, _player.moving, _player.latestDirection));

        }

        private void RewindLol()
        {
            //rewinds the player position
            if (!_menus.playing) return;
            var rewindingHasJuice = _multiValueForRewinds.Count > 0;
        
            if (rewindingHasJuice)
            {
                var value = _multiValueForRewinds[0];
                transform.position = value.Positions;
                _multiValueForRewinds.RemoveAt(0);
                var velocity = _rb.velocity;
                velocity = Vector2.up * 0;
                velocity = Vector2.left * 0;
                _rb.velocity = velocity;
                _player.moving = value.moveing;
                _player.latestDirection = value.lastDirections;
            }
            else
            {
                StopRewinding();
            }
        
        


        }

    }
}
