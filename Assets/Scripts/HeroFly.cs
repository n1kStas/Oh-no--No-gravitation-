using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFly : MonoBehaviour
{
    public float speedFly;
    public Vector2 targetPosition;
    private IEnumerator activeIEnumerator;
    private Animator _animator;
    private int _countAnimation;
    public GameController gameController;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Fly(DrawAPath drawAPath)
    {
        _countAnimation = Random.Range(1, 4);
        _animator.SetBool("Move_" + _countAnimation, true);
        activeIEnumerator = FlyIEnumerator(drawAPath);
        StartCoroutine(activeIEnumerator);
    }

    private IEnumerator FlyIEnumerator(DrawAPath drawAPath)
    {
        yield return new WaitForFixedUpdate();
        while (drawAPath.positionPointsPath.Count > 1)
        {            
            targetPosition = drawAPath.positionPointsPath[0];
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speedFly * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) <= 0.2f)
            {
                GameObject point = drawAPath.pointsPath[0];
                drawAPath.positionPointsPath.RemoveAt(0);
                drawAPath.pointsPath.RemoveAt(0);
                Destroy(point);
            }
            yield return new WaitForFixedUpdate();
        }
        gameController.PlayerStopped();
    }

    public void StopFly()
    {
        if (activeIEnumerator != null)
        {
            _animator.SetBool("Move_" + _countAnimation, false);
            StopCoroutine(activeIEnumerator);
        }
    }

    private void HurtPlayer(GameObject pushObject)
    {
        activeIEnumerator = HurtPlayerIEnumerator(pushObject);
        StartCoroutine(activeIEnumerator);
    }

    private IEnumerator HurtPlayerIEnumerator(GameObject pushObject)
    {
        int cntAnim = _countAnimation;        
        _countAnimation = Random.Range(1, 3);
        _animator.SetBool("Hurt_" + _countAnimation, true);
        _animator.SetBool("Move_" + cntAnim, false);
        while (true)
        {
            if (Vector2.Distance(transform.position, pushObject.transform.position) >= pushObject.GetComponent<Space>().distancePush)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        _animator.SetBool("Hurt_" + _countAnimation, false);
        gameController.drawAPath.ClearDrawPath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Space"))
        {
            if (GetComponent<Player>().Hit()) //если игрок стукнулся и у него осталось здоровье
            {                
                GameObject pushObject = collision.gameObject;
                Vector2 inDirection = collision.collider.bounds.center;
                Vector2 inNormal = collision.contacts[0].normal;
                GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(inDirection, inNormal).normalized * 1.5f;
                gameController.PlayerStopped();
                
                HurtPlayer(pushObject);
            }
            else
            {
                StopCoroutine(activeIEnumerator);
                _animator.SetTrigger("Death_" + Random.Range(1, 4));
                gameController.PlayerStopped();
                gameController.drawAPath.ClearDrawPath();
                StartCoroutine(GameOverIEnumerator());
            }
        }
        else if (collision.gameObject.CompareTag("Turret"))
        {

        }
        else if (collision.gameObject.CompareTag("Edge"))
        {

        }
    }
    private IEnumerator GameOverIEnumerator()
    {
        yield return new WaitForSeconds(0.3f);
    }
}
