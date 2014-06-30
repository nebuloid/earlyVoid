using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void onTriggerEnter2D(Collider2D other){
		Debug.Log("Trigger Enter!");
		if(other.tag == "Player"){
			Debug.Log("Player Dies!");
			Destroy (other.gameObject);
			Application.LoadLevel(Application.loadedLevelName);
			return;
		}

		if(other.gameObject.transform.parent){
			//destroy the parent object
			Destroy (other.gameObject.transform.parent.gameObject);
		}else{
			//destroy the object
			Destroy (other.gameObject);
		}
	}
}
