using UnityEngine;
using System.Collections;

public class UIAudio : MonoBehaviour {
    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public void PlayClick()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(SoundManager.audioClick, 0.5f);
    }

}
