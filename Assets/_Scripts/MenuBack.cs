using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBack : MonoBehaviour {

	public void menuBack()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
