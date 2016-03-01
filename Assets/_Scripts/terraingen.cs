using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class terraingen : MonoBehaviour {

	public GameObject ground;
    public GameObject water;
    public GameObject exit;
    public GameObject BarrelSpawner;
    public GameObject LeftLogSpawner;
    public GameObject RightLogSpawner;
    public GameObject point_of_rotation;
    public GameObject player;


	// Use this for initialization
	void Start () {
        GenerateTerrain(20.5f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void GenerateTerrain(float z)
    {




        Vector3 eulerangles;
        GameObject defaultenv = new GameObject();
        defaultenv.tag = "Reg-Wall";
        defaultenv.name = "Floor";
        PlayerControl pc = player.GetComponent<PlayerControl>();
        pc.current_wall = defaultenv;


        GameObject rightwall = new GameObject();
        rightwall.tag = "Wall";
        rightwall.name = "Right Wall";

        GameObject leftwall = new GameObject();
        leftwall.tag = "Wall";
        leftwall.name = "Left Wall";

        GameObject ceiling = new GameObject();
        ceiling.tag = "Wall";
        ceiling.name = "Ceiling";


        AddWall(defaultenv, z);
        AddWall(rightwall, z);
        AddWall(leftwall, z);
        AddWall(ceiling, z);

        defaultenv.transform.parent = point_of_rotation.transform;


        rightwall.transform.parent = point_of_rotation.transform;
        eulerangles = new Vector3(0f, 0f, 0f);
        eulerangles.z = 90;
        rightwall.transform.eulerAngles = eulerangles;

        Vector3 rightwallpos = leftwall.transform.position;
        rightwallpos.x = 13f + 2.5f;
        rightwallpos.y = 13f - 2.5f;
        rightwallpos.z = 0f;
        rightwall.transform.position = rightwallpos;





        leftwall.transform.parent = point_of_rotation.transform;
        eulerangles = new Vector3(0f, 0f, 0f);
        eulerangles.z = 270;
        leftwall.transform.eulerAngles = eulerangles;

        Vector3 leftwallpos = leftwall.transform.position;
        leftwallpos.x = -13f + 2.5f;
        leftwallpos.y = 2.5f + 13f;
        leftwallpos.z = 0f;
        leftwall.transform.position = leftwallpos;


        ceiling.transform.parent = point_of_rotation.transform;
        eulerangles = new Vector3(0f, 0f, 0f);
        eulerangles.z = 180;
        ceiling.transform.eulerAngles = eulerangles;

        Vector3 ceilingpos = ceiling.transform.position;
        ceilingpos.x = -10f + 7.5f + 5f + 2.5f;
        ceilingpos.y = 13f + 13f;
        ceilingpos.z = 0f;
        ceiling.transform.position = ceilingpos;




    }

    public void AddWall(GameObject wall, float z)
    {
        List<GameObject> biomeline = GenerateLine(z);


        foreach (GameObject go in biomeline)
        {
            go.transform.parent = wall.transform;




            //right and left side
            for (float i = -7.5f; i <= 12.5f; i += 5)
            {
                if (i != 2.5f)
                {
                    GameObject sideblock = Instantiate(go) as GameObject;
                    Vector3 sideblockpos = sideblock.transform.position;
                    sideblockpos.x = i;
                    sideblock.transform.position = sideblockpos;
                    sideblock.transform.parent = wall.transform;
                }
            }

        }
    }





    public List<GameObject> GenerateLine(float z)
    {

        List<GameObject> biomeline = new List<GameObject>();



        for (float i = -4.5f; i <= z; i += 5f)
        {
            float biome = Random.value;
            GameObject go;

            if (i == -4.5f || i == z)
            {
                go = Instantiate(ground) as GameObject;
            }
            else
            {
                if (biome <= 0.4)
                {
                    go = Instantiate(water) as GameObject;
                }
                else
                {
                    go = Instantiate(ground) as GameObject;
                }
            }


            Vector3 bioPos = go.transform.position;
            bioPos.x = 2.5f;
            bioPos.y = 0f;
            bioPos.z = i;

            go.transform.position = bioPos;
            biomeline.Add(go);
        }

        return biomeline;
    }







}
