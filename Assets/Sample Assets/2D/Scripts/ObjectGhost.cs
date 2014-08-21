using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlatformerCharacter2D))]
[RequireComponent(typeof(Camera2DFollow))]
public class ObjectGhost : MonoBehaviour {

	private ObjectGhost og;
	static ObjectGhost ghost;

	private float recordTime;
	private bool recording = true;
	private PlatformerCharacter2D character;
	private Camera2DFollow camera;
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

	private Vector3 originalPosition;
	private Quaternion originalRotation;
	
	private Vector3 cameraOriginalPosition;
	
	void Awake()
	{
		
		character = GetComponent<PlatformerCharacter2D>();
		GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cameraObject.GetComponent<Camera2DFollow>();
		runNumber = 1;

		//make sure there is only ever 1 of these objects
/*
		if (og == null) {
			DontDestroyOnLoad(gameObject);
			DontDestroyOnLoad(character);

			og = this;
			runNumber = 1;
			Debug.Log("First Time Initialize.");
		} else if(og != this){
			Destroy(gameObject);
			Destroy(character);
			runNumber++;
			Debug.Log("Destroy");
		}
*/
		
	}

	void Start()
	{
		recordTime = 0.0f;
		originalPosition = character.transform.position;
		originalRotation = character.transform.rotation;
		
		cameraOriginalPosition = camera.transform.position;
	}

	void FixedUpdate () {

		if (recording) {
			recordTime += Time.deltaTime;

			current.Add(recordTime);
			current.Add(character.transform.position); 
			current.Add(character.transform.rotation);

			//runNumber
			movements.Add(current);
		}

		recording = !recording;

		/// float to int
		//timerInSecond = Mathf.Round (levelTimer);
	}

	public void Reset() {
		recordTime = 0.0f;
		character.transform.position = originalPosition;
		character.transform.rotation = originalRotation;
		camera.transform.position = cameraOriginalPosition;

		current.Clear();
		runNumber += 1;
		Debug.Log(runNumber);
		//TODO: NOW we need to find a way to replay the last ghost
	}
}

