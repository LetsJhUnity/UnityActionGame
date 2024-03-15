using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//이벤트 트리거를 통해 전달
public class DSController : MonoBehaviour
{
    //사용한 결과를 출력할 텍스트
    //TMP 사용할 경우에는 TMP의 형태로 작업합니다.
    public Text ResultText;
    //배열 사용
    public void DSArray()
    {
        //배열 생성
        //자료형[] 배열명 = new 자료형[배열의 길이];
        int[] exp = new int[10];

        for(int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i*50);
            ResultText.text += $"[DSArray] 다음 레벨{i}까지 요구 경험치 = {exp[i]} 입니다.\n";
        }
    }

    public void DSList()
    {
        //리스트<T> 리스트명 = new List<T>();
        List<int> exp = new List<int>();

        for(int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        //가지고 있는 데이터 값 중 4의 배수를 전부 삭제합니다.
        //exp.RemoveAll(x => (x % 4) == 0);

        exp.Sort((a,b) => b.CompareTo(a));

        for (int i = 0; i < exp.Count; i++)
        {
            ResultText.text += $"[DSList] 다음 레벨{i}까지 요구 경험치 = {exp[i]} 입니다.\n";
        }
            
        //C#에서 사용되는 리스트 문법
        //1. Add(값) : 해당 값을 리스트에 추가합니다.
        //2. Remove(값) : 해당 값을 리스트에서 제거합니다.
        //3. Insert(위치, 값)  : 리스트의 해당 위치에 값을 추가합니다.
        //4. Contains(값) : 리스트가 해당 값을 가지고 있는지를 판단합니다. (bool)
        //5. Clear() : 리스트의 모든 요소를 제거합니다.
        //6. Reverse() : 요소를 역순으로 정렬합니다.
        //7. RemoveAll(조건 작성) : 해당 조건을 만족하는 모든 요소를 삭제합니다.
        //8. Sort() : 오름 차순으로 정렬합니다.
        //9. Sort((a,b) => b.CompareTo(a)); 내림 차순        
    }


    public void DSDictionary()
    {
        //생성
        //Dictionary<K,V> 딕셔너리명 = new Dictionary<K,V>();

        //생성 및 초기화
        Dictionary<string, int> items = new Dictionary<string, int>
        {
            {"red apple", 10}
            ,
            {"meat", 100}
        };

        //기능 추가
        items.Add("cake",50);

        //키 조사
        if(items.ContainsKey("cake"))
        {
            items.Remove("cake");
        }

        if(items.ContainsValue(100))
        {
            Debug.Log("해당 값은 존재합니다.");
        }

        //딕셔너리의 핵심
        //1. 키를 이용한 값에 대한 접근
        //2. 해당 키가 존재하는가에 대한 여부
        //3. 키, 값을 각각 분할해 보관할 수 있는가?(리스트 변환)
        //4. 딕셔너리는 키의 경우에는 중복을 허용하지 않고, 값은 중복을 허용합니다.
        //따라서 Add 진행할 때, 기존에 있는 키를 다시 Add하는 경우 그 키가 가진 값만 변경


        //딕셔너리의 키 -> 리스트로 바꾸는 기능
        var KList = new List<string>(items.Keys);

        //딕셔너리의 값 -> 리스트로 바꾸는 기능
        var VList = new List<int>(items.Values);

        //리스트 -> 딕셔너리로 바꾸는 법
        //1. 키가 될 리스트와 값이 될 리스트를 준비합니다.
        var KtoD = new List<string>() {"a","b","c","d","e"};
        var VtoD = new List<int>() { 1, 2, 3, 4, 5 };

        //딕셔너리를 생성하고 Zip 함수를 통해 작업을 진행합니다.
        //키.Zip(값, (k,v) => new {k,v}) 키와 값 하나하나가 {키,값}의 형태로 묶이게 됩니다.
        //ToDictionary에 의해 키와 값을 설정합니다. 그리고 딕셔너리의 형태로 반환합니다.
        var NewDictionary = KtoD.Zip(VtoD, (k,v) => new { k,v }).ToDictionary(a => a.k, a => a.v);

    }

    //해당 함수 호출 시 화면에 나와있는 텍스트를 비우는 기능
    public void DSResultReset()
    {
        ResultText.text = "";
    }


}
