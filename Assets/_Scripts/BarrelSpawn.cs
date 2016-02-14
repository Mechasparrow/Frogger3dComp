using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {

    public GameObject Barrel_prefab;
    public float speed;
    public float barrel_speed;
    public string direction;


	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBarrel", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void spawnBarrel()
    {
        GameObject go = Instantiate(Barrel_prefab) as GameObject;
        go.transform.position = gameObject.transform.position;
        Barrel bar = go.GetComponent<Barrel>();
        bar.speed = barrel_speed; 
        bar.direction = direction;

    }


}
