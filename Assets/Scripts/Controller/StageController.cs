using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//스테이지를 관리하는 컨트롤러
//스테이지 시작과 종료 시점에 스테이지의 시작과 마감을 처리하는 기능
//스테이지 내에서 획득하는 포인트를 관리하는 시스템
public class StageController : MonoBehaviour
{
    //스테이지에서 쌓은 포인트를 저장할 변수
    public int StagePoint = 0;
    //포인트 표시용 텍스트
    public Text PointText;
    //스테이지 컨트롤러의 인스턴스를 저장하는 static 변수입니다.
    public static StageController instance;
    //다른 코드 내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용할 수 있게 됩니다.
    //따로 연결해서 쓸 필요가 없어서 편리합니다.

    //2024 -3-15 Awake -> Start 
    private void Start()
    {
        instance = this;
        //안내창 값 설정
        var alert = new DialogDataAlert("게임 시작", "소환되는 슬라임들을 무자비하게 도륙하세요.", delegate () { Debug.Log("OK를 눌렀습니다!"); });

        //매니저에 등록
        DialogManager.Instance.Push(alert);
    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); 구 버전 코드(현재는 쓰지 않습니다.)
        SceneManager.LoadScene("Game");
    
    }
}
