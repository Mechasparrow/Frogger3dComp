using UnityEngine;
using System.Collections;

public class LogSpawner : MonoBehaviour {

	public GameObject Log_prefab;
	public float speed;
	public float log_speed;
	public string direction;




	// Use this for initialization
	void Start () {
		InvokeRepeating("spawnLog", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnLog(){
		GameObject go = Instantiate(Log_prefab) as GameObject;
		go.transform.position = gameObject.transform.position;
		Log log = go.GetComponent<Log>();
		log.timethres = log_speed; 
		log.direction = direction;

		print ("log spawn");
	}
}
