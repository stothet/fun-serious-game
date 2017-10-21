using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundScript : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microphoneInitialised;
    public float sensitivity;
    public GameObject[] dustBlockers;

    void Start()
    {
        //Get the array of dust particles to remove with each blow.
        dustBlockers = GameObject.FindGameObjectsWithTag("Dust");
        //init microphone input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialised = true;
        }
    }

    void Update()
    {
        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));

        if (level>sensitivity)
        {
            for (var i = 0; i < dustBlockers.Length; i++)
            {
                Destroy(dustBlockers[i]);
            }
            Debug.Log("SOUND DETECTED");
        }
    }
}