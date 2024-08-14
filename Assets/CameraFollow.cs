//using UnityEngine;

//public class CameraFollow : MonoBehaviour
//{
//    public Transform target; // Nhân vật mà camera sẽ theo dõi
//    public Vector3 offset; // Khoảng cách giữa camera và nhân vật
//    public float smoothSpeed = 0.125f; // Tốc độ mượt mà cho chuyển động của camera
//    public float tiltAngle = 30f; // Góc nghiêng của camera

//    void LateUpdate()
//    {
//        if (target == null)
//        {
//            return; // Nếu không có đối tượng theo dõi, thoát khỏi hàm
//        }

//        // Tính toán vị trí mới của camera
//        Vector3 desiredPosition = target.position + offset;

//        // Áp dụng góc nghiêng cho camera
//        Quaternion desiredRotation = Quaternion.Euler(tiltAngle, 0, 0);

//        // Tính toán vị trí camera mượt mà
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//        transform.position = smoothedPosition;

//        // Đặt góc quay của camera
//        transform.rotation = desiredRotation;
//    }
//}
