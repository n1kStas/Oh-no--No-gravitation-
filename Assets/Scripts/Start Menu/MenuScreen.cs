using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    public Transform heroTransform;
    private Vector2 _targetPosition;
    private Vector2 _sizeScreen;
    private float _rotationZ;
    void Start()
    {
        _sizeScreen = new Vector2(Screen.height, Screen.width);
        heroTransform.position = new Vector2(Random.Range(0, 1024), Random.Range(0, 768));
        _targetPosition = new Vector2(Random.Range(0, 1024), Random.Range(0, 768));
    }

    private void Update()
    {
        HeroFly();
        _rotationZ += 0.5f;
        heroTransform.rotation = Quaternion.Euler(0, 0, _rotationZ);
    }

    private void HeroFly()
    {
        heroTransform.position = Vector2.MoveTowards(heroTransform.position, _targetPosition, 0.6f);
        if (Vector2.Distance(heroTransform.position, _targetPosition) <= 0.3f)
        {
            _targetPosition = new Vector2(Random.Range(0, 1024), Random.Range(0, 768));
        }
    }
}
