using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	void onTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Debug.Break ();
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
