using System.Collections;
using TMPro;
using UnityEngine;

public class DameSender : MonoBehaviour
{
    public bool checkTree = true;
    public Transform targetTree; // Cây mục tiêu cần kiểm tra
    public float timeReturn;
    public Transform enemy;
    public string TypeWeapon;

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu game object không thuộc cây targetTree thì mới xoá
        if ((!IsChildOf(other.transform, targetTree) && other.CompareTag("Enemy"))|| other.CompareTag("Playerr"))
        {
            this.transform.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.GetComponent<BoxCollider>().enabled = false;

            scoreincrease();
         
            var otherEnemy = other.transform.parent.GetComponent<EnemyMoving>();
            if (otherEnemy != null)
            {

                Rigidbody rb = other.transform.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

                other.transform.GetComponent<BoxCollider>().enabled = false;

                //StartCoroutine(EnableBoxColider(other.transform.parent.gameObject));
                other.transform.parent.tag = "DieEnemy";
                otherEnemy.transform.Find("Armature").tag = "DieEnemy";
                //otherEnemy.anim.Play("Dead");
                otherEnemy.isDead = true;
                GameManager.Instance.numEnemyAlive -= 1;
                GameManager.Instance.counyEnemy -= 1;
                GameObject.Find("Num").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.counyEnemy.ToString();
                enemy = other.transform;
            }
            if (other.tag == "Playerr")
            {
                other.GetComponent<PlayerAttack>().isDead = true;
                other.GetComponent<PlayerAttack>().End = true;
                GameManager.Instance.TouchToContinue.Find("Canvas").Find("PanelRank").Find("NameKiller").GetComponent<TextMeshProUGUI>().text
                    = targetTree.GetComponent<EnemyMoving>().name;

            }


            //StartCoroutine(DelayDie(other.transform.parent.gameObject));


            if (targetTree != null)
            {
                targetTree.localScale += new Vector3(0.005f, 0.005f, 0.005f);
                targetTree.GetComponent<EnemyMoving>().detectionRadius += targetTree.GetComponent<EnemyMoving>().detectionRadius * 0.01f;
                this.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            }
        }
    }

    private bool IsChildOf(Transform child, Transform parent)
    {
        if (child == null) return false;
        Transform current = child;
        while (current != null)
        {
            if (current == parent) return true;
            current = current.parent;
        }
        return false;
    }

    private void Update()
    {
        if (targetTree != null)
        {
            timeReturn = targetTree.GetComponent<EnemyMoving>().timeToReturn;
        }

        if (!checkTree&& !targetTree.GetComponent<EnemyMoving>().isDead)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(CheckTreeStatus());
        }
        if (checkTree)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void scoreincrease()
    {
        if (targetTree != null)
        {
            var textComponent = targetTree.Find("Canvas/UIPoint/Point")?.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                if (float.TryParse(textComponent.text, out float pointValue))
                {
                    pointValue += 1f;
                    textComponent.text = pointValue.ToString();
                }
            }
        }
    }

    private IEnumerator CheckTreeStatus()
    {
        yield return new WaitForSeconds(timeReturn);

        if (!checkTree && targetTree == null)
        {   
            Destroy(gameObject);
        }
    }

    private IEnumerator DelayDie(GameObject enemy)
    {
        yield return new WaitForSeconds(2.4f);

        // Hủy đối tượng enemy sau khi thời gian trễ kết thúc
        
        Destroy(enemy);
        Debug.Log("ok-----------------");
    }   
    //private IEnumerator EnableBoxColider(GameObject enemy)
    //{

    //    yield return new WaitForSeconds(enemy.GetComponent<EnemyMoving>().timeToReturn);
    //    enemy.transfGetComponent<EnemyMoving>().Weapon.GetComponent<Rigidbody>().isKinematic = true;
    //    enemy.transform.parent.GetComponent<EnemyMoving>().Weapon.GetComponent<BoxCollider>().enabled = false;
    //    // Hủy đối tượng enemy sau khi thời gian trễ kết thúc
    //    Destroy(enemy);
    //}
}
