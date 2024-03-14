using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3.0f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        //InvokeRepeating("�Լ�", �����̽ð�,�ݺ��ð�);
        //�ش� �Լ��� ������ �ð� ���Ŀ� ȣ���ϰ�, �ݺ� �ð��� �ֱ�� �ش� �Լ��� �ݺ������� ȣ���մϴ�.
    }

    void Spawn()
    {
        //�÷��̾��� ü���� 0�̶��
        if (playerHealth.currentHealth <= 0.0f)
            return;

        int spawnPoolIndex = Random.Range(0, spawnPoints.Length);
        //���� ������ ������ŭ ������ ��ġ�� ���� �ε����� �����ڽ��ϴ�.
    
        Instantiate(enemy, spawnPoints[spawnPoolIndex].position, spawnPoints[spawnPoolIndex].rotation);


    }

  
}
