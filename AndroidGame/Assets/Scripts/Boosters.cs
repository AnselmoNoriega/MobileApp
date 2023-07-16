using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Boosters : MonoBehaviour
{
    [SerializeField]
    private Points score;
    [SerializeField]
    private List<TextMeshProUGUI> pricesText;
    [SerializeField]
    private List<float> pricesNums;
    [SerializeField]
    private List<int> boostAmount;

    private bool _isTimerActive;
    private float _countDown;

    private void Start()
    {
        for (int i = 0; i < pricesNums.Count; i++)
        {
            pricesText[i].text = "$ " + pricesNums[i].ToString();
        }

        _isTimerActive = false;
    }

    private void Update()
    {
        TimerLogic();
    }

    public void BoostTime(int boosterIndex)
    {
        if (!_isTimerActive)
        {
            score.boostTime = boostAmount[boosterIndex];
            //wallet -= pricesNums[boosterIndex];
            _countDown = 30.0f;
            _isTimerActive = true;
        }
    }

    private void TimerLogic()
    {
        if (_isTimerActive)
        {
            _countDown -= Time.deltaTime;

            if (_countDown <= 0)
            {
                _isTimerActive = false;
                score.boostTime = 1;
            }
        }
    }
}
