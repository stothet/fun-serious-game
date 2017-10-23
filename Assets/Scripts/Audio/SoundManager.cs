using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static readonly int NUMBER_OF_PATH_STEPS = 8;
    public static readonly int NUMBER_OF_GRASS_STEPS = 2;
    public static readonly int NUMBER_OF_BUILDING_STEPS = 2;

    public static SoundManager instance;
    public static AudioClip[] audioPathStep = new AudioClip[NUMBER_OF_PATH_STEPS];
    public static AudioClip[] audioDirtStep = new AudioClip[NUMBER_OF_GRASS_STEPS];
    public static AudioClip[] audioBuildingStep = new AudioClip[NUMBER_OF_BUILDING_STEPS];
    public static AudioClip audioBackgroundMusic;

    public static AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LoadAudioAssets();

        audioSource = gameObject.GetComponent<AudioSource>();
        //PlayBackGroundMusic();
    }

    private void LoadAudioAssets()
    {
        for (int i = 0; i < NUMBER_OF_PATH_STEPS; i++)
        {
            audioPathStep[i] = (AudioClip)Resources.Load("Audio/Steps/stepstone_" + (i + 1));
        }

        for (int i = 0; i < NUMBER_OF_GRASS_STEPS; i++)
        {
            audioDirtStep[i] = (AudioClip)Resources.Load("Audio/Steps/stepsnow_" + (i + 1));
        }

        for (int i = 0; i < NUMBER_OF_BUILDING_STEPS; i++)
        {
            audioBuildingStep[i] = (AudioClip)Resources.Load("Audio/Steps/stepwood_" + (i + 1));
        }
        audioBackgroundMusic = (AudioClip)Resources.Load("Audio/Music/Background Music");
    }

    private void PlayBackGroundMusic()
    {
        audioSource.clip = audioBackgroundMusic;
        audioSource.loop = true;
        audioSource.volume=0.5f;
        audioSource.Play();
    }
}