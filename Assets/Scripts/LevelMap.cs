using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour
{
   /* public float minX;
    public float maxX;
    public bool drag;
    public Vector2 initialTouchPosition;
    public Vector2 initialCameraPosition;
    public Camera mainCamera;
    public GameManager gameManager;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1) //прокрутка уровня
        {
            Touch touch0 = Input.GetTouch(0);

            if (IsTouching(touch0))
            {
                if (!drag)
                {
                    initialTouchPosition = touch0.position;
                    initialCameraPosition = mainCamera.transform.position;

                    drag = true;
                }
                else
                {
                    Vector2 delta = mainCamera.ScreenToWorldPoint(touch0.position) -
                                    mainCamera.ScreenToWorldPoint(initialTouchPosition);

                    Vector3 newPos = initialCameraPosition;
                    newPos.x -= delta.x;
                    newPos.y = 0;
                    newPos.z = -10;
                    if (newPos.x < minX + mainCamera.GetComponent<Camera>().orthographicSize - 5)
                    {
                        newPos.x = minX + mainCamera.GetComponent<Camera>().orthographicSize - 5;
                    }
                    else if (newPos.x > maxX + (5 - mainCamera.GetComponent<Camera>().orthographicSize))
                    {
                        newPos.x = maxX + (5 - mainCamera.GetComponent<Camera>().orthographicSize);
                    }
                    mainCamera.transform.position = newPos;
                }
            }

            if (!IsTouching(touch0))
            {
                drag = false;
            }
        }
        else
        {
            drag = false;
        }
    }

    static bool IsTouching(Touch touch) //касается ли игрок экрана
    {
        return touch.phase == TouchPhase.Began ||
                touch.phase == TouchPhase.Moved ||
                touch.phase == TouchPhase.Stationary;
    }

    public void SelectLevel(int m_numberLevel)
    {
        mainCamera.transform.position = new Vector3(0, 0, -10);
        gameManager.StartLevel(m_numberLevel);
    }*/
}
