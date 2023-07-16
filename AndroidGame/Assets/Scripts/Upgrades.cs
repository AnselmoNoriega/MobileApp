using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Upgrades : MonoBehaviour
{
    [SerializeField]
    private Points score;
    [SerializeField]
    private List<TextMeshProUGUI> prices;
    [SerializeField]
    private List<int> pricesNums;

    private int _extrapoints;
    private int _cookieLevel;
    private int _extraOnClickPoints;

    private void Start()
    {
        for (int i = 0; i < pricesNums.Count; i++)
        {
            prices[i].text = "$ " + pricesNums[i].ToString();
        }

        _cookieLevel = 1;
        _extrapoints = 0;
        _extraOnClickPoints = 0;
    }

    public void MoreCookiesGained()
    {
        if (pricesNums[0] <= score.score)
        {
            _extrapoints += (1 * _cookieLevel);
            score.points += _extrapoints;
            score.score -= pricesNums[0];
            pricesNums[0] *= 2;
        }
    }

    public void MoreClickPoints()
    {
        if (pricesNums[1] <= score.score)
        {
            _extraOnClickPoints += (1 * _cookieLevel);
            score.pointsOnClick += _extraOnClickPoints;
            score.score -= pricesNums[1];
            pricesNums[1] *= 2;
        }
    }

    public void LessTimeToEarn()
    {
        if (pricesNums[2] <= score.score)
        {
            score.timeCount /= 1 + (_cookieLevel / 10);
            score.score -= pricesNums[2];
            pricesNums[2] *= 2;
        }
    }

    public void IncreaseLevel()
    {
        if (pricesNums[3] <= score.score)
        {
            _cookieLevel += 1;
            score.score -= pricesNums[3];
            pricesNums[3] *= 2;
        }
    }
}