using UnityEngine;
using System.Collections;

public class ResetGameState : MonoBehaviour {

	void Start () {
        PersistenceController.instantiateInstance();
        //PersistenceController.instance.InitialiseState();	
	}
	
}
