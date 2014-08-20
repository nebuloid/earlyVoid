using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class ObjectGhost : MonoBehaviour {

	public static ObjectGhost og;

	private float recordTime;
	private bool recording = true;
	private PlatformerCharacter2D character;
	private int runNumber;

	public int ghostSpeed;
	public GameObject target;

	//private ArrayList ghostMovements;
	private ArrayList movements = new ArrayList();
	private ArrayList current = new ArrayList();

	private int TIME = 0;
	private int POSITION_X = 1;
	private int POSITION_Y = 2;
	private int POSITION_Z = 3;
	//private int CROUCHING = 4;
	//private int JUMPING = 5;

	void Awake()
	{
		//make sure there is only ever 1 of these objects

		if (og == null) {
			DontDestroyOnLoad (gameObject);
			og = this;
			runNumber = 1;
		} else if (og != this) {
			Destroy (gameObject);
		} else {
			runNumber++;
		}
		
		Debug.Log("run number = "+runNumber);

		character = GetComponent<PlatformerCharacter2D>();
	}

	void Start()
	{
		recordTime = 0.0f;

	}

	void FixedUpdate () {

		if (recording) {
			current.Add(Time.deltaTime);
			recordTime += Time.deltaTime;
			//may need additional information such as rotation
			current.Add(character.transform.position.x);
			current.Add(character.transform.position.y);
			current.Add(character.transform.position.z);

			//runNumber
			movements.Add(current);
		}

		recording = !recording;

		/// float to int
		//timerInSecond = Mathf.Round (levelTimer);
	}
}
