using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	HUDScript hud;

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){
			//may be inificiant
			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			
			hud.UpdateScore(10);
			Destroy(this.gameObject);
		}
	}	

}
