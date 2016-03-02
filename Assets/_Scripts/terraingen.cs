using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class terraingen : MonoBehaviour {

	public GameObject ground;
    public GameObject water;
    public GameObject exit_prefab;
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

        GameObject exit = Instantiate(exit_prefab) as GameObject;
        Vector3 exitPos = exit.transform.position;
        exitPos.z = z - 0.5f;
        exitPos.x = 2.5f;
        exit.transform.position = exitPos;
        exit.transform.parent = defaultenv.transform;









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

        CheckSpawners();

        

    }









    public void AddWall(GameObject wall, float z)
    {
        List<GameObject> biomeline = GenerateLine(z);
        AddSpawners(biomeline, wall);



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

    public void AddSpawners(List<GameObject> biomeline, GameObject go)
    {
        foreach (GameObject biome in biomeline)
        {
            if (biome.tag == "Ground-Water")
            {
                float direction = Random.value;
                if (direction <= 0.5)
                {
                    //go left
                    GameObject spawner = Instantiate(LeftLogSpawner) as GameObject;
                    Vector3 spawnerPos = spawner.transform.position;
                    spawnerPos.y = 0.3f;
                    spawnerPos.x = 10f;
                    spawnerPos.z = biome.transform.position.z - 1.5f;
                    spawner.transform.position = spawnerPos;
                    spawner.transform.parent = go.transform;

                    
                    GameObject spawner2 = Instantiate(RightLogSpawner) as GameObject;
                    Vector3 spawnerPos2 = spawner.transform.position;
                    spawnerPos2.y = 0.3f;
                    spawnerPos2.x = -10f;
                    spawnerPos2.z = spawnerPos.z + 2.5f;
                    spawner2.transform.position = spawnerPos2;
                    spawner2.transform.parent = go.transform;
                    





                }
                else
                {
                    //go right
                    GameObject spawner = Instantiate(RightLogSpawner) as GameObject;
                    Vector3 spawnerPos = spawner.transform.position;
                    spawnerPos.y = 0.3f;
                    spawnerPos.x = -10f;
                    spawnerPos.z = biome.transform.position.z - 1.5f;
                    spawner.transform.position = spawnerPos;
                    spawner.transform.parent = go.transform;

                    
                    GameObject spawner2 = Instantiate(LeftLogSpawner) as GameObject;
                    Vector3 spawnerPos2 = spawner.transform.position;
                    spawnerPos2.y = 0.3f;
                    spawnerPos2.x = 10f;
                    spawnerPos2.z = spawnerPos.z + 2.5f;
                    spawner2.transform.position = spawnerPos2;
                    spawner2.transform.parent = go.transform;
                    


                }

            }
        }
    }

    public static void CheckSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(true);
        }
        print(spawners.Length);

        foreach (GameObject spawner in spawners)
        {
            LogSpawner ls;
            if (spawner.GetComponent<LogSpawner>() != null)
            {
                ls = spawner.GetComponent<LogSpawner>();
                if (spawner.transform.parent.tag == "Wall")
                {
                    ls.inuse = false;
                }
                else
                {
                    ls.inuse = true;
                }
            }


            
        }

        GameObject[] logs = GameObject.FindGameObjectsWithTag("Log");
        foreach (GameObject log in logs)
        {
            Destroy(log);
        }




    }









}
