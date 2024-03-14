using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillTarget : MonoBehaviour
{
    public List<Collider> targetList;

    // Use this for initialization
    void Start()
    {
        targetList = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
       targetList.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
 
        targetList.Remove(other);

    }
}
