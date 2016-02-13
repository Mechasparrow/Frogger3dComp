using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {

    public GameObject Barrel_prefab;
    public Transform barrel_spawn_point;



	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBarrel", 0.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void spawnBarrel()
    {
        GameObject go = Instantiate(Barrel_prefab) as GameObject;
        go.transform.position = barrel_spawn_point.position;


    }


}
