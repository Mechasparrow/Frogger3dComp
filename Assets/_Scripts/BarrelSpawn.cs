using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {

    public GameObject Barrel_prefab;
    public float speed;
    public float barrel_speed;
    public string direction;
    public bool inuse = true;


    // Use this for initialization
    void Start () {
        InvokeRepeating("spawnBarrel", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
		if (inuse == false) {
			GameObject[] barrels = GameObject.FindGameObjectsWithTag ("Barrel");
			foreach (GameObject barrel in barrels) {
				if (barrel.transform.parent == gameObject.transform) {
					Destroy (barrel);
				}
			}
		}
	}

    void spawnBarrel()
    {
        GameObject go = Instantiate(Barrel_prefab) as GameObject;
        go.transform.position = gameObject.transform.position;
        Barrel bar = go.GetComponent<Barrel>();
        bar.speed = barrel_speed; 
        bar.direction = direction;
        go.transform.parent = gameObject.transform;

        if (inuse == false)
        {
            Destroy(go);
        }


    }


}
