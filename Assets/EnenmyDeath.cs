using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyDeath : MonoBehaviour
{
    public int life;

    private void Start()
    {
        life = 3;
    }

    private void Update()
    {
        if(life == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
