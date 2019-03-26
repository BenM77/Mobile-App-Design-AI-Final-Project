//Ben Michael and Tristan Hildahl
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour {

public void selectScene()
    {
        //This should be placed on all buttons in the main menu 
        switch (this.gameObject.name)
        {
            //To play main game
            case "Menu":
                SceneManager.LoadScene("Menu");
                break;
            case "Main":
                SceneManager.LoadScene("Main");
                break;
            case "Boomer-Run!":
                SceneManager.LoadScene("Boomer-Run!");
                break;
/*            //To play timed mode
            case "TimeGameButton":
                SceneManager.LoadScene("TimeGame");
                break;
            //To play a survival mode
            case "SurvivalGameButton":
                SceneManager.LoadScene("SurvivalGame");
                break;
*/           
        }
    }
}
