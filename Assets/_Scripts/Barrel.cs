using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    bool touching_ground;


	// Use this for initialization
	void Start () {
        touching_ground = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (touching_ground == true) {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(10f, 0f, 0f);
        }

        
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Ground")
        {
            touching_ground = true;
            print("true");
        }
    }


}
