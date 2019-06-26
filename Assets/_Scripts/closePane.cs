using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class closePane : MonoBehaviour {

    Button b;
    public Canvas c;
    public int question = 0;




	// Use this for initialization
	void Start () {
        b = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void buttonHit()
    {
        print("buttonhit");
        question++;
        c.gameObject.SetActive(false);

    }


}
