using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
  [SerializeField] private float time;

  [SerializeField] private Text timerText;

    public GameObject Player;

    private float _timeLeft = 100f;

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
            Destroy(Player);
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
