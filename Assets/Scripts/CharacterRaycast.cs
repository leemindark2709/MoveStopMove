using UnityEngine;

public class CharacterRaycast : MonoBehaviour
{
    public float raycastDistance = 10f; // Khoảng cách của raycast

    void Update()
    {
        // Tính toán hướng raycast xuống góc 45 độ
        Vector3 direction = Quaternion.Euler(45, 0, 0) * Vector3.down;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
        {
            Debug.DrawRay(transform.position, direction, Color.red);
            // Kiểm tra xem đối tượng va chạm có tag là "map" không
            if (hit.collider.CompareTag("map"))
            {
                //Debug.Log("Raycast hit an object with tag 'map': " + hit.collider.name);
            }
            else
            {
                Debug.Log("Raycast hit an object without tag 'map': " + hit.collider.name);
            }
        }
        else
        {
            //// Nếu raycast không va chạm với bất kỳ đối tượng nào
            //Debug.Log("Raycast did not hit any object with tag 'map'");
        }
    }
}
