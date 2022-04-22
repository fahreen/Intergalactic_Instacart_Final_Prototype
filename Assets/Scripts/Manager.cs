using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    public static bool gameOver = false;
    public static float finishTime;
   // public GameObject instructions;
    public static int  itemCount = 0;
    public static bool inCombat;
    public static bool doneShopping;



    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {


        inCombat = false;
        doneShopping = false;
       
        // instructions.SetActive(true);
        // Debug.Log("Hello");
        //  StartCoroutine(Delay2());
    }

    IEnumerator Delay2()
    {

        yield return new WaitForSeconds(3);

       // instructions.SetActive(false);
    }

}



