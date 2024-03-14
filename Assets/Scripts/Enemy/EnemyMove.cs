using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;

    private void Awake()
    {
        //���忡�� Player �±׸� ���� ������Ʈ�� ������ �� ������Ʈ�� Ʈ������ ������ ����
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //�������� ������ �ִ� NavMeshAgent ���� ����
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.enabled)
        {
            nav.SetDestination(player.position);
        }
    }
    
    public void SpeedUp()
    {
        if(nav.enabled)
        {
            nav.speed++; //������Ʈ �ӵ�
            nav.angularSpeed++; //������Ʈ ȸ�� ��
        }
    }
}
