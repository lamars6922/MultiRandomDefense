using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingGold : MonoBehaviour
{
    public Animator animator;
    public float destroyTime = 1f;
    public float upSpeed = 3f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(Disabled(destroyTime));
    }

    void Update()
    {
        animator.speed = GameManager.Instance.GameSpeed;
        transform.Translate(Vector3.up * (Time.deltaTime * GameManager.Instance.GameSpeed) * upSpeed + Vector3.forward * 0.001f);
    }

    IEnumerator Disabled(float waitTime)
    {
        //yield return new WaitForSeconds(waitTime);
        for (float timer = waitTime; timer >= 0; timer -= (Time.deltaTime * GameManager.Instance.GameSpeed))
        {
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
