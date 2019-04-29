using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.Video;

namespace VrMovie
{
    public class VrMovieModeSwitcher : MonoBehaviour
    {
        [SerializeField]
        VrMovieSkybox vrMovieSkybox;

        [SerializeField]
        VideoPlayer vrVideoPlayer;

        [SerializeField]
        InformationText informationText;

        [SerializeField]
        List<VrMovie> vrMovies;

        int currentVrMovieIndex;

        const float movieInformationVisibleDuration = 5f;

        void Awake()
        {
            Assert.IsNotNull(vrMovieSkybox);
            Assert.IsNotNull(vrVideoPlayer);
            Assert.IsNotNull(informationText);

            if (vrMovies.Count == 0)
            {
                Debug.LogError("vrMoviesが設定されていません");
                return;
            }
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
                NextVrMovieMode();
            }
        }

        void NextVrMovieMode()
        {
            currentVrMovieIndex++;
            if (currentVrMovieIndex >= vrMovies.Count)
            {
                currentVrMovieIndex = 0;
            }

            UpdateVrMovie();
        }

        void UpdateVrMovie()
        {
            vrVideoPlayer.Stop();
            var information = "Loading...";
            informationText.Show(information, Mathf.Infinity);
            vrVideoPlayer.clip = vrMovies[currentVrMovieIndex].VideoClip;
            vrVideoPlayer.Prepare();
        }

        void OnCompletePrepare(VideoPlayer videoPlayer)
        {
            videoPlayer.Play();
            var vrMovie = vrMovies[currentVrMovieIndex];
            vrMovieSkybox.ChangeMode(vrMovie.ImageType, vrMovie.Layout);
            
            var information = "VideoName : " + vrMovie.VideoClip.name +
                              "\nImageType : " + vrMovie.ImageType.ToString() +
                              "\nLayout : " + vrMovie.Layout.ToString();
            
            informationText.Show(information, movieInformationVisibleDuration);
        }
    }
}