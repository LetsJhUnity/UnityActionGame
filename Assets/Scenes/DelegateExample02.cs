using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample02 : MonoBehaviour
{
    static int coin = 0;
    static int point = 0;
    static int exp = 0;

    public delegate void PlusDelegate(int _coin, int _point, int _exp);

    static void PlusCoin(int _coin, int _point, int _exp)
    {
        coin += _coin;
        Debug.Log($"{_coin}을 획득했습니다!");
    }

    static void PlusPoint(int _coin, int _point, int _exp)
    {
        point += _point;
        Debug.Log($"{_point}을 획득했습니다!");
    }

    static void PlusExp(int _coin, int _point, int _exp)
    {
        exp += _exp;
        Debug.Log($"{_exp}을 획득했습니다!");
    }

    private void Start()
    {
        //코인 100 , 포인트 50, 경험치 500을 획득하겠습니다.
        /*        PlusCoin(100);
                PlusPoint(50);
                PlusExp(500);*/

        //델리게이트 체인
        //델리게이트에서 함수를 + 또는 -를 통해 추가 , 제거할 수 있습니다.
        //추가할 경우 추가 순서대로 함수 호출 시 실행됩니다.(함수 동시 실행)

        PlusDelegate kill_Unit = PlusCoin;
        kill_Unit += PlusPoint;
        kill_Unit += PlusExp;

        kill_Unit(100,50,500);


    }


}
