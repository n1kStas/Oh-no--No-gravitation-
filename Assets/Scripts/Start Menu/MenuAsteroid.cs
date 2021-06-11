using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAsteroid : MonoBehaviour
{
    private Vector3 _movePositon;
    public float speed;
    private Vector2 _sizeScreen;
    private void Start()
    {
        _sizeScreen = new Vector2(Screen.height, Screen.width);
        _movePositon = new Vector2(_sizeScreen.y + 200, GetComponent<RectTransform>().position.y);
    }

    void Update()
    {
        if(Vector2.Distance(GetComponent<RectTransform>().position, _movePositon) < 1f)
        {
            GetComponent<RectTransform>().position = new Vector2( -200, GetComponent<RectTransform>().position.y);
        }
        GetComponent<RectTransform>().position = Vector2.MoveTowards(GetComponent<RectTransform>().position, _movePositon, speed * Time.deltaTime);
    }
}
