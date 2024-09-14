using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombirManager : MonoBehaviour
{
    public Animator anim;
    public Transform IsCheckEnemy;
    private void Start()
    {
         anim = transform.GetComponent<Animator>();


    }
    public void Update()
    {
        if (transform.gameObject == PlayerAttack.instance.enemy)
        {
            IsCheckEnemy.gameObject.SetActive(true);

        }
        else
        {
            IsCheckEnemy.gameObject.SetActive(false);
        }
    }
    public void Awake()
    {
        Walk();
       
    }
    public void Wait()
    {
        StartCoroutine(WaitForThreeSeconds());
    }
    public IEnumerator WaitForThreeSeconds()
    {
        //Debug.Log("Started waiting...");

        // Đợi trong 3 giây
        yield return new WaitForSeconds(3f);

        // Thực hiện hành động sau khi đợi
        transform.GetComponent<ZombieMoving>().zombieSpeed = 2.5f;
        Run();
    }
    public void Walk() {
        anim.SetFloat("Walk", 1);
    }
    public void Run() {
        anim.SetFloat("Run", 1);
    }
    public void SpawnZombie()
    {
        transform.GetComponent<ZombieMoving>().zombieSpeed = 0.5f;
        Walk();
        Wait();
    }

}
