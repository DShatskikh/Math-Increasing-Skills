using System;
using UnityEngine;
using UnityEngine.UI;

namespace Math
{
    public class PerlinNouse : MonoBehaviour
    {
        // Width and height of the texture in pixels.
        public int pixWidth;
        public int pixHeight;

        // The origin of the sampled area in the plane.
        public float xOrg;
        public float yOrg;

        // The number of cycles of the basic noise pattern that are repeated
        // over the width and height of the texture.
        [Range(1, 10)]
        public float scale = 1.0F;
        
        public Slider Slider;

        private Texture2D noiseTex;
        private Color[] pix;
        private SpriteRenderer rend;

        private void OnEnable()
        {
            Slider.onValueChanged.AddListener(UpdateSlider);
        }

        private void OnDisable()
        {
            Slider.onValueChanged.RemoveListener(UpdateSlider);
        }
        
        void Start()
        {
            rend = GetComponent<SpriteRenderer>();

            // Set up the texture and a Color array to hold pixels during processing.
            noiseTex = new Texture2D(pixWidth, pixHeight);
            pix = new Color[noiseTex.width * noiseTex.height];
            rend.sprite = Sprite.Create(noiseTex, new Rect(0.0f, 0.0f, noiseTex.width, noiseTex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

        void CalcNoise()
        {
            // For each pixel in the texture...
            float y = 0.0F;

            while (y < noiseTex.height)
            {
                float x = 0.0F;
                while (x < noiseTex.width)
                {
                    float xCoord = xOrg + x / noiseTex.width * scale;
                    float yCoord = yOrg + y / noiseTex.height * scale;
                    float sample = Mathf.PerlinNoise(xCoord, yCoord);
                    pix[(int)y * noiseTex.width + (int)x] = new Color(sample, sample, sample);
                    x++;
                }
                y++;
            }

            // Copy the pixel data to the texture and load it into the GPU.
            noiseTex.SetPixels(pix);
            noiseTex.Apply();
        }

        void Update()
        {
            var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            var y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

            xOrg += x * scale;
            yOrg += y * scale;
            
            CalcNoise();
        }
        
        private void UpdateSlider(float value)
        {
            scale = Mathf.Lerp(0, 10, value);
        }
    }
}