using UnityEngine;
using System.Collections;

public class Log : MonoBehaviour {
    public string direction;
	public float speed;
    GameObject player = null;
    float elapsedtime;
	float elapsedtime2;
    int allowthing = -1;
	// Use this for initialization
	void Start () {
        elapsedtime = 0f;
		elapsedtime2 = 0f;
	}

    void Update()
    {

        //get player input
        float Horizontal = 0f;
        float Vertical = 0f;

        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        //get the elapsedtime
        elapsedtime += Time.deltaTime;

        if (player != null)
        {
            elapsedtime2 += Time.deltaTime;
        }

        Vector3 TempPos = gameObject.transform.position;
        Vector3 PlayerPos = new Vector3(0f,0f,0f);
        if (player != null)
        {
            PlayerPos = player.transform.position;
        }

		if (elapsedtime2 > 80f/1000 && player != null) {
			allowthing += 1;
			elapsedtime2 = 0;
			print ("20 ms");
		}	

        if (Horizontal != 0 || Vertical != 0)
        {
            if (player != null && player.layer == 9 && allowthing > 0)
            {
                clearplayer();
                Destroy(gameObject);
            }

        }


			
            switch (direction)
            {
			case "right":
			TempPos.x += speed * Time.deltaTime;
                    if (player != null)
                    {
						PlayerPos.x += speed * Time.deltaTime;
                    }
                    break;
                case "left":
			TempPos.x -= speed * Time.deltaTime;
                    if (player != null)
                    {
				PlayerPos.x -= speed * Time.deltaTime;
                    }
                    break;
            }
            elapsedtime = 0f;
        

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
            
        }if (other.gameObject.tag == "LogDestroy" && other.gameObject.transform.parent == gameObject.transform.parent)
        {
            
            if (player != null)
            {
                PlayerControl player_cont = player.GetComponent<PlayerControl>();
                player_cont.ExplodeSelf();
            }
            Destroy(gameObject);
            

        }
    }
    void clearplayer()
    {
        player.layer = 0;
        PlayerControl player_cont = player.GetComponent<PlayerControl>();
        player_cont.touching_ground = false;
        allowthing = 0;
        player = null;
    }

}
