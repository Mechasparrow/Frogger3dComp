using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    // Use this for initialization
    bool press;
    Vector2 simple_pos;
    public Transform spawn_point;



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


        //Horizontal Movement

        if (Horizontal > 0 && press == false && simple_pos.x < 2)
        {
            simple_pos.x += 1;
            temp_pos.x += 2.5f;
            press = true;
        }else if (Horizontal < 0 && press == false && simple_pos.x > -2)   
        {
            simple_pos.x -= 1;
            temp_pos.x -= 2.5f;
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

        gameObject.transform.position = temp_pos;



	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrel") {
            gameObject.transform.position = spawn_point.transform.position;
            simple_pos = new Vector2(0f, 0f);
        }

    }


}
