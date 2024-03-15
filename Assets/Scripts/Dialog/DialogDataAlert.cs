using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//알림창에서 사용할 데이터
public class DialogDataAlert : DialogData
{
    public string Title { get; private set; }
    public string Message { get; private set; }
    //유니티에서 사용할 수있는 delegate Action
    //유저가 확인 버튼 눌렀을 때 호출되는 콜백 함수를 저장하겠습니다.
    //콜백 함수
    public Action Callback { get; private set; }

    //Action callback = null
    //default 매개변수는 매개변수에 값을 초기화해두는 것으로,
    //함수 호출 시에 해당 값을 안넣고 호출하는 경우 설정해둔 초기 값으로 자동으로 처리하는 기능

    //base(DialogType.Alert)

    public DialogDataAlert(string title, string message, Action callback = null) : base(DialogType.Alert)
    {
        Title = title;
        Message = message;
        Callback = callback;
    }

}

