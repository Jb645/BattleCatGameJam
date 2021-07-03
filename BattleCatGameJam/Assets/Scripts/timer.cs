using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleCat
{
    public class timer : MonoBehaviour
    {

        public float timePassed;
        [SerializeField] float time;
        public bool addTime;
        [SerializeField] TextMeshProUGUI timeOwO;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        if (addTime)
            {
                time += Time.deltaTime;
            }

            timePassed = Mathf.Round(time);
            timeOwO.text = "Time: " + timePassed;
        }
    }
}
