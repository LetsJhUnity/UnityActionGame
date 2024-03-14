using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animator�� ���� �䱸(�ݵ�� �ʿ��ϴ�.)
//���� ��� �ڵ� �߰��ȴ�.
//Animator�� �����Ϳ��� ������Ʈ ������ �� ����.
//���࿡ Animator ������Ʈ�� ���ٸ� ���� �������� ���� �ʴ´�.
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    //���� ������Ʈ ���� ����Ǿ��ִ� Animator ������Ʈ�� �����ͼ� ����մϴ�.
    protected Animator avatar;
    protected PlayerAttack playerAttack; //2024-03-14 �÷��̾� ���� ��� �߰�
    float h, v;

    //�ִϸ��̼� ����� �ð� üũ�� ����
    float lastAttackTime, lastSkillTime, lastDashTime;

    [Header("Animation Condition")]
    public bool attacking = false;
    public bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    /// <summary>
    /// ���� ��Ʈ�ѷ����� ��Ʈ�ѷ��� ������ �Ͼ ��� ȣ���� �Լ�
    /// </summary>
    /// <param name="stickPos">��ƽ�� ��ǥ</param>
    public void OnStickChanaged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(avatar)
        {
            float back = 1.0f;
            if (v < 0.0f)
                back = -1.0f;

            avatar.SetFloat("Speed", (h * h + v * v));
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            if(rigidbody)
            {
                if (h != 0.0f && v != 0.0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0f, v));
                    //�ش� ���� ������ �ٶ󺸴� ȸ�� ���¸� ��ȯ�ϴ� �ڵ�
                }
            }
        }
    }

    #region EventTrigger
    public void OnAttackDown()
    {
        attacking = true;
        avatar.SetBool("Combo", true);
        StartCoroutine(StartAttack());
        //�ڷ�ƾ�� �۵���Ű�� �ڵ�
        //�ڷ�ƾ�� Update�� �ƴ� �������� �ݺ������� �ڵ尡 ����Ǿ�� �� �� ����ϸ� �ſ� ȿ�����Դϴ�.
        //Update���� ���к��ϰ� ������ �ڵ带 �ڷ�ƾ���� ��ȯ�ϸ�, �ڿ� ������ ȿ�����Դϴ�.
        //�ڷ�ƾ�� ���� �ð� ���߰� �ڿ� �����̴� �۾�, Ư�� ������ �ο��� �ڵ带 �����ϴ� �۾��� �����մϴ�.
        //�ڷ�ƾ�� IEnumerator ������ �Լ��� �����մϴ�.
        //�ش� �Լ� ���ο��� �ݵ�� yield return���� �����ؾ� �մϴ�.

        //���� �Լ��δ� Invoke�� ������, �̰� ���״�� �� �ð���ŭ ���� �� �Լ� �����̶� �ڷ�ƾ���� �ణ �ٸ�.
        //�ڷ�ƾ�� �ݺ� ��ƾ���� Ż���ϰ� �ٽ� �� �������� ���ƿ��� ���� �����մϴ�.

        //StartCoroutine("StartAttack");
    }
    public void OnAttackUp()
    {
        avatar.SetBool("Combo", false);
        attacking = false;
    }

    //yield���� ���� ��Ҹ� �����ϴ� Ű�����Դϴ�.

    IEnumerator StartAttack()
    {
        if(Time.time - lastAttackTime > 1.0f)
        {
            lastAttackTime = Time.time;
            while(attacking)
            {
                avatar.SetTrigger("AttackStart");
                playerAttack.NormalAttack(); // 2024-03-14 �÷��̾� �������κ��� �Ϲ� ���� ȣ��
                yield return new WaitForSeconds(1.0f);
            }
        }   
    }

    /// <summary>
    /// ��ư 2�� ������ ���� ��ų
    /// </summary>
    public void OnSkillDown()
    {
        if(Time.time - lastSkillTime > 1.0f)
        {
            avatar.SetBool("Skill", true);
            lastSkillTime = Time.time;
            playerAttack.SkillAttack(); // 2024-03-14 �÷��̾� �������κ��� ��ų ���� ȣ��
        }
    }

    public void OnSkillUp()
    {
        avatar.SetBool("Skill", false);
    }

    /// <summary>
    /// ��ư 1�� ������ ���� ��ų
    /// </summary>
    public void OnDashDown()
    {
        if (Time.time - lastDashTime > 1.0f)
        {
            lastDashTime = Time.time;
            dashing = true;
            avatar.SetTrigger("Dash"); // 2024-03-14 �÷��̾� �������κ��� ��� ���� ȣ��
            playerAttack.DashAttack();
        }

    }
    public void OnDashUp()
    {
        dashing = false;
    }


    #endregion





}
