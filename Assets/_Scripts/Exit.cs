using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    public int level = 1;
    public CameraFollow cf = Camera.main.GetComponent<CameraFollow>();
	public GameObject prefab_explosion;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
			GameObject explosion = Instantiate (prefab_explosion) as GameObject;
			explosion.transform.position = gameObject.transform.position;
			c.gameObject.SetActive (false);

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }else
            {
                SceneManager.LoadScene(0);
            }









            print("Game End");
        }
    }



}
