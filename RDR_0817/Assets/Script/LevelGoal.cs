using UnityEngine;
using UnityEngine.UI;


public class LevelGoal : MonoBehaviour
{
    [SerializeField]
    CapsuleCollider player;
    [SerializeField]
    BoxCollider trigger;

    public GameObject gameOverUI;
    private ScoreCount _scoreCount;
    public static bool goal;

    

    private void Awake()
    {
        goal = false;
    }

    private void Start()
    {
        player = GameObject.Find("DOG").GetComponent<CapsuleCollider>();
        _scoreCount = GameObject.Find("GameManger").GetComponent<ScoreCount>();
        trigger = GetComponent<BoxCollider>();
        
        if(player != null && trigger != null)
        {
            Physics.IgnoreCollision(player, trigger); // nullreference

        }
        
    }

    private void Update()
    {



    }


    private void OnParticleCollision(GameObject other)
    {

        if (other.name == "Pee(Clone)" && goal == false)
        {
            goal = true;
            _scoreCount.AddScore(30);
            Invoke("openGameOVerUI", 3f);
            print("開啟結算");
            // 凍結畫面

        }


    }

    private void OnCollisionEnter(Collision Hit)
    {
        if(Hit .gameObject.tag == "poo")
        {
            goal = true;
            _scoreCount.AddScore(30);
            print("開啟結算");
            Invoke("openGameOVerUI", 3f);
        }
    }

    private void openGameOVerUI()
    {
        gameOverUI.SetActive(true); // 開啟分數結算畫面
    }

    


}
