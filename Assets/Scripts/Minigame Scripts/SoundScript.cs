using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundScript : MonoBehaviour
{
    AudioClip microphoneInput;
    bool microphoneInitialised;
    public float sensitivity;
    public GameObject[] dustBlockers;
    //A dustcounter is used so that all all the dust isn't blown away at once.
    //Used in the update method to variably change how hard it is to blow away DustBlocker prefabs.
    public int dustCounter;
    void Start()
    {
        //Get the array of dust particles to remove with each blow.
        dustBlockers = GameObject.FindGameObjectsWithTag("Dust");
        dustCounter = 0;
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

        //Sensitivity is currently set as 0.9 at the inspector.
        if (level>sensitivity)
        {
            //The microphone needs to detect 20 'blows' in order to remove on DustBlocker prefab.
            //Change the value of 20 higher to make player blow harder to get rid of a DustBlocker.
            //Or lower to make it easier for the player to get rid of a DustBlocker.
            if (dustCounter/20 < dustBlockers.Length)
            {
                dustCounter += 1;
                Destroy(dustBlockers[dustCounter / 20]);

            }

        }
    }
}