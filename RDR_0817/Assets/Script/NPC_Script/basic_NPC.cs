using UnityEngine;
using UnityEngine.AI;

public class basic_NPC : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent NPC;

    public float MaxDistance = 10f;
    public Transform[] _patrolPoints;
    [Header("驚嘆號")]
    public GameObject mark;
    public static DataManager _dataManager;

    Transform Player;
    int _currentPatrolIndex;
    bool _playerisHere;
    bool __alarm;
    Animator ani;

    void Start()
    {
        _dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        Player = GameObject.Find("DOG").transform;
        NPC = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        if( NPC == null)
        {
            Debug.Log(gameObject.name + "Agent componet is missing !");
        }
        else
        {
            if(_patrolPoints != null)
            {
                _currentPatrolIndex = 0;
                SetDestination();                
            }

            else
            {
                Debug.Log("patrolPoint missing !");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        ani.SetFloat("speed", NPC.speed);
        checkPlayer();
           
        //// 玩家靠近 追趕玩家
        if (NPC.remainingDistance < 0.1f && !_playerisHere)
        {
            ChangePatrolPoint();
            SetDestination();
        }

        else if (_playerisHere)
        {           
            NPC.SetDestination(Player.position);
            print("發現玩家");
            // 追逐動作 警戒聲音
            mark.SetActive(true);
            // 頭上顯示驚嘆號
            NPC.speed = 6;            
            Debug.DrawLine(transform.position, Player.position);            
        }
        else
        {
            SetDestination();
            mark.SetActive(false);
        }

    }


    /// <summary>
    /// 前往巡邏點
    /// </summary>
    public void SetDestination()
    {
        Vector3 checkPoint = _patrolPoints[_currentPatrolIndex].transform.position;
        NPC.speed = 3;
        NPC.SetDestination(checkPoint);
        // NPC 走路動畫
        
    }
    /// <summary>
    /// 下一個巡邏點
    /// </summary>
    public void ChangePatrolPoint()
    {
        _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
    }

    public void checkPlayer()
    {

        // 加入更複雜的判斷 比如 距離 15~10 NPC 呈現警戒動作(動畫加驚嘆號)，  距離 10 才追玩家
        float dis = Vector3.Distance(transform.position, Player.position);
        //print(dis);
        if(dis < MaxDistance)
        {
            _playerisHere = true;                
        }
        if(dis < 0.5f)
        {
            // 攻擊音效
            ani.SetTrigger("ATK");
            
        }
        else
        {
            if (dis > MaxDistance)
            {
                _playerisHere = false;             
                
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if(hit .gameObject .name  == "DOG")
        {
            print("碰到玩家");
            _dataManager.LoadGame();
        }
    }

}
