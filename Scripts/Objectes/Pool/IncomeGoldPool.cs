using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class IncomeGoldPool : MonoBehaviour
{
    public GameObject incomeGold;
    private List<TextMeshPro> IncomePool = new List<TextMeshPro>();

    // Start is called before the first frame update
    void Awake()
    {
        incomeGold = Database.Instance.incomeGold;
    }

    public TextMeshPro GetFromPool()
    {
        for (int i = 0; i < IncomePool.Count; i++)
        {
            if (!IncomePool[i].gameObject.activeInHierarchy)
            {
                return IncomePool[i];
            }
        }

        GameObject temp = Instantiate(incomeGold);
        temp.SetActive(false);

        TextMeshPro tmp = temp.GetComponent<TextMeshPro>();
        IncomePool.Add(tmp);
        return tmp;
    }

}
