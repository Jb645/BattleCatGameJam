using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace BattleCat
{
    public class Menus : MonoBehaviour
    {

        public bool playing;
        [SerializeField] GameObject pauseMenu;
        Rigidbody2D playerRb;
        GameObject player;
        Vector2 pausePlace;
        [SerializeField] GameObject settings;
        [SerializeField] AudioMixer music;
        [SerializeField] AudioMixer soundEffects;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //exiting menus and opening the pausemenu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (settings.activeInHierarchy)
                {
                    //close settings
                    settings.SetActive(false);
                }
                else if (pauseMenu.activeInHierarchy == true)
                {
                    //exiting pausemenu
                    pauseMenu.SetActive(false);
                    playing = true;
                    playerRb.isKinematic = false;

                }
                else if (pauseMenu.activeInHierarchy == false)
                {
                    //opening pause menu
                    pauseMenu.SetActive(true);
                    playing = false;
                    //used to block movement
                    playerRb.isKinematic = true;
                    pausePlace = player.transform.position;
                }

            }
        }

        private void FixedUpdate()
        {
            if (!playing)
            {
                //setting the paused players position
                player.transform.position = pausePlace;
            }
        }

        public void ShowSettings()
        {
            settings.SetActive(true);
        }

        public void ChangeSound(float volume)
        {
            music.SetFloat("Sound", volume);
        }

        public void ChangeSoundOnEffects(float volume)
        {
            soundEffects.SetFloat("Sound", volume);
        }

        public void Restart()
        {
            Scene Scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(Scene.name);
        }


        private void Awake()
        {
            playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player");
            pausePlace = player.transform.position;
        }

    }
}
