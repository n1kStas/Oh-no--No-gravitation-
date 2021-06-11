using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAPath : MonoBehaviour
{
    public enum DrawingDirection
    {
        NotDraw,
        DrawUp,
        DrawDown,
        ClearPath
    }

    public Sprite pointSprite;
    public Sprite pointFirstSprite;

    /*[HideInInspector]*/
    public List<Vector2> positionPointsPath = new List<Vector2>();
    /*[HideInInspector]*/
    public List<GameObject> pointsPath = new List<GameObject>();

    private TouchScreen _touchScreen;
    private Camera _camera;
    private Transform _playerTransform;
    public bool movementInAllDirections;
    public int numberOfMoves;

    public DrawingDirection drawingDirection;


    
    private Vector2 _delta;

    //создаваемы обьекты на сцене
    private GameObject _path;

    private void Start()
    {
        _camera = Camera.main;
        _touchScreen = _camera.GetComponent<TouchScreen>();
    }

    private void Update()
    {
        if (positionPointsPath.Count == 0)
        {
            CreateFirstPosition();
        }
        if (IsTouching())
        {

            _delta = _camera.ScreenToWorldPoint(_touchScreen.GetTouchPosition());
            Vector2 oldPoint = positionPointsPath[positionPointsPath.Count - 1];
            switch (drawingDirection)
            {
                case DrawingDirection.DrawUp:

                    if(!movementInAllDirections && _delta.x >= oldPoint.x && _delta.y >= oldPoint.y)
                    {
                        int addCountPoint = (int)(Vector2.Distance(_delta, oldPoint) / 0.3f);
                        float x = (_delta.x + oldPoint.x) / addCountPoint;
                        float y = (_delta.y + oldPoint.y) / addCountPoint;
                        for (int i = 1; i < addCountPoint; i++)
                        {
                            Vector2 positionPoint = new Vector2(x * i, y * i);
                            if (Vector2.Distance(positionPointsPath[positionPointsPath.Count - 1], positionPoint) < 1f)
                            {
                                positionPointsPath.Add(positionPoint);
                                GameObject point = new GameObject("Point");
                                pointsPath.Add(point);
                                point.transform.position = positionPoint;
                                point.transform.parent = _path.transform;
                                point.AddComponent<SpriteRenderer>().sprite = pointFirstSprite;
                                if (pointsPath.Count > 1)
                                {
                                    pointsPath[pointsPath.Count - 2].GetComponent<SpriteRenderer>().sprite = pointSprite;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (movementInAllDirections && _delta.y >= oldPoint.y)
                    {
                        int addCountPoint = (int)(Vector2.Distance(_delta, oldPoint) / 0.3f);
                        float x = (_delta.x + oldPoint.x) / addCountPoint;
                        float y = (_delta.y + oldPoint.y) / addCountPoint;
                        for (int i = 1; i < addCountPoint; i++)
                        {
                            Vector2 positionPoint = new Vector2(x * i, y * i);
                            if (Vector2.Distance(positionPointsPath[positionPointsPath.Count - 1], positionPoint) < 1f)
                            {
                                positionPointsPath.Add(positionPoint);
                                GameObject point = new GameObject("Point");
                                pointsPath.Add(point);
                                point.transform.position = positionPoint;
                                point.transform.parent = _path.transform;
                                point.AddComponent<SpriteRenderer>().sprite = pointFirstSprite;
                                if (pointsPath.Count > 1)
                                {
                                    pointsPath[pointsPath.Count - 2].GetComponent<SpriteRenderer>().sprite = pointSprite;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;

                case DrawingDirection.DrawDown:
                    if (!movementInAllDirections && _delta.x >= oldPoint.x && _delta.y <= oldPoint.y)
                    {
                        int addCountPoint = (int)(Vector2.Distance(_delta, oldPoint) / 0.3f);
                        float x = (_delta.x + oldPoint.x) / addCountPoint;
                        float y = (_delta.y + oldPoint.y) / addCountPoint;
                        for (int i = 1; i < addCountPoint; i++)
                        {
                            Vector2 positionPoint = new Vector2(x * i, y * i);
                            if (Vector2.Distance(positionPointsPath[positionPointsPath.Count - 1], positionPoint) < 1f)
                            {
                                positionPointsPath.Add(positionPoint);
                                GameObject point = new GameObject("Point");
                                pointsPath.Add(point);
                                point.transform.position = positionPoint;
                                point.transform.parent = _path.transform;
                                point.AddComponent<SpriteRenderer>().sprite = pointFirstSprite;
                                if (pointsPath.Count > 1)
                                {
                                    pointsPath[pointsPath.Count - 2].GetComponent<SpriteRenderer>().sprite = pointSprite;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (movementInAllDirections && _delta.y <= oldPoint.y)
                    {
                        int addCountPoint = (int)(Vector2.Distance(_delta, oldPoint) / 0.3f);
                        float x = (_delta.x + oldPoint.x) / addCountPoint;
                        float y = (_delta.y + oldPoint.y) / addCountPoint;
                        for (int i = 1; i < addCountPoint; i++)
                        {
                            Vector2 positionPoint = new Vector2(x * i, y * i);
                            if (Vector2.Distance(positionPointsPath[positionPointsPath.Count - 1], positionPoint) < 1f)
                            {
                                positionPointsPath.Add(positionPoint);
                                GameObject point = new GameObject("Point");
                                pointsPath.Add(point);
                                point.transform.position = positionPoint;
                                point.transform.parent = _path.transform;
                                point.AddComponent<SpriteRenderer>().sprite = pointFirstSprite;
                                if (pointsPath.Count > 1)
                                {
                                    pointsPath[pointsPath.Count - 2].GetComponent<SpriteRenderer>().sprite = pointSprite;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;

                case DrawingDirection.ClearPath:                                        
                    int countPointPath = positionPointsPath.Count;
                    int clearPoint = 0;
                    while (clearPoint < countPointPath)
                    {
                        if (Vector2.Distance(positionPointsPath[clearPoint], _delta) < 0.1f)
                        {
                            while (true)
                            {
                                positionPointsPath.RemoveAt(clearPoint);
                                Destroy(pointsPath[clearPoint]);
                                pointsPath.RemoveAt(clearPoint);
                                if (clearPoint == positionPointsPath.Count)
                                {
                                    pointsPath[pointsPath.Count - 1].GetComponent<SpriteRenderer>().sprite = pointFirstSprite;
                                    break;
                                }
                            }
                            break;
                        }
                        else
                        {
                            clearPoint++;
                        }
                    }
                    break;
            }
        }
    }

    public void DrawTheWayUp()
    {
        numberOfMoves++;
        drawingDirection = DrawingDirection.DrawUp;
    }

    public void DrawTheWayDown()
    {
        drawingDirection = DrawingDirection.DrawDown;
    }

    public void ClearPath()
    {
        drawingDirection = DrawingDirection.ClearPath;
    }

    public void DoNotDraw()
    {
        drawingDirection = DrawingDirection.NotDraw;
    }

    private bool IsTouching()
    {
        return _touchScreen.GetTouchPhase();
    }

    public void ClearDrawPath()
    {
        positionPointsPath.Clear();
        foreach (GameObject point in pointsPath)
        {
            Destroy(point);
        }
        pointsPath.Clear();
        DoNotDraw();
    }

    private void CreateFirstPosition()
    {
        _path = new GameObject("Path");
        positionPointsPath.Add(_playerTransform.position);
        GameObject point = new GameObject("Point");
        pointsPath.Add(point);
        point.transform.position = _playerTransform.position;
        point.transform.parent = _path.transform;
        point.AddComponent<SpriteRenderer>().sprite = pointFirstSprite;
    }

    public void SetTranformPlayer(Transform playerTranform)
    {
        _playerTransform = playerTranform;
    }

    public void MakeThePathTransparent()
    {
        foreach(var point in pointsPath)
        {
            point.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,90);
        }
    }

    public void ReturnToStandardImageThePath()
    {
        foreach (var point in pointsPath)
        {
            point.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}
