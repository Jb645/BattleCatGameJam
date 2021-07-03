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
        timer timerr;

        

        // Update is called once per frame
        private void Update()
        {
            //exiting menus and opening the pausemenu
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
            if (settings.activeInHierarchy) settings.SetActive(false);
            else switch (pauseMenu.activeInHierarchy)
            {
                case true:
                    //exiting pausemenu
                    pauseMenu.SetActive(false);
                    playing = true;
                    playerRb.isKinematic = false;
                    timerr.timePasses = true;
                    break;
                case false:
                    //opening pause menu
                    pauseMenu.SetActive(true);
                    playing = false;
                    //used to block movement
                    playerRb.isKinematic = true;
                    pausePlace = player.transform.position;
                    timerr.timePasses = false;
                    break;
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
            var scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }


        private void Awake()
        {
            playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player");
            pausePlace = player.transform.position;
            timerr = player.GetComponent<timer>();
        }

    }
}
