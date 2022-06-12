using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleCat
{
    public class timer : MonoBehaviour
    {

        public float timePassed;
        [SerializeField] private float time;
        public bool timePasses;
        [SerializeField] private TextMeshProUGUI timeOwO;

        
        private void Update()
        {
            if (timePasses) time += Time.deltaTime;

            timePassed = Mathf.Round(time);
                timeOwO.text = "Time: " + timePassed;
        }
    }
}
