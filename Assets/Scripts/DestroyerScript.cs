using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
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
