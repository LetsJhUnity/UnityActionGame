using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//�̺�Ʈ Ʈ���Ÿ� ���� ����
public class DSController : MonoBehaviour
{
    //����� ����� ����� �ؽ�Ʈ
    //TMP ����� ��쿡�� TMP�� ���·� �۾��մϴ�.
    public Text ResultText;
    //�迭 ���
    public void DSArray()
    {
        //�迭 ����
        //�ڷ���[] �迭�� = new �ڷ���[�迭�� ����];
        int[] exp = new int[10];

        for(int i = 0; i < exp.Length; i++)
        {
            exp[i] = i * 100 + (i*50);
            ResultText.text += $"[DSArray] ���� ����{i}���� �䱸 ����ġ = {exp[i]} �Դϴ�.\n";
        }
    }

    public void DSList()
    {
        //����Ʈ<T> ����Ʈ�� = new List<T>();
        List<int> exp = new List<int>();

        for(int i = 0; i < 10; i++)
        {
            exp.Add(i * 100 + (i * 50));
        }

        //������ �ִ� ������ �� �� 4�� ����� ���� �����մϴ�.
        //exp.RemoveAll(x => (x % 4) == 0);

        exp.Sort((a,b) => b.CompareTo(a));

        for (int i = 0; i < exp.Count; i++)
        {
            ResultText.text += $"[DSList] ���� ����{i}���� �䱸 ����ġ = {exp[i]} �Դϴ�.\n";
        }
            
        //C#���� ���Ǵ� ����Ʈ ����
        //1. Add(��) : �ش� ���� ����Ʈ�� �߰��մϴ�.
        //2. Remove(��) : �ش� ���� ����Ʈ���� �����մϴ�.
        //3. Insert(��ġ, ��)  : ����Ʈ�� �ش� ��ġ�� ���� �߰��մϴ�.
        //4. Contains(��) : ����Ʈ�� �ش� ���� ������ �ִ����� �Ǵ��մϴ�. (bool)
        //5. Clear() : ����Ʈ�� ��� ��Ҹ� �����մϴ�.
        //6. Reverse() : ��Ҹ� �������� �����մϴ�.
        //7. RemoveAll(���� �ۼ�) : �ش� ������ �����ϴ� ��� ��Ҹ� �����մϴ�.
        //8. Sort() : ���� �������� �����մϴ�.
        //9. Sort((a,b) => b.CompareTo(a)); ���� ����        
    }


    public void DSDictionary()
    {
        //����
        //Dictionary<K,V> ��ųʸ��� = new Dictionary<K,V>();

        //���� �� �ʱ�ȭ
        Dictionary<string, int> items = new Dictionary<string, int>
        {
            {"red apple", 10}
            ,
            {"meat", 100}
        };

        //��� �߰�
        items.Add("cake",50);

        //Ű ����
        if(items.ContainsKey("cake"))
        {
            items.Remove("cake");
        }

        if(items.ContainsValue(100))
        {
            Debug.Log("�ش� ���� �����մϴ�.");
        }

        //��ųʸ��� �ٽ�
        //1. Ű�� �̿��� ���� ���� ����
        //2. �ش� Ű�� �����ϴ°��� ���� ����
        //3. Ű, ���� ���� ������ ������ �� �ִ°�?(����Ʈ ��ȯ)
        //4. ��ųʸ��� Ű�� ��쿡�� �ߺ��� ������� �ʰ�, ���� �ߺ��� ����մϴ�.
        //���� Add ������ ��, ������ �ִ� Ű�� �ٽ� Add�ϴ� ��� �� Ű�� ���� ���� ����


        //��ųʸ��� Ű -> ����Ʈ�� �ٲٴ� ���
        var KList = new List<string>(items.Keys);

        //��ųʸ��� �� -> ����Ʈ�� �ٲٴ� ���
        var VList = new List<int>(items.Values);

        //����Ʈ -> ��ųʸ��� �ٲٴ� ��
        //1. Ű�� �� ����Ʈ�� ���� �� ����Ʈ�� �غ��մϴ�.
        var KtoD = new List<string>() {"a","b","c","d","e"};
        var VtoD = new List<int>() { 1, 2, 3, 4, 5 };

        //��ųʸ��� �����ϰ� Zip �Լ��� ���� �۾��� �����մϴ�.
        //Ű.Zip(��, (k,v) => new {k,v}) Ű�� �� �ϳ��ϳ��� {Ű,��}�� ���·� ���̰� �˴ϴ�.
        //ToDictionary�� ���� Ű�� ���� �����մϴ�. �׸��� ��ųʸ��� ���·� ��ȯ�մϴ�.
        var NewDictionary = KtoD.Zip(VtoD, (k,v) => new { k,v }).ToDictionary(a => a.k, a => a.v);

    }

    //�ش� �Լ� ȣ�� �� ȭ�鿡 �����ִ� �ؽ�Ʈ�� ���� ���
    public void DSResultReset()
    {
        ResultText.text = "";
    }


}
