using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeMainMenuVolume : MonoBehaviour {
    public Slider volumeSlider;

    public void OnValueChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
