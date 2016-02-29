using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerControl : MonoBehaviour {

    // Use this for initialization
    bool press;
    Vector2 simple_pos;
    public Transform spawn_point;
	public GameObject prefab_explosion;
    public bool touching_ground = false;
    public Camera cam;
    public GameObject envs;
    public bool new_wall = false;
    public GameObject current_wall;

    public float bounds = 10f;


    float time_since_intersection = 0f;
    



    public List<GameObject> collidedobjects = new List<GameObject>();


    void Start () {
        press = false;
        simple_pos.x = 0;
        simple_pos.y = 0;
	}

    


	// Update is called once per frame
	void Update () {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        
        if (touching_ground == false)
        {
            time_since_intersection += Time.deltaTime;
        }

        Vector3 temp_pos = gameObject.transform.position;


        //Horizontal Movement

        if (Horizontal > 0 && temp_pos.x < 15)
        {
            temp_pos.x += 10f * Time.deltaTime;
            press = true;
        }else if (Horizontal < 0 && temp_pos.x > -15)   
        {
            temp_pos.x -= 10f * Time.deltaTime;
            press = true;
        }
        //Vertical Movement
        
        else if (Vertical > 0 && press == false)
        {
            temp_pos.z += 2.5f;
            press = true;
        }

        else if (Vertical < 0 && press == false)
        {
            temp_pos.z -= 2.5f;
            press = true;
        }

        else if (Vertical == 0 && Horizontal == 0)
        {
            press = false;
        }

        gameObject.transform.position = temp_pos;

        if (collidedobjects.Count > 0)
        {
            for (int i = 0; i != collidedobjects.Count; i++)
            {
                if (new_wall == true)
                {
                    current_wall.tag = "Wall";
                    current_wall = collidedobjects[i].transform.parent.gameObject;
                    current_wall.tag = "Reg-Wall";
                    new_wall = false;
                }

                else if (collidedobjects [i].tag == "Ground-Reg") {

                    if (collidedobjects [i].transform.parent != null)
                    {
                        if (collidedobjects[i].transform.parent.tag == "Wall")
                        {
                            print("not a reg");

                            RotateRight();



                        }
                    }
                    else
                    {
                        print("Ground reg");
                    }

                    
                    break;
				} else if (collidedobjects [i].tag == "Barrel" || collidedobjects [i].tag == "Ground-Water") {
                    ExplodeSelf();
                }
            }
        }


        if (time_since_intersection > 100f/1000f && touching_ground == false)
        {
            time_since_intersection = 0f;
            ExplodeSelf();

        }else if (time_since_intersection > 100f/1000f && touching_ground != false)
        {
            time_since_intersection = 0f;
        }



        collidedobjects = new List<GameObject>();

	}

    void OnTriggerEnter(Collider other)
    {
        collidedobjects.Add(other.gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        touching_ground = true;
    }
    public void OnTriggerExit(Collider other)
    {
        touching_ground = false;
    }



	void Respawn(){
		gameObject.SetActive (true);
		gameObject.transform.position = spawn_point.transform.position;

        cam.gameObject.GetComponent<CameraFollow>().respawn_player();


	}

    void RotateRight()
    {
        Vector3 tempPos = gameObject.transform.position;
        tempPos.x = 0;
        tempPos.z = -6;
        gameObject.transform.position = tempPos;


        Vector3 eulerAngles = envs.transform.eulerAngles;
        eulerAngles.x += 90;

        envs.transform.eulerAngles = eulerAngles;
       
        tempPos = envs.transform.position;
        envs.transform.position = tempPos;

        new_wall = true;


    }






    public void ExplodeSelf()
    {
        GameObject explosion = Instantiate(prefab_explosion) as GameObject;
        explosion.transform.position = gameObject.transform.position;

        gameObject.SetActive(false);
        Invoke("Respawn", 1.1f);
        simple_pos = new Vector2(0f, 0f);
    }


}
