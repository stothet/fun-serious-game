using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowVolumePercentage : MonoBehaviour {
    Text volumeLabel;

	// Use this for initialization
	void Start () {
        volumeLabel = GetComponent<Text>();
	}
	
	public void volumeLabelUpdate (float volumeValue)
    {
        float valueToBeUpdated = Mathf.RoundToInt(volumeValue * 100);
        volumeLabel.text = valueToBeUpdated + "%";
    }




}
