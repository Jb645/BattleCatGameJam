using System.Collections;
using UnityEngine;

namespace BattleCat
{
    public class PlayerScript : MonoBehaviour
    {

        [SerializeField] private float speed = 1;
        [SerializeField] private float jump = 5;
        [SerializeField] private bool allowJump;
        private Rigidbody2D _playerRb;
        private bool _isOnGround;
        private BattleCat.Menus _menu;
        private Animator _animator;
        public float moving;
        private Rewind _rewind;
        public float latestDirection = 0;
        private AudioSource _audioUwU;
        private GameObject _player;
        private BattleCat.timer _timer;
        private BattleCat.dialoge _dia;

        // Start is called before the first frame update
        private void Start()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _menu = GameObject.Find("MenuHandler").GetComponent<BattleCat.Menus>();
            allowJump = true;
            _animator = GetComponent<Animator>();
            _rewind = GetComponent<Rewind>();
            _audioUwU = GetComponent<AudioSource>();
            _player = GameObject.Find("Player");
            _timer = _player.GetComponent<BattleCat.timer>();
        }

        // Update is called once per frame
        private void Update()
        {
            _animator.SetFloat("Move X", moving);
        }

        private void FixedUpdate()
        {
            //jump
        
            if (allowJump && Input.GetKey(KeyCode.Space) && _menu.playing){

                if (_isOnGround)
                {
                    _playerRb.velocity = Vector2.up * jump;
                    allowJump = false;
                
                    if (latestDirection < 0)
                    {
                        _animator.SetTrigger("Jump Left");
                    }
                    else if (latestDirection > 0)
                    {
                        _animator.SetTrigger("Jump");
                    }


                }
                else
                {
                    StartCoroutine(CheckForJump());
                } 


            }
            //walk right
            var canWalkRight = Input.GetKey(KeyCode.D) && _menu.playing && !_rewind.isRewinding;
            if (canWalkRight)
            {
                transform.Translate(Vector2.right * (speed * Time.deltaTime));
                moving = 1;
                latestDirection = 0.025f;
            }
            else
            {
                var canWalkLeft = Input.GetKey(KeyCode.A) && _menu.playing && !_rewind.isRewinding;
                if (canWalkLeft)
                {
                    transform.Translate(Vector2.left * (speed * Time.deltaTime));
                    moving = 0;
                    latestDirection = -0.025f;
                }
                else if (!_rewind.isRewinding)
                {
                    moving = 0.5f + latestDirection;
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            //on collions stay
 
            _isOnGround = true;
            allowJump = true;    }

        private void OnCollisionExit2D(Collision2D collision)
        {
            //when you exit the collion
            StartCoroutine(CoyoteTime());
            _isOnGround = false;
        }

        IEnumerator CheckForJump()
        {
            //remeber jumps if they are 1 frame befor you can jump
        
            yield return new WaitForSeconds(0.1666f);
            if (!allowJump) yield break;
            _playerRb.velocity = Vector2.up * jump;
            allowJump = false;
        }

        //allows jumps for 3 more frames after they jumped 
        private IEnumerator CoyoteTime()
        {
            yield return new WaitForSeconds(0.05f);
            allowJump = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //stops your verlociy on collion with an object
            _playerRb.velocity = Vector2.up * 0;

            if (!collision.gameObject.CompareTag("win")) return;
            _timer.timePasses = false;
            if (_timer.timePassed < 80)
            {
                _animator.SetTrigger("die");

            }

        }

        public void PlaySound(AudioClip sound)
        {
            _audioUwU.PlayOneShot(sound);
        }
    }
}
