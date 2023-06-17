using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    private Text score;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score").GetComponent<Text>();
        count = 0;
        score.text = "0"; 
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int point = 10)
    {
        count += point;
        score.text = count.ToString(); 
    }
}
