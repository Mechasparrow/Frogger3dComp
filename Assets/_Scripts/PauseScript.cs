using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

    GameObject PauseMenu;
    bool paused;
    bool muted;
    [SerializeField]
    Text mutetext;

	// Use this for initialization
	void Start () {
        paused = false;
        PauseMenu = GameObject.Find("Pause Game");
        muted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))  //quits program immediately
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if(muted)
        {
            AudioListener.volume = 0;
            mutetext.text = "Unmute";
        }
        else
        {
            AudioListener.volume = 1;
            mutetext.text = "Mute";
        }
	}

    public void Resume()
    {
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*public void Save()
    {
        PlayerPrefs.SetInt("currentscenesave", Application.loadedLevel);
    }

    public void Load()
    {
        Application.LoadLevel(PlayerPrefs.GetInt("currentscenesafe"));
    }*/

    public void Mute()
    {
        muted = !muted;
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
