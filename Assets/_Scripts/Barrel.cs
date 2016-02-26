using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    bool touching_ground;
    public string direction;
    public float speed;

	// Use this for initialization
	void Start () {
        touching_ground = false;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Vector3 vel = new Vector3(0f, 0f, 0f);

        switch (direction)
        {
            case "right":
                vel.x = speed * Time.deltaTime;
                break;
            case "left":
                vel.x = speed * Time.deltaTime * -1;
                break;
        }
        rb.velocity = vel;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "BarrelDestroy")
        {
            Destroy(gameObject);
        }
    }



}
