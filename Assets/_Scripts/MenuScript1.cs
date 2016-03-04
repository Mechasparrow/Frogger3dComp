using UnityEngine;
using UnityEngine.UI; //used to put UI elements directly into script
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript1 : MonoBehaviour {

    public bool back;
    // Use this for initialization
    void Start()
    {
        back = false;
    }

   /* public void Back()
    {
        Directions.enabled = false;
        play.enabled = true;
        quit.enabled = true;
        directions.enabled = true;
    }*/

    public void getDirections()
    {
        SceneManager.LoadScene("Directions");
        if(back == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
      

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        //Application.LoadLevel(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void clickback()
    {
        back = true;
    }

}
