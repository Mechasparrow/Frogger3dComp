using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject prefab_explosion;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
			GameObject explosion = Instantiate (prefab_explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			c.gameObject.SetActive (false);
            print("Game End");
        }
    }



}
