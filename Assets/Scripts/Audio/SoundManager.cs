using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static readonly int NUMBER_OF_PATH_STEPS = 8;

    public static SoundManager instance;
    public static AudioClip[] audioPathStep = new AudioClip[NUMBER_OF_PATH_STEPS];

    void Awake()
    {
        Debug.Log("SOUND: " + audioPathStep.Length);
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < NUMBER_OF_PATH_STEPS; i++)
        {
            audioPathStep[i] = (AudioClip)Resources.Load("Audio/stepstone_" + (i + 1));
        }

    }
}