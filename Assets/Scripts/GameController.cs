using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] public float time;

  [SerializeField] private Text timerText; // ����� �� ����� ������ ������

    [SerializeField] private Text fireWoodText; // ����� �� ����� ���-�� ������

    [SerializeField] private Player woodCoins; // ���-�� ������ � ������ ������

     public GameObject Fire;

    public float _timeLeft = 100f; // �� ��������!

     public float ckeckFireWoods = 0f; // ���������, �������� �� ����� ������ . �� ������!

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            Destroy(Fire);
        }
        

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        fireWoodText.text = Convert.ToString(woodCoins.fireWoodQuantity);
    }
}
