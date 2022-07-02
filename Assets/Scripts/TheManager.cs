using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheManager : MonoBehaviour
{
    public static TheManager theManager;

    private AudioSource audioSource;

    public AudioClip batman;

    public AudioClip time;

    public AudioClip carribean;

    private void Awake()
    {
        // Here we make TheManager singleton.
        if (theManager!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            theManager = this;
        }
        DontDestroyOnLoad(theManager);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayMusic(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
