using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleCat
{

    

    public class MainMenu : MonoBehaviour
    {

        string sceneName = "BattleCatScene";
        [SerializeField] GameObject credits;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && credits.activeInHierarchy == true)
            {
                credits.SetActive(false);
            }
        }

        public void Game()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Credits()
        {
            credits.SetActive(true);
        }
    }


}
