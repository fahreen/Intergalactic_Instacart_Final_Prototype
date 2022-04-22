using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    bool finished;
    public Slider timeSlider;

    public float gametime;
    private bool stopTimer;
    public GameObject endCanvas;


    public Text showResult;
    public GameObject gameOver;

    public Canvas timeBarCanvas;
    public GameObject timeBarObject;
    void Awake()
    {
        DontDestroyOnLoad(timeBarCanvas);
        DontDestroyOnLoad(timeBarObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timeSlider.maxValue = gametime;
        timeSlider.value = gametime;
        finished = true;
        gameOver.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float time = gametime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        // string textTime = string.Format
        if ((time <= 0 || Manager.gameOver == true) && finished)
        {
            stopTimer = true;
            Manager.finishTime = time;
            float profit;
            if (time > 245)
            {
                profit = 100 * 0.3f;
            }

            else if (time < 245 && time > 105)
            {
                profit = 100 * 0.15f;
            }

            else if (time < 105 && time > 10)
            {
                profit = 100 * 0.05f;
            }

            else
            {
                profit = 0f;
            }

           

            this.showResult.text = "By completing this order, you've earned: $" + profit.ToString();
            this.endCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            this.gameObject.SetActive(false);


            finished = false;
        }





        if (stopTimer == false)
        {

            timeSlider.value = time;
        }
    }
}
