using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
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

    private List<int> listKeys = new List<int>()
    {
        45,
        74,
        127,
        1004
    };

    private List<string> keys = new List<string>()
    {
        "Score",
        "Points",
        "pointsOnClick",
        "timeCount",
        "PricesNums",
        "extrapoints",
        "cookieLevel",
        "extraOnClickPoints"
    };

    private void OnApplicationQuit()
    {
        SeerializeData();
    }
    public void MoreCookiesGained()
    {
        if (pricesNums[0] <= score.score)
        {
            _extrapoints += (1 * _cookieLevel);
            score.points += _extrapoints;
            score.score -= pricesNums[0];
            pricesNums[0] *= 3;
            prices[0].text = "$ " + pricesNums[0].ToString();
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
            prices[1].text = "$ " + pricesNums[1].ToString();
        }
    }

    public void LessTimeToEarn()
    {
        if (pricesNums[2] <= score.score)
        {
            score.timeCount /= 1 + (_cookieLevel / 10);
            score.score -= pricesNums[2];
            pricesNums[2] *= 4;
            prices[2].text = "$ " + pricesNums[2].ToString();
        }
    }

    public void IncreaseLevel()
    {
        if (pricesNums[3] <= score.score)
        {
            _cookieLevel += 1;
            score.score -= pricesNums[3];
            pricesNums[3] *= 3;
            prices[3].text = "$ " + pricesNums[3].ToString();
        }
    }

    private void SerializeList()
    {
        for (int i = 0; i < pricesNums.Count; i++)
        {
            PlayerPrefs.SetInt(listKeys[i].ToString(), pricesNums[i]);
        }
    }

    public void Deserialize()
    {
        score.score = PlayerPrefs.GetInt(keys[0], 0);
        score.points = PlayerPrefs.GetInt(keys[1], 10);
        score.pointsOnClick = PlayerPrefs.GetInt(keys[2], 1);
        score.timeCount = PlayerPrefs.GetFloat(keys[3], 10);

        DeSerializeList();
        _extrapoints = PlayerPrefs.GetInt(keys[5], 0);
        _cookieLevel = PlayerPrefs.GetInt(keys[6], 1);
        _extraOnClickPoints = PlayerPrefs.GetInt(keys[7], 0);

        for (int i = 0; i < pricesNums.Count; i++)
        {
            prices[i].text = "$ " + pricesNums[i].ToString();
        }

        this.transform.parent.parent.gameObject.SetActive(false);
    }

    private void DeSerializeList()
    {
        for (int i = 0; i < listKeys.Count; i++)
        {
            pricesNums[i] = PlayerPrefs.GetInt(listKeys[i].ToString(), listKeys[i]);
        }
    }

    public void SeerializeData()
    {
        PlayerPrefs.SetInt(keys[0], score.score);
        PlayerPrefs.SetInt(keys[1], score.points);
        PlayerPrefs.SetInt(keys[2], score.pointsOnClick);
        PlayerPrefs.SetFloat(keys[3], score.timeCount);

        SerializeList();
        PlayerPrefs.SetInt(keys[5], _extrapoints);
        PlayerPrefs.SetInt(keys[6], _cookieLevel);
        PlayerPrefs.SetInt(keys[7], _extraOnClickPoints);
        PlayerPrefs.Save();
    }
}