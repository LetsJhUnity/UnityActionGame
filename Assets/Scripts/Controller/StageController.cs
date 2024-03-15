using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//���������� �����ϴ� ��Ʈ�ѷ�
//�������� ���۰� ���� ������ ���������� ���۰� ������ ó���ϴ� ���
//�������� ������ ȹ���ϴ� ����Ʈ�� �����ϴ� �ý���
public class StageController : MonoBehaviour
{
    //������������ ���� ����Ʈ�� ������ ����
    public int StagePoint = 0;
    //����Ʈ ǥ�ÿ� �ؽ�Ʈ
    public Text PointText;
    //�������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� static �����Դϴ�.
    public static StageController instance;
    //�ٸ� �ڵ� ������ StageController.instance.AddPoint(10)�� ���� ���·� ����� �� �ְ� �˴ϴ�.
    //���� �����ؼ� �� �ʿ䰡 ��� ���մϴ�.

    //2024 -3-15 Awake -> Start 
    private void Start()
    {
        instance = this;
        //�ȳ�â �� ����
        var alert = new DialogDataAlert("���� ����", "��ȯ�Ǵ� �����ӵ��� ���ں��ϰ� �����ϼ���.", delegate () { Debug.Log("OK�� �������ϴ�!"); });

        //�Ŵ����� ���
        DialogManager.Instance.Push(alert);
    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        //Application.LoadLevel(Application.loadedLevel); �� ���� �ڵ�(����� ���� �ʽ��ϴ�.)
        SceneManager.LoadScene("Game");
    
    }
}
