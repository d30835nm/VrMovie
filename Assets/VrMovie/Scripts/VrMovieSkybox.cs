using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace VrMovie
{
    public class VrMovieSkybox : MonoBehaviour
    {
        public enum ImageType
        {
            Image360Degrees,
            Image180Degrees,
        }

        public enum Layout
        {
            None,
            SideBySide,
            OverUnder,
        }

        [SerializeField]
        Material vrMovieSkybox;

        const float rotationOffset360Degrees = 90f;
        const float rotationOffset180Degrees = 0f;
        
        void Awake()
        {
            Assert.IsNotNull(vrMovieSkybox);
        }

        public void ChangeMode(ImageType imageType, Layout layout)
        {
            ChangeMode(imageType);
            ChangeMode(layout);
        }
        
        public void ChangeMode(ImageType imageType)
        {
            vrMovieSkybox.SetFloat("_ImageType", (int)imageType);
            switch (imageType)
            {
                case ImageType.Image360Degrees:
                    vrMovieSkybox.SetFloat("_Rotation", rotationOffset360Degrees);
                    break;
                case ImageType.Image180Degrees:
                    vrMovieSkybox.SetFloat("_Rotation", rotationOffset180Degrees);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageType), imageType, null);
            }
        }
        
        public void ChangeMode(Layout layout)
        {
            vrMovieSkybox.SetFloat("_Layout", (int)layout);
        }
    }
}