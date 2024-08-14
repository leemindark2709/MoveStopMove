using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDameSender : MonoBehaviour
{
    public bool checkTree=true;
    public Transform targetTree; // Cây mục tiêu cần kiểm tra
    public float timeReturn;

    private void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu game object không thuộc cây targetTree thì mới xoá
        if (!IsChildOf(other.transform, targetTree)&& other.tag=="Enemy")
        {

            Destroy(other.transform.parent.gameObject);
            GameManager.Instance.numEnemy -= 1;
            if (targetTree != null)
            {
                // Tăng scale của targetTree lên 0.1 lần
                targetTree.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                targetTree.GetComponent<EnemyMoving>().detectionRadius += targetTree.GetComponent<EnemyMoving>().detectionRadius * 0.5f;
            }
        }
    }

    // Hàm kiểm tra xem transform có phải là con của cây mục tiêu hay không
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
        if (targetTree!=null)
        {
            timeReturn = targetTree.GetComponent<PlayerAttack>().timeToReturn;

        }
        if (checkTree==false)
        {

            StartCoroutine(CheckTreeStatus());
        }
     
    }

    private IEnumerator CheckTreeStatus()
    {
        // Chờ 2 giây
        yield return new WaitForSeconds(timeReturn);

        // Kiểm tra nếu checkTree là false và targetTree là null thì xoá chính object này
        if (!checkTree && targetTree == null)
        {
            Destroy(gameObject);
        }
    }
}
