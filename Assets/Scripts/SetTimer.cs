using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetTimer : MonoBehaviour {
    private int minite;
    private float second;
    private int oldSecond;
    private bool timerFlag = true;
    public Text timer;
    // Use this for initialization
    void Start () {
        minite = 0;
        second = 0;
        oldSecond = 0;
        timer = this.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale > 0)
        {
            second += Time.deltaTime;
            if (second >= 60.0f)
            {
                minite++;
                second = second - 60;
            }
            if ((int)second != oldSecond)
            {
                timer.text = minite.ToString("00") + ":" + ((int)(second)).ToString("00");
            }
            oldSecond = (int)(second);
        }
    }
}
