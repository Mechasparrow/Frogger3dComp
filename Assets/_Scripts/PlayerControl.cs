using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    // Use this for initialization
    bool press;
    Vector2 simple_pos;
    public Camera cam; 

    void Start () {
        press = false;
        simple_pos.x = 0;
        simple_pos.y = 0;
	}

    


	// Update is called once per frame
	void Update () {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");


        Vector3 temp_pos = gameObject.transform.position;
        Vector3 cam_angles = new Vector3(0, 0, 0);


        //Horizontal Movement

        if (Horizontal > 0 && press == false && simple_pos.x < 1)
        {
            simple_pos.x += 1;
            temp_pos.x += 5f;
            press = true;
        }else if (Horizontal < 0 && press == false && simple_pos.x > -1)   
        {
            simple_pos.x -= 1;
            temp_pos.x -= 5f;
            press = true;
        }
        //Vertical Movement
        
        else if (Vertical > 0 && press == false)
        {
            simple_pos.y += 1;
            temp_pos.z += 2.5f;
            press = true;
        }
        else if (Vertical < 0 && press == false)
        {
            simple_pos.y -= 1;
            temp_pos.z -= 2.5f;
            press = true;
        }else if (Vertical == 0 && Horizontal == 0)
        {
            press = false;
        }
        


        if (Input.GetKeyDown(KeyCode.Q)){
            Vector3 angles = cam.transform.rotation.eulerAngles;
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 angles = cam.transform.rotation.eulerAngles;

        }



        gameObject.transform.position = temp_pos;



	}
}
