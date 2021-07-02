using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCat
{
    public class Menus : MonoBehaviour
    {

        public bool playing = true;
        [SerializeField] GameObject pauseMenu;
        Rigidbody2D playerRb;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(pauseMenu.activeInHierarchy == true)
                {
                    pauseMenu.SetActive(false);
                    playing = true;

                }
                else if (pauseMenu.activeInHierarchy == false)
                {
                    pauseMenu.SetActive(true); 
                    playing = false;
                }
            }
        }
    }

    
}
