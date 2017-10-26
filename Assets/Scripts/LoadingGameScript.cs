using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadingGameScript : MonoBehaviour {

	// Use this for initialization
	public void save () {
        Debug.Log("Deos this get called?");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log("Path: " + Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file, PersistenceController.instance);
        file.Close();
	}
	
	// Update is called once per frame
	public void load () {
        Debug.Log("Deos this get called?");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        PersistenceController.instance = (PersistenceController)(bf.Deserialize(file));
		PersistenceController.instance.loadGame = true;
        file.Close();
    }
}
