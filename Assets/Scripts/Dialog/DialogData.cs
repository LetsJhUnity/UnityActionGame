using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DialogData
{
    //다이얼로그 타입에 대한 프로퍼티
    public DialogType Type { get; set; }

    //다이얼로그 타입을 매개변수로 다이얼로그 데이터 생성(생성자)
    public DialogData(DialogType type)
    {
        Type = type;
    }
}

