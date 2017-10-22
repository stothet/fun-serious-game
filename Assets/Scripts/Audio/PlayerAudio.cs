using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {
    public bool onPath = false;

    public float stepTimer = 0f;
    public float stepPause = 0.6f; // amount of time between steps

    private float xpos = 0f;
    private float ypos = 0f;

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

        onPath = false;
    }
	
	// Update is called once per frame
	void Update () {
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
            if (onPath)
            {
                //StepSound(Configuration.audioPathStep);
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
    void StepSound(AudioClip audioClip)
    {
        if (stepTimer == 0)
        {
            audioSource.PlayOneShot(audioClip, 0.1f);
            stepTimer = stepPause;
        }
    }
}
