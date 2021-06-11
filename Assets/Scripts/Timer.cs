using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    private float _millisecond;
    private float _second;
    private float _minute;
    [SerializeField] public Text timerText;
    private IEnumerator _timerEnabled;
    public int second;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }
    public void StartTimer()
    {
        _timerEnabled = TimerEnabled();
        StartCoroutine(_timerEnabled);
    }

    private IEnumerator TimerEnabled()
    {
        while (true)
        {            
            _millisecond += Time.deltaTime;
            if (_millisecond >= 1)
            {                
                _millisecond -= 1;
                _second++;
            }
            if (_second == 60)
            {
                _minute++;
                _second -= 60;
            }
            string sMillisecond = ((_millisecond - _millisecond % 0.01f) * 100).ToString();
            if (sMillisecond.Length > 2)
            {
                sMillisecond = sMillisecond[0].ToString() + sMillisecond[1].ToString();
            }
            string sSecond = _second.ToString();
            string sMinute = _minute.ToString();
            timerText.text = sMinute + ":" + sSecond + ":" + sMillisecond;
            yield return new WaitForFixedUpdate();
        }
    }

    public void StopTimer()
    {
        if (_timerEnabled != null)
        {
            StopCoroutine(_timerEnabled);
        }
    }

    public void ResetTimer()
    {
        _millisecond = 0;
        _second = 0;
        _minute = 0;
        timerText.text = "0:00:00";
        second = 0;
    }
}
