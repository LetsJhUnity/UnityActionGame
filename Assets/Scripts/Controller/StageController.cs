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
    void Start()
    {
        // Instance 변수에 현재 클래스의 인스턴스를 설정합니다.
        instance = this;
        // 다이얼로그 데이터를 하나 생성합니다. 제목하고 내용, 그리고 콜백함수를 매개변수로 전달합니다. 
        DialogDataAlert alert = new DialogDataAlert("START", "Game Start!", delegate () {
            Debug.Log("OK Pressed");
        });
        // 생성한 Alert 다이얼로그 데이터를 DialogManager에 추가합니다.
        DialogManager.Instance.Push(alert);

    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }
        

	public void FinishGame()
    {
        // DialogDataConfirm 클래스의 인스턴스를 생성합니다.
        // 이때 제목(Title), 내용(Message), 콜백함수(delegate(bool yn))을 매개변수로 전달합니다.
        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if you want to restart the game.",
            delegate (bool yn) {
                if (yn)
                {
                    Debug.Log("OK Pressed");
                    SceneManager.LoadScene("Game");
                }
                else
                {
                    Debug.Log("Cancel Pressed");
                    Application.Quit();
                }
            });
        // 생성한 다이얼로그 데이터를 다이얼로그 매니저에게 전달합니다.
        DialogManager.Instance.Push(confirm);
    }
}
