
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2f;

    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;

    private float timer;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        player = GameObject.Find("player").transform;

        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        Track();
        Skill();
    }


    private void Skill()
    {
        if(nav.remainingDistance < stopDistance)
        {

            ani.SetTrigger("跳舞觸發");

        }
    }

    //追蹤
    private void Track()
    {
        nav.SetDestination(player.position);

        // print("剩餘的距離:" + nav.remainingDistance);
        ani.SetBool("跑步開關", + nav.remainingDistance > stopDistance);
    }
}
