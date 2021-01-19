using UnityEngine;
using Invector.vCharacterController;

public class player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Damage()
    {
        hp -= 35;
        ani.SetTrigger("受傷觸發");



    }

}
