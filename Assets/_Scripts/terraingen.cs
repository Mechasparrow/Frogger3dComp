using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class terraingen : MonoBehaviour {

    //The exit to the level
    public GameObject exit_prefab;

    //biome that are in the game
    public GameObject ground;
    public GameObject water;
    public GameObject road;
    public GameObject question_trigger;

    //Barrel/Obstacle spawners
    public GameObject LeftBarrelSpawner;
    public GameObject RightBarrelSpawner;

    //Log Spawners
    public GameObject LeftLogSpawner;
    public GameObject RightLogSpawner;

    //The point of rotation for the walls
    public GameObject point_of_rotation;


    //The player object
    public GameObject player;

    //The length of the level
    public float length;

	//When the game starts, Generate the Terrain
	void Start () {
        GenerateTerrain(length);
	}

    //The actual script to generate the terrain
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


        AddWall(defaultenv, z,true);
        AddWall(rightwall, z,true);
		AddWall(leftwall, z,true);
		AddWall(ceiling, z,true);

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









	public void AddWall(GameObject wall, float z, bool isexit)
    {
		List<GameObject> biomeline = GenerateLine(z,isexit);
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





	public List<GameObject> GenerateLine(float z,bool isexit)
    {

        List<GameObject> biomeline = new List<GameObject>();



        for (float i = -4.5f; i <= z; i += 5f)
        {
            float biome = Random.value;
            GameObject go;
			if (i == z && isexit == true) {
				go = Instantiate (exit_prefab);
			}
            else if (i == -4.5f || i == z)
            {
                go = Instantiate(ground) as GameObject;
            }
            else
            {
                if (biome <= 0.4) //40% chance of a water biome spawning
                {
                    go = Instantiate(water) as GameObject;
                }else if (biome > 0.4 && biome <= 0.8) // 40% chance of a road spawning
                {
                    go = Instantiate(road) as GameObject;
                }
                else
                {
                    go = Instantiate(ground);
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
            float direction = Random.value;
            if (biome.tag == "Ground-Water") //Check if the current object is water to generate logs
            {
                
                if (direction <= 0.5f) //50% left, 50% right
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

            }else if (biome.tag == "Road") //Check if its a road to generate cars
            {
                if (direction <= 0.5f) //50% left, 50% right
                {
                    GameObject spawner = Instantiate(LeftBarrelSpawner) as GameObject;
                    Vector3 spawnerPos = spawner.transform.position;
                    spawnerPos.y = 1f;
                    spawnerPos.x = 10f;
                    spawnerPos.z = biome.transform.position.z - 1.5f;
                    spawner.transform.position = spawnerPos;
                    spawner.transform.parent = go.transform;
                }
                else
                {
                    GameObject spawner = Instantiate(RightBarrelSpawner) as GameObject;
                    Vector3 spawnerPos = spawner.transform.position;
                    spawnerPos.y = 1f;
                    spawnerPos.x = -10f;
                    spawnerPos.z = biome.transform.position.z - 1.5f;
                    spawner.transform.position = spawnerPos;
                    spawner.transform.parent = go.transform;
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
            BarrelSpawn bs;

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
            }else if (spawner.GetComponent<BarrelSpawn>() != null)
            {
                bs = spawner.GetComponent<BarrelSpawn>();
                if (spawner.transform.parent.tag == "Wall")
                {
                    bs.inuse = false;
                }
                else
                {
                    bs.inuse = true;
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
