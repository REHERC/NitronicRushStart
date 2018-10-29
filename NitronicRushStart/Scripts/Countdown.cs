using System;
using UnityEngine;
using UnityEngine.UI;

namespace NitronicRushStart.UnityScripts
{
    public class Countdown : MonoBehaviour
    {
        public float Time = -10;
        public float StartKey = 0;
        public float DurationKey = 1;

        public float AudioClipStart;
        public string AudioClipName;

        private float EndKey = 1;
        private Image img;

        private float LastTime;
        private float CurrentTime;

        // Use this for initialization
        void Start()
        {
            this.img = this.GetComponent<Image>();
            UnityEngine.Object.FindObjectOfType<UnityScripts.AudioManager>().Play(this.AudioClipName);
        }

        // Update is called once per frame
        void Update()
        {
            this.CurrentTime = this.Time;
            Material mat = Instantiate(this.img.material);
            mat.SetFloat("_Progress", this.GetInterpolationState(this.Time));
            
            if (this.CurrentTime >= this.AudioClipStart && this.LastTime <= this.AudioClipStart)
            {
                Console.WriteLine(this.AudioClipName);
                UnityEngine.Object.FindObjectOfType<UnityScripts.AudioManager>().Play(this.AudioClipName);
            }

            this.img.material = mat;
            this.LastTime = this.CurrentTime;
        }
        
        float GetInterpolationState(float time)
        {
            this.EndKey = this.StartKey + (this.DurationKey / 2);
            float diff = this.EndKey - this.StartKey;
            float curve = (1 / diff) * (-Mathf.Abs(time - this.StartKey - diff)) + 1;
            return Mathf.Max(0, curve);
        }
    }
}
