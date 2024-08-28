using UnityEngine;

public class MaintainRotationUiNamePoint : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Lưu lại rotation ban đầu của object
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Đặt lại rotation của object về giá trị ban đầu
        transform.rotation = initialRotation;
    }
}
