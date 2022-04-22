using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{

   public void  StartGame()
    {
        SceneManager.LoadScene("Scenes/Company");
    }

    public void StartShopping1()
    {
        SceneManager.LoadScene("Scenes/shopping1");
    }

    public void StartDelivery1()
    {
        SceneManager.LoadScene("Scenes/Delivery1");
    }


}
