using System;
using UnityEngine;
using UnityEngine.Video;

namespace VrMovie
{
    [Serializable]
    public class VrMovie
    {
        [SerializeField]
        VideoClip videoClip;

        public VideoClip VideoClip => videoClip;

        [SerializeField]
        VrMovieSkybox.ImageType imageType;

        public VrMovieSkybox.ImageType ImageType => imageType;

        [SerializeField]
        VrMovieSkybox.Layout layout;

        public VrMovieSkybox.Layout Layout => layout;
    }
}