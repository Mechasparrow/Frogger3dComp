using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
    public Light l; 
	// Use this for initialization
	void Start () {
        l.gameObject.SetActive(false);
        Invoke("lightup", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void lightup()
    {
        l.gameObject.SetActive(true);
    }


}
