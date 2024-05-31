using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public string videoUrl = "https://youtu.be/zWh3CShX_do";
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = videoUrl;
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += (source) => { videoPlayer.Play(); };
        }
        else
        {
            Debug.LogError("Video Player component is missing");
        }
    }
}
