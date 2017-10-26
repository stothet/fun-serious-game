using UnityEngine;
using System.Collections;

public class ResetGameState : MonoBehaviour {

	void Start () {
        PersistenceController.ResetState();
        //PersistenceController.instance.InitialiseState();	
	}
	
}
