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

        private const string start = "ello (prees space to continue)";
        private const string lore = "im jerry and im too poor (next)";
        private const string lore2 = "to die, so im asking (next)";
        private const string lore3 = "you to help me with it";
        private const string ins1 = "use Wasd + space to move me";
        private const string ins2 = "reach to end";
        private const string ins3 = "pwz UwU";
        private const string sidenote = "oh, and btw unity or github delated some of our files and we cant";
        private const string sidenote2 = "revert back, so if this isnt finished that prob why :(";

        private const string finalWin = "*dies* ty.";
        private const string finalFail = "u did compleate it in under 80s, trash";

        [SerializeField] GameObject dialogue;

        private Menus _menu;

        private List<string> _pog;
        private void Awake()
        {
            _menu = GetComponent<Menus>();

            var text = new List<string>
            {
                start,
                lore,
                lore2,
                lore3,
                ins1,
                ins2,
                ins3,
                sidenote,
                sidenote2
            };

            _pog = text;

            
        }
        
        
        // Start is called before the first frame update
        private void Start()
        {
            dialogue.SetActive(true);
            textOwO.text = _pog[0];
            _menu.playing = false;
            time = GameObject.Find("Player").GetComponent<timer>();
        }

        // Update is called once per frame
        private void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var thereIsDialogueRemaining = _pog.Count > 0;
            
            if (thereIsDialogueRemaining)
            {
                _pog.RemoveAt(0);
            }
            else
            {
                dialogue.SetActive(false);
                _menu.playing = true;
                time.timePasses = true;
            }

        }

        if (_pog.Count != 0)
        {
            textOwO.text = _pog[0];
        }

        }


    }

    
}
