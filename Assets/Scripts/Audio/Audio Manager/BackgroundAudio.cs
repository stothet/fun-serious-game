using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {
    private static AudioSource audioSource; 

    // Use this for initialization
    void Awake () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}

    void Start()
    {
        //PlayBackgroundMusic();
    }
    public static void PlayBackgroundMusic()
    {
        audioSource.clip = SoundManager.audioBackgroundMusic;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
