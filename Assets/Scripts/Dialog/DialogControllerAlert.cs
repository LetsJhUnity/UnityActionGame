using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

//알림창
public class DialogControllerAlert : DialogController
{
    //제목
    public Text LabelTitle;
    //내용
    public Text LabelMessage;

    //클래스에서 전달할 알림창의 데이터 객체 선언
    DialogDataAlert Data { get; set; }

    //버튼 클릭시 처리할 함수
    public void OnClickOK()
    {
        if(Data != null && Data.Callback != null)
        {
            Data.Callback();
        }

        //작업 끝난 후 현재의 팝업 창을 관리자에서 제거합니다.
        DialogManager.Instance.Pop();
    }


    public override void Awake()
    {
        base.Awake();
    }

    public override void Build(DialogData data)
    {
        base.Build(data);

        //데이터가 알림이 아닐 경우
        if(!(data is DialogDataAlert))
        {
            //에러 메세지 출력 
            Debug.LogError("Invaild dialog data!");
            return;//작업 종료
        }
        //데이터를 안내 데이터로써 받아오겠습니다.
        Data = data as DialogDataAlert;
        //텍스트 값에 데이터의 속성을 적용합니다.
        LabelTitle.text= Data.Title;
        LabelMessage.text= Data.Message;
    }

    public override void Start()
    {
        base.Start();
        //인스턴스를 통해 Alert 타입의 컨트롤러를 다루고 있음을 등록합니다.
        DialogManager.Instance.Regist(DialogType.Alert, this);
    }
}

