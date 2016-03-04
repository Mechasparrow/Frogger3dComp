using UnityEngine;
using UnityEngine.SceneManagement; //used for our SceneManager
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;

public class menuScript : MonoBehaviour
{
    public Canvas DirectionsMenu;
    public Canvas CharSelect;
    public Canvas LevelSelect;



    public Button startText;
    public Button exitText;
    public Button directions;
    public Button levelselect;

    public void Start()

    {
        DirectionsMenu = DirectionsMenu.GetComponent<Canvas>();
        CharSelect = CharSelect.GetComponent<Canvas>();
        LevelSelect = LevelSelect.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        directions = directions.GetComponent<Button>();
        levelselect = levelselect.GetComponent<Button>();

        DirectionsMenu.enabled = false; //deactivates other menus
        CharSelect.enabled = false;
        LevelSelect.enabled = false;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //quits program immediately after escape key is entered
        {
            Application.Quit();
        }
    }

    public void getDirections() //will be used on Directions button

    {
        DirectionsMenu.enabled = true; //Enable directions menu options

        startText.enabled = false; //then disable other Menu options
        exitText.enabled = false;
        directions.enabled = false;
        levelselect.enabled = false;

    }

    public void getLevelSelect ()
    {
        LevelSelect.enabled = true;

        startText.enabled = false; //then disable other Menu options
        exitText.enabled = false;
        directions.enabled = false;
        levelselect.enabled = false;

    }

    public void SelectLevel(int x)
    {
        if(x==1)
        {
             SceneManager.LoadScene("Level1");
        }
        else if (x==2)
        {
           SceneManager.LoadScene("Level2");
        }
        else if (x==3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void Back() //this function will be used for the back button in menu

    {
        DirectionsMenu.enabled = false; //we'll disable the quit menu, meaning it won't be visible anymore
        CharSelect.enabled = false;
        LevelSelect.enabled = false;

        startText.enabled = true; //enable the Play and Exit buttons again so they can be clicked
        exitText.enabled = true;
        directions.enabled = true;
        levelselect.enabled = true;

    }

    public void getCharSelect()  //used to trigger character selection after clicking "Play"
    {
        CharSelect.enabled = true;

        startText.enabled = false; 
        exitText.enabled = false;
        directions.enabled = false;
        levelselect.enabled = false;
    }

    /*public void select (int x) //which character player selects
    {
        StartLevel(x);
    }*/

    public void StartLevel() //Used after player selects his/her character

    {
        SceneManager.LoadScene("level1") ; //loads first level
        print("level start");
        
    }

    public void Quit() //Used if player selects Quit

    {
        Application.Quit();

    }

}
