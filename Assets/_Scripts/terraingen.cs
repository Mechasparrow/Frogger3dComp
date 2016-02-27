using UnityEngine;
using System.Collections;

public class terraingen : MonoBehaviour {

	public GameObject ground;


	// Use this for initialization
	void Start () {
		GenerateTerrain ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateTerrain(){
		for (int x = 0; x != 10; x++) {
			GameObject go = Instantiate (ground) as GameObject;
			Vector3 tempPos = new Vector3 (x * 10000, 0, 0);
			go.transform.position = tempPos;
		}
	}


}
