using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleCat
{
    public class dialoge : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textOwO;

        timer time;

        string start = "ello (prees space to continue)";
        string lore = "im jerry and im too poor (next)";
        string lore2 = "to die, so im asking (next)";
        string lore3 = "you to help me with it";
        string ins1 = "use Wasd + space to move me";
        string ins2 = "reach to end";
        string ins3 = "pwz UwU";
        string sidenote = "oh, and btw unity or github delated some of our files and we cant";
        string sidenote2 = "revert back, so if this isnt finished that prob why :(";

        string finalWin = "*dies* ty.";
        string finalFail = "u did compleate it in under 80s, trash";

        [SerializeField] GameObject dialogue;

       Menus menu;

        List<string> pog;
        private void Awake()
        {
            menu = GetComponent<Menus>();
            
            List<string> text = new List<string>();
            text.Add(start);
            text.Add(lore);
            text.Add(lore2);
            text.Add(lore3);
            text.Add(ins1);
            text.Add(ins2);
            text.Add(ins3);
            text.Add(sidenote);
            text.Add(sidenote2);

            pog = text;

            
        }
        
        
        // Start is called before the first frame update
        void Start()
        {
            dialogue.SetActive(true);
            textOwO.text = pog[0];
            menu.playing = false;
            time = GameObject.Find("Player").GetComponent<timer>();
        }

        // Update is called once per frame
        void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                if (pog.Count > 0)
                {
                    pog.RemoveAt(0);
                }
                else
                {
                    dialogue.SetActive(false);
                    menu.playing = true;
                    time.addTime = true;
                }

            }

            if (pog.Count != 0)
            {
                textOwO.text = pog[0];
            }

        }


    }

    
}
