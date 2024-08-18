using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character; // Nhân vật mà camera sẽ theo dõi
    public Vector3 offset; // Khoảng cách so với nhân vật
    public Vector3 offsetRotation; // Góc xoay của camera so với nhân vật

    void LateUpdate()
    {
        // Cập nhật vị trí của camera với offset so với vị trí của nhân vật
        transform.position = character.position + offset;

        // Tạo một góc xoay từ Vector3 offsetRotation và nhân với góc quay của nhân vật
        Quaternion rotationOffset = Quaternion.Euler(offsetRotation);
        transform.rotation = character.rotation * rotationOffset;
    }
}
