using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

namespace Nightmare
{
    public class PlayVideo : MonoBehaviour
    {
        [SerializeField]
        private VideoPlayer videoPlayer;
        [SerializeField]
        private bool atStart;

        public void Start()
        {
            if (atStart)
            {
                Play();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void Play()
        {
            SceneController.StopScene(gameObject);
            videoPlayer.isLooping = true;
            videoPlayer.Play();
            videoPlayer.loopPointReached += onEndPlay;
        }
        public void StopPlay() => onEndPlay(videoPlayer);

        private void onEndPlay(VideoPlayer player) 
        {
            player.Stop();
            videoPlayer.isLooping = false;
            SceneController.PlayScene(gameObject);
            videoPlayer.loopPointReached -= onEndPlay;
        }
    }
}