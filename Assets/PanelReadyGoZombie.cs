using System.Collections;
using TMPro;
using UnityEngine;

public class PanelReadyGoZombie : MonoBehaviour
{
    public Transform NumberGo;

    private void OnEnable()
    {
        // Bắt đầu quá trình hiển thị số đếm ngược
        StartCoroutine(CountdownCoroutine());
    }

    // Coroutine để thực hiện đếm ngược
    private IEnumerator CountdownCoroutine()
    {
        // Hiển thị số 3
        NumberGo.GetComponent<TextMeshProUGUI>().text = "3";
        yield return new WaitForSeconds(1f); // Chờ 1 giây

        // Hiển thị số 2
        NumberGo.GetComponent<TextMeshProUGUI>().text = "2";
        yield return new WaitForSeconds(1f); // Chờ 1 giây

        // Hiển thị số 1
        NumberGo.GetComponent<TextMeshProUGUI>().text = "1";
        yield return new WaitForSeconds(1f); // Chờ 1 giây

        // Hiển thị "Go"
        NumberGo.GetComponent<TextMeshProUGUI>().text = "Go";
        yield return new WaitForSeconds(1f); // Chờ 1 giây
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = true;
        transform.gameObject.SetActive(false);
    }
}
