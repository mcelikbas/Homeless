using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SwitchScene : MonoBehaviour {



    public void switchToMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void switchToMainScene () {
        SceneManager.LoadScene(1);
	}
	
    public void quitGame ()
    {
        Application.Quit();
    }



}
