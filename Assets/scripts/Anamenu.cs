using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anamenu : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene(2);

    }
    public void Credit()
    {

        SceneManager.LoadScene(1);
    }
    public void QuitButton()
    {
        Application.Quit(); 
    }


}
