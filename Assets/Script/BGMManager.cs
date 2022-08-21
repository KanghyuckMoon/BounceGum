using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;
    [SerializeField]
    private Transform bound;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("BGMON") == 0)
        {
            audioSource.clip = null;
        }
    }
    private void Update()
    {
        if (bound.position.x > 2030)
        {
            if(audioSource.clip != null)
            {
                audioSource.clip = null;
                audioSource.Play();
            }
        }
        else if (bound.position.x > 1580)
        {
            if (audioSource.clip != audioClips[4])
            {
                audioSource.clip = audioClips[4];
                audioSource.Play();
            }
        }
        else if(bound.position.x > 1140)
        {
            if (audioSource.clip != audioClips[3])
            {
                audioSource.clip = audioClips[3];
                audioSource.Play();
            }
        }
        else if(bound.position.x > 800)
        {
            if (audioSource.clip != audioClips[2])
            {
                audioSource.clip = audioClips[2];
                audioSource.Play();
            }
        }
        else if(bound.position.x > 555)
        {
            if (audioSource.clip != audioClips[1])
            {
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.clip != audioClips[0])
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("CAM", 1);
            SceneManager.LoadScene("TitleScene");
        }
    }
}
