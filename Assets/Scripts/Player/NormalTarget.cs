using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NormalTarget : MonoBehaviour
{

    //타겟에 대한 리스트
    public List<Collider> targetList;

    // Use this for initialization
    void Awake()
    {
        targetList = new List<Collider>();
    }

    private void Start()
    {
   //     StartCoroutine(MissingCheck());
        
    }

   /* IEnumerator MissingCheck()
    {
        while(true)
        {
         
            yield return new WaitForSeconds(1.0f);
        }

    }
*/

    //트리거 충돌 시 리스트 명단에 타겟을 등록
    private void OnTriggerEnter(Collider other)
    {
        targetList.Add(other);
    }
    //트리거 충돌이 끝나면 리스트 명단에서 타겟을 제거
    private void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);

    }

}
