using UnityEngine;
using System.Collections;

public class PlayerFootSteps : MonoBehaviour {
    public bool onPath = false;

    public float stepTimer = 0f;
    public float stepPause = 0.6f; // amount of time between steps

    private Rigidbody2D rigidBody;
    private PlayerController playerController;
    private TouchControls touchControls;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
        touchControls = GetComponent<TouchControls>();
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(rigidBody.velocity.magnitude > 0)
        {
            if (onPath) {
                //StepSound(Configuration.audioPathStep);
            }
            
        }
        if(stepTimer > 0f)
        {
            stepTimer -= Time.deltaTime;

        }
        if(stepTimer < 0f)
        {
            stepTimer = 0f;
        }
	}

    void StepSound(AudioClip audioClip)
    {
        if (stepTimer == 0)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            stepTimer = stepPause;
        }
    }
}
