using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public TouchScreen _touchScreen;

    private Vector2 _initialTouchPosition;
    private Vector2 _initialCameraPosition;
    private bool _drag;
    private Vector2 _delta;
    private Camera _camera;

    private Vector2 _maxPositionsCamera;
    private Vector2 _minPositionsCamera;

    private IEnumerator cameraToMovementPlayer;
    public bool enabledControl = true;

    private void Start()
    {
        _camera = Camera.main;
        _touchScreen = GetComponent<TouchScreen>();
    }

    private void Update()
    {
        if (IsTouching() && enabledControl)
        {
            CameraMovement();
        }
        else
        {
            _drag = false;
        }
    }

    private void CameraMovement()
    {
        if (!_drag)
        {
            _initialTouchPosition = _touchScreen.GetTouchPosition();
            _initialCameraPosition = _camera.transform.position;
            _drag = true;
        }
        else
        {
            _delta = _camera.ScreenToWorldPoint(_touchScreen.GetTouchPosition()) - _camera.ScreenToWorldPoint(_initialTouchPosition);

            Vector3 newPos = _initialCameraPosition;
            newPos.x -= _delta.x;
            newPos.y -= _delta.y;
            newPos.z = -10;
            if(newPos.x < _minPositionsCamera.x + _camera.orthographicSize - 5)
            {
                newPos.x = _minPositionsCamera.x + _camera.orthographicSize - 5;
            }
            else if(newPos.x > _maxPositionsCamera.x + _camera.orthographicSize - 5)
            {
                newPos.x = _maxPositionsCamera.x + _camera.orthographicSize - 5;
            }
            if(newPos.y < _minPositionsCamera.y + _camera.orthographicSize - 5)
            {
                newPos.y = _minPositionsCamera.y + _camera.orthographicSize - 5;
            }
            else if(newPos.y > _maxPositionsCamera.y - _camera.orthographicSize + 5)
            {
                newPos.y = _maxPositionsCamera.y - _camera.orthographicSize + 5;
            }

            _camera.transform.position = newPos;
        }
    }

    private bool IsTouching()
    {
        return _touchScreen.GetTouchPhase();
    }

    public void SetMinAndMaxCameraPosition(Vector2 minPosCam, Vector2 maxPosCam)
    {
        _minPositionsCamera = minPosCam;
        _maxPositionsCamera = maxPosCam;
    }

    public void StartCameraToMovementPlayer(Transform playerTransform)
    {
        cameraToMovementPlayer = CameraToMovementPlayerIEnumerator(playerTransform);
        StartCoroutine(cameraToMovementPlayer);
    }

    private IEnumerator CameraToMovementPlayerIEnumerator(Transform playerTransform)
    {
        while (true)
        {
            Vector3 newPos = playerTransform.position;
            newPos.z = -10;
            if (newPos.x < _minPositionsCamera.x + _camera.orthographicSize - 5)
            {
                newPos.x = _minPositionsCamera.x + _camera.orthographicSize - 5;
            }
            else if (newPos.x > _maxPositionsCamera.x + _camera.orthographicSize - 5)
            {
                newPos.x = _maxPositionsCamera.x + _camera.orthographicSize - 5;
            }
            if (newPos.y < _minPositionsCamera.y + _camera.orthographicSize - 5)
            {
                newPos.y = _minPositionsCamera.y + _camera.orthographicSize - 5;
            }
            else if (newPos.y > _maxPositionsCamera.y - _camera.orthographicSize + 5)
            {
                newPos.y = _maxPositionsCamera.y - _camera.orthographicSize + 5;
            }

            _camera.transform.position = newPos;
            yield return new WaitForFixedUpdate();
        }
    }

    public void StopCameraToMovementPlayer()
    {
        if (cameraToMovementPlayer != null)
        {
            StopCoroutine(cameraToMovementPlayer);
        }
    }

    public void DisabledContorolCamera()
    {
        enabledControl = false;
    }

}
