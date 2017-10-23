using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {
	// Use this for initialization
	void Start () {
        SoundManager sm = new SoundManager();
        sm.PlayBackGroundMusic();
	}

    private void PlayBackGroundMusic()
    {

    }
}
