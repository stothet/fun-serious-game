using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour
{
    public bool onPath = false;
    public bool onGrass = false;
    public bool onBuildingFloor = false;
    public bool atDoor = false;

    private float stepTimer = 0f;
    private float stepPause = 0.42f; // amount of time between steps

    private float xpos = 0f;
    private float ypos = 0f;

    private PlayerController playerController;
    private TouchControls touchControls;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        touchControls = GetComponent<TouchControls>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Step();
        TrackPosition();

    }

    void TrackPosition()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
    }
    void Step()
    {
        
        if (xpos != transform.position.x || ypos != transform.position.y)
        {
            if (onBuildingFloor)
            {
                StepSound(SoundManager.audioBuildingStep, SoundManager.NUMBER_OF_BUILDING_STEPS, 0.8f);
            }
            else if (onPath)
            {
                StepSound(SoundManager.audioPathStep, SoundManager.NUMBER_OF_PATH_STEPS, 0.8f);
            }
            else if (onGrass)
            {
                StepSound(SoundManager.audioDirtStep, SoundManager.NUMBER_OF_GRASS_STEPS, 0.6f);
            }
            
        }
        if (stepTimer > 0f)
        {
            stepTimer -= Time.deltaTime;

        }
        if (stepTimer < 0f)
        {
            stepTimer = 0f;
        }

    }
    void StepSound(AudioClip[] audioClip, int numberOfSoundVariations, float volume)
    {
        if (stepTimer == 0)
        {
            audioSource.PlayOneShot(audioClip[Random.Range(0, numberOfSoundVariations)], volume);
            stepTimer = stepPause;
        }
    }

    public void PlayDoorSound()
    {
        audioSource.PlayOneShot(SoundManager.audioDoor[Random.Range(0, SoundManager.NUMBER_OF_DOOR_SOUNDS)], 0.8f);
        Debug.Log("Play door sound");
    }
}
