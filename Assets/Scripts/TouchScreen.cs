using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    public enum TouchPhase
    {
        Ended,
        Began,
        Moved,
        Stationary      
    }

    private Vector2 _touchPosition;
    private Vector2 _oldTouchPosition;

    private Vector2 _touchOnePosition;
    private Vector2 _touchTwoPosition;

    [SerializeField] TouchPhase _touchPhase;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchPhase = TouchPhase.Began;
            _touchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            _touchPosition = Input.mousePosition;
            if (_oldTouchPosition != _touchPosition)
            {
                _touchPhase = TouchPhase.Moved;
            }
            else
            {
                _touchPhase = TouchPhase.Stationary;
            }
            _oldTouchPosition = _touchPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _touchPosition = Input.mousePosition;
            _touchPhase = TouchPhase.Ended;
        }
    }

    public Vector2 GetTouchPosition()
    {
        return _touchPosition;
    }

    public bool GetTouchPhase()
    {
        return _touchPhase == TouchPhase.Began || _touchPhase == TouchPhase.Moved || _touchPhase == TouchPhase.Stationary;
    }
}
