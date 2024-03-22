using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillTarget : MonoBehaviour
{
    public List<Collider> targetList;

    // Use this for initialization
    void Awake()
    {
        targetList = new List<Collider>();
    }

    private void Update()
    {
        StartCoroutine(MissingCheck());

    }

    IEnumerator MissingCheck()
    {
        while (true)
        {
            for (int i = 0; i < targetList.Count; i++)
            {
                if (targetList[i] == null)
                {
                    targetList.Remove(targetList[i]);
                }
            }
            yield return new WaitForSeconds(1.0f);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
       targetList.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);
        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] == null)
            {
                targetList.Remove(targetList[i]);
            }
        }
        targetList.Remove(other);


    }
}
