using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public interface IPauseGameController
{
    void Pause();
    void Resume();
    void TogglePause();
}

public class PauseGame : MonoBehaviour, IPauseGameController
{
    private bool isPaused = false;
    [SerializeField] private List<GameObject> objectsToDisable;
    [SerializeField] private List<GameObject> objectsToEnable;

    private Dictionary<AudioSource, float> audioPlaybackTimes;

    [SerializeField] private InputActionReference primaryButtonAction;

    void Start()
    {
        audioPlaybackTimes = new Dictionary<AudioSource, float>();
        primaryButtonAction.action.Enable();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || primaryButtonAction.action.triggered)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        audioPlaybackTimes.Clear();
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioPlaybackTimes[audioSource] = audioSource.time;
                audioSource.Pause();
            }
        }

        ErrorType.UnknownError.LogCustomError("Game paused.");
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }
        foreach (KeyValuePair<AudioSource, float> entry in audioPlaybackTimes)
        {
            entry.Key.time = entry.Value;
            entry.Key.Play();
        }

        ErrorType.UnknownError.LogCustomError("Game resumed.");
    }
}
