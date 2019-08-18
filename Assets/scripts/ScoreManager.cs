using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    Text text;
    int score = 0;

    public static ScoreManager Instance;

	void Start ()
    {
        Instance = this;
        text = GetComponent<Text>();
	}
	
    public void ChangeScore(int add)
    {
        score += add;
        text.text = "Score : " + score;
    }
}
