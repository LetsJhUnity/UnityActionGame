using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion
{
    public int value;
    public int count;
}


public class PotionExample : MonoBehaviour
{

    public bool isUse;
    public float cooltime = 10.0f;
    public float cooltime_max = 10.0f;

    Potion potion;
    PlayerHealth playerHealth;

   public void OnPotionDown()
    {
        if (isUse == false)
        {
            Debug.Log("������ ����߽��ϴ�!");
            playerHealth.currentHealth += potion.value;
            potion.count--;
            StartCoroutine(CoolTimeCheck());

        }
   }

    IEnumerator CoolTimeCheck()
    {
        while(cooltime > 0.0f)
        {
            GetComponent<Image>().color = Color.black;
            isUse = true;

            cooltime -= Time.deltaTime;
            GetComponent<Image>().fillAmount = cooltime / cooltime_max;

            yield return null;
        }

        Debug.Log("��Ÿ�� üũ �Ϸ�");
        GetComponent<Image>().color = Color.white;
        GetComponent<Image>().fillAmount = 1.0f;
        cooltime = cooltime_max;
        isUse = false;
    }
}
