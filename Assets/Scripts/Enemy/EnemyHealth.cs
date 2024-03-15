using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    #region Fields
    [Header("슬라임의 체력 정보")]
    public int startingHealth = 100;
    public int currentHealth;

    [Header("공격 받을 시 색 변경")]
    public float flashSpeed = 5.0f;
    public Color flashColor = new Color(1, 0, 0, 0.1f);

    [Header("죽은 이후 처리")]
    public float sinkSpeed = 1.0f;

    //오디오 소스
    AudioSource audioSource;

    //슬라임의 상태를 구분해 상황에 맞는 효과를 슬라임에게 전달하는 역할
    bool isDead;
    bool isSinking;
    bool damaged;
    #endregion
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //데미지를 받았을 경우 색을 설정한 색으로 변경합니다.
        if(damaged)
        {
            //Slime->Model에 접근
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", flashColor);
        }
        //그게 아닐 경우는 다시 자연스럽게 색이 변환될 수 있도록 처리합니다.
        //Color.Lerp(A,B); //A 컬러를 B 컬러로 천천히 바꾸는 코드
        else
        {
            transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(transform.GetChild(0).
                GetComponent<Renderer>().material.GetColor("_Color"), Color.white, flashSpeed * Time.deltaTime));
        }

        //데미지 처리를 비활성화
        damaged = false;

        //싱크 처리(사후 처리) 시 슬라임을 아래로 서서히 내려가게 연출합니다.
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);

        }
    }

    /// <summary>
    /// 슬라임이 플레이어로부터 공격을 받았을 때의 상황을 처리하는 함수
    /// </summary>
    /// <param name="amount">데미지 수치</param>
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        //죽음 처리가 안됬고, 체력이 0보다 작은 경우 죽음 판정
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    /// <summary>
    /// 슬라임이 플레이어로부터 공격을 받았을 때 넉백 효과 연출
    /// </summary>
    /// <param name="damage">데미지</param>
    /// <param name="playerPosition">플레이어 위치</param>
    /// <param name="delay">딜레이</param>
    /// <param name="pushback">푸쉬백</param>
    /// <returns></returns>
    public IEnumerator StartDamage(int damage, Vector3 playerPosition, float delay , float pushback)
    {
        if(gameObject != null)
        {
            yield return new WaitForSeconds(delay);
            //딜레이 시간 뒤 다시 작업을 진행합니다.

            //try는 예외 상황이 발생할 수 잇는 코드에 작성해주는 예외 처리문
            try
            {
                //데미지를 줍니다.
                TakeDamage(damage);
                //거리를 측정합니다.
                Vector3 diff = playerPosition - transform.position;
                //거리의 범위만큼 나눠줍니다.
                diff /= diff.sqrMagnitude;
                //물체에서 그 수치만큼 튕겨나가도록 연출하겠습니다.
                GetComponent<Rigidbody>().AddForce((transform.position - new Vector3(diff.x, diff.y, 0.0f)) * 50f * pushback);
            }
            catch (MissingReferenceException e)
            //코루틴을 돌리고 있는 상황에서 객체가 사라진 상태에서 다시 그 객체를 참조하려고 할 때 발생하는 오류
            //현재 슬라임이 체력이 0보다 낮아지면 Destroy되는 상황이기에 Missing이 날 수 밖에 없는 상황
            {
                Debug.Log(e.ToString());
            }

        }
      
    }

    /// <summary>
    /// 슬라임의 죽음 시 호출할 함수
    /// </summary>
    void Death()
    {
        isDead = true;
        StageController.instance.AddPoint(10);

        transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
        //애니메이션 트리거 작동
        //죽을 때 사용할 클립으로 변경 후 오디오 실행
        StartSinking();
    }

    /// <summary>
    /// 사후 처리 
    /// </summary>
    public void StartSinking()
    {
        //NavMeshAgent 비활성화
        GetComponent<NavMeshAgent>().enabled = false;

        //외부에서 가해지는 물리적인 힘에 반응하지 않겠습니다.
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        Destroy(gameObject, 2.0f);

    }


}
