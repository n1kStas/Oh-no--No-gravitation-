using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public GameObject target;
    public GameObject buttonAttack;
    [SerializeField] bool used;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void DestroyTarget()
    {
        if (!used)
        {
            _animator.SetTrigger("Fire");
            used = true;
            Destroy(target);
            buttonAttack.GetComponent<Image>().color = Color.red;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buttonAttack.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonAttack.SetActive(false);
    }
}
