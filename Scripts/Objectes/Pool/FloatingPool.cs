using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingPool: MonoBehaviour
{
    private GameObject floatingText;

    private Stack<TextMeshPro> floatPool = new Stack<TextMeshPro>();

    void Awake()
    {
        floatingText = Database.Instance.floatingBasis;
    }

    public TextMeshPro GetFromPool()
    {
        if(floatPool.Count > 0)
        {
            return floatPool.Pop();
        }

        GameObject temp = Instantiate(floatingText);
        temp.SetActive(false);

        TextMeshPro tmp = temp.GetComponent<TextMeshPro>();

        floatPool.Push(tmp);

        return tmp;
    }

    public void ReturnPool(TextMeshPro tmp)
    {
        floatPool.Push(tmp);
    }
}
