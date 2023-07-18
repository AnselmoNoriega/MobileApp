using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Points : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;
    public int score;
    public int points;
    public int pointsOnClick;
    public float timeCount;
    public int boostTime;

    private float _currentTime;

    void Start()
    {
        _currentTime = 0;

        if (pointsOnClick == 0)
        {
            score = 0;
            pointsOnClick = 1;
            boostTime = 1;
            points = 10;
            timeCount = 10;
        }
    }

    void Update()
    {
        pointsText.text = score.ToString();
    }

    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= (timeCount / boostTime))
        {
            score += points;
            _currentTime = 0;
        }
        
    }

    public void CoockieOnClick()
    {
        score += pointsOnClick;
    }
}
