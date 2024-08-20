using UnityEngine;
using UnityEngine.UI;

public class MarkerController : MonoBehaviour
{
    public GameObject arrowPrefab;  // Prefab cho mũi tên định hướng
    public Camera mainCamera;
    public GameObject arrowInstance;
   public Transform armatureTransform;

    void Start()
    {
        mainCamera = Camera.main;
        //armatureTransform = transform.parent.parent.Find("Armature");

        // Tạo mũi tên nhưng ẩn nó đi ban đầu
        arrowInstance = Instantiate(arrowPrefab);
        arrowInstance.SetActive(false);
    }

    void Update()
    {
        // Kiểm tra vị trí của "Armature"
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(armatureTransform.position);

        // Kiểm tra nếu "Armature" nằm ngoài màn hình
        bool isOnScreen = screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;

        if (!isOnScreen)
        {
            arrowInstance.SetActive(true);
            Vector3 arrowPosition = GetArrowPosition(screenPoint);
            arrowInstance.transform.position = arrowPosition;

            // Tính toán hướng của mũi tên
            Vector3 direction = (armatureTransform.position - mainCamera.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            arrowInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            arrowInstance.SetActive(false);
        }
    }

    private Vector3 GetArrowPosition(Vector3 screenPoint)
    {
        Vector3 arrowScreenPoint = screenPoint;
        if (screenPoint.x < 0) arrowScreenPoint.x = 0;
        if (screenPoint.x > 1) arrowScreenPoint.x = 1;
        if (screenPoint.y < 0) arrowScreenPoint.y = 0;
        if (screenPoint.y > 1) arrowScreenPoint.y = 1;

        return mainCamera.ViewportToWorldPoint(arrowScreenPoint);
    }
}
