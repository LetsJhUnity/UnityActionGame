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
    void Start()
    {
        // Instance ������ ���� Ŭ������ �ν��Ͻ��� �����մϴ�.
        instance = this;
        // ���̾�α� �����͸� �ϳ� �����մϴ�. �����ϰ� ����, �׸��� �ݹ��Լ��� �Ű������� �����մϴ�. 
        DialogDataAlert alert = new DialogDataAlert("START", "Game Start!", delegate () {
            Debug.Log("OK Pressed");
        });
        // ������ Alert ���̾�α� �����͸� DialogManager�� �߰��մϴ�.
        DialogManager.Instance.Push(alert);

    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }
        

	public void FinishGame()
    {
        // DialogDataConfirm Ŭ������ �ν��Ͻ��� �����մϴ�.
        // �̶� ����(Title), ����(Message), �ݹ��Լ�(delegate(bool yn))�� �Ű������� �����մϴ�.
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
        // ������ ���̾�α� �����͸� ���̾�α� �Ŵ������� �����մϴ�.
        DialogManager.Instance.Push(confirm);
    }
}
