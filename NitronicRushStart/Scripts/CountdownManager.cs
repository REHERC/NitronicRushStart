using System.Collections.Generic;
using UnityEngine;

namespace NitronicRushStart.UnityScripts
{
    public class CountdownManager : MonoBehaviour
    {
        public List<Countdown> Digits;

        public float Time = -10;

        private bool initiated = false;

        // Use this for initialization
        public void Setup()
        {
            this.Digits = new List<Countdown>();
            this.Digits.Clear();
            this.Digits.AddRange(this.gameObject.GetComponentsInChildren<Countdown>());

            this.initiated = true;
        }

        // Update is called once per frame
        void Update()
        {

            if (this.initiated)
            {
                foreach (Countdown Digit in Digits)
                {
                    Digit.Time = this.Time;
                }
            }
        }

        public bool IsInitiated()
        {
            return this.initiated;
        }
    }
}
