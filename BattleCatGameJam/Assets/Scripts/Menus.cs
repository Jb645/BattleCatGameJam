using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace BattleCat
{
    public class Menus : MonoBehaviour
    {

        public bool playing = true;
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
            playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (settings.activeInHierarchy)
                {
                    settings.SetActive(false);
                }
                else if (pauseMenu.activeInHierarchy == true)
                {
                    pauseMenu.SetActive(false);
                    playing = true;
                    playerRb.isKinematic = false;

                }
                else if (pauseMenu.activeInHierarchy == false)
                {
                    pauseMenu.SetActive(true);
                    playing = false;
                    playerRb.isKinematic = true;
                    pausePlace = player.transform.position;
                }

            }
        }

        private void FixedUpdate()
        {
            if (!playing)
            {
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

    }
}
