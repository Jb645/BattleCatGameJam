using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleCat
{
    public class dialoge : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI textOwO;

        string start = "ello (prees space to continue)";
        string lore = "im jerry and im too poor (next)";
        string lore2 = "to die, so im asking (next)";
        string lore3 = "you to help me with it";
        string ins1 = "use Wasd + space to move me";
        string ins2 = "reach to end";
        string ins3 = "pwz UwU";

        string final = "*dies* ty.";

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

            pog = text;

            
        }
        
        
        // Start is called before the first frame update
        void Start()
        {
            dialogue.SetActive(true);
            textOwO.text = pog[0];
            menu.playing = false;
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
                }

            }

            if (pog.Count != 0)
            {
                textOwO.text = pog[0];
            }

        }

    }
}
