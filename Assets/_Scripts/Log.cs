using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {
bool touching_ground;
    public string direction;
    public float timethres = 500f;
    GameObject player = null;
    float elapsedtime;
    int allowthing = 0;
	// Use this for initialization
	void Start () {
        touching_ground = false;
        elapsedtime = 0f;
	}

    void Update()
    {
        float Horizontal = 0f;
        float Vertical = 0f;

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");


        elapsedtime += Time.deltaTime;

        Vector3 TempPos = gameObject.transform.position;
        Vector3 PlayerPos = new Vector3(0f,0f,0f);
        if (player != null)
        {
            PlayerPos = player.transform.position;
        }

        if (Horizontal != 0 || Vertical != 0)
        {
            if (player != null && player.layer == 9 && allowthing > 0)
            {
                clearplayer();
                Destroy(gameObject);
            }

        }
        if (elapsedtime > timethres/1000)
        {
            switch (direction)
            {
                case "right":
                    TempPos.x += 2.5f;
                    if (player != null)
                    {
                        PlayerPos.x += 2.5f;
                        allowthing += 1;
                    }
                    break;
                case "left":
                    TempPos.x -= 2.5f;
                    if (player != null)
                    {
                        PlayerPos.x -= 2.5f;
                        allowthing += 1;
                    }
                    break;
            }
            elapsedtime = 0f;
        }

        gameObject.transform.position = TempPos;
        if (player != null)
        {
            player.transform.position = PlayerPos;
        }

        
    }






    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            player.layer = 9;
            print("Player");
            
        }else if (other.gameObject.tag == "LogDestroy")
        {
            Destroy(gameObject);
        }
    }
    void clearplayer()
    {
        player.layer = 0;
        allowthing = 0;
        player = null;
    }

}
