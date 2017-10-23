using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayBackGroundMusic();
	}

    private void PlayBackGroundMusic()
    {
        audioSource.clip = SoundManager.audioBackgroundMusic;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
