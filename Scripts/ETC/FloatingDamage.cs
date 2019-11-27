using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamage : MonoBehaviour
{
    public Animator animator;
    TextMeshPro tmp;

    public float destroyTime = 1f;
    private float upSpeed = 10f;

   // WaitForSeconds waitTime = new WaitForSeconds(1f);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        tmp = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        //
        //Destroy(gameObject, destroyTime);
        StopAllCoroutines();
        StartCoroutine(Disabled());
    }

    IEnumerator Disabled()
    {
        //yield return waitTime;
        ////yield return new WaitForSeconds(waitTime);
        for (float timer = 1f; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
        {
            yield return null;
        }
        MasterFloatingTextPool.Instance.ReturnToPool(tmp);
        //gameObject.SetActive(false);
    }

    void Update()
    {
        animator.speed = GameManager.Instance.GameSpeed;
        //transform.Translate(Vector3.up * (Time.deltaTime * GameManager.Instance.GameSpeed) * upSpeed + Vector3.forward * 0.001f);
        transform.Translate(Vector3.up * (Time.deltaTime * GameManager.Instance.GameSpeed) * upSpeed + Vector3.forward * 0.001f);
    }
}
