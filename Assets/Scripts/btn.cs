using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn : MonoBehaviour
{
    SceneLoader s = new SceneLoader();
    public GameObject c;
    public void StartGame()
    {
        s.StartGame();
        if(c!= null)
        {
            c.SetActive(false);
        }
    }
}
