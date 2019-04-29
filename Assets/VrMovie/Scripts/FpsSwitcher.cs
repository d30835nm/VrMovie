using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Video;

namespace VrMovie
{
    public class FpsSwitcher : MonoBehaviour
    {
        [SerializeField]
        VrMovieSkybox vrMovieSkybox;

        [SerializeField]
        VideoPlayer vrVideoPlayer;

        [SerializeField]
        InformationText informationText;

        [SerializeField]
        VideoClip videoClipFps60;

        [SerializeField]
        VideoClip videoClipFps30;

        [SerializeField]
        VrMovieSkybox.ImageType targetImageType;

        [SerializeField]
        VrMovieSkybox.Layout targetLayout;
        
        enum Fps
        {
            Fps60,
            Fps30,
        }

        Fps currentFps;

        const float movieInformationVisibleDuration = 5f;

        void Awake()
        {
            Assert.IsNotNull(vrMovieSkybox);
            Assert.IsNotNull(vrVideoPlayer);
            Assert.IsNotNull(informationText);
            Assert.IsNotNull(videoClipFps60);
            Assert.IsNotNull(videoClipFps30);
            currentFps = Fps.Fps30;
            vrMovieSkybox.ChangeMode(targetImageType, targetLayout);
        }

        void Start()
        {
            UpdateVrMovie();
        }

        void OnEnable()
        {
            vrVideoPlayer.prepareCompleted += OnCompletePrepare;
        }

        void Update()
        {
            //Oculus Go の Trigger or Pad 及び、マウスクリックで動作。
            if (Input.GetButtonDown("Enter"))
            {
                NextFps();
            }
        }

        void NextFps()
        {
            currentFps++;
         
            if ((int)currentFps >= Enum.GetValues(typeof(Fps)).Length)
            {
                currentFps = (Fps)Enum.ToObject(typeof(Fps), 0);

            }
            
            UpdateVrMovie();
        }

        void UpdateVrMovie()
        {
            vrVideoPlayer.Stop();
            var information = "Loading...";
            informationText.Show(information, Mathf.Infinity);

            switch (currentFps)
            {
                case Fps.Fps60:
                    vrVideoPlayer.clip = videoClipFps60;
                    break;
                case Fps.Fps30:
                    vrVideoPlayer.clip = videoClipFps30;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            vrVideoPlayer.Prepare();
        }

        void OnCompletePrepare(VideoPlayer videoPlayer)
        {
            videoPlayer.Play();
            var information = currentFps.ToString();
            informationText.Show(information, movieInformationVisibleDuration);
        }
    }
}