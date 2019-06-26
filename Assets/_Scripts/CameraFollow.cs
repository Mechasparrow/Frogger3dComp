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
        float vertical = Input.GetAxisRaw("Vertical");


        if (vertical == 1)
        {
            Camera cam = gameObject.GetComponent<Camera>();
            Vector3 cam_pos = gameObject.transform.position;

         
            cam_pos.y = player.transform.position.y + offsety;
            cam_pos.z = player.transform.position.z + offsetz;
            gameObject.transform.position = cam_pos;
        }
        
       
	}

    public void respawn_player()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        Vector3 cam_pos = player.transform.position;

        cam_pos.y += offsety;
        cam_pos.z += offsetz;

        gameObject.transform.position = cam_pos;
    }



}
