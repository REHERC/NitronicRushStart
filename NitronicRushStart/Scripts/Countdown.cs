using UnityEngine;
using UnityEngine.UI;

namespace NitronicRushStart.UnityScripts
{
    class Countdown : MonoBehaviour
    {
        public float Time = -10;

        public float StartKey = 0;
        public float DurationKey = 1;


        private float EndKey = 1;
        private Image img;

        // Use this for initialization
        void Start()
        {
            this.img = this.GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            Material mat = Instantiate(this.img.material);
            mat.SetFloat("_Progress", this.GetInterpolationState(this.Time));
            this.img.material = mat;
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
