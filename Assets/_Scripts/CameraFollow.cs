using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float offsetz;
    public float offsety;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPos = gameObject.transform.position;
        Vector3 playerPos = player.position;

        cameraPos.y = playerPos.y + offsety;
        cameraPos.z = playerPos.z + offsetz;



        gameObject.transform.position = cameraPos;






	}
}
