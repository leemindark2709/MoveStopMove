using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZombieRotation : MonoBehaviour
{
    // Biến để tham chiếu đến đối tượng Weapon cần quay
    public Transform Weapon;

    // Tốc độ quay của Weapon
    public float rotationSpeed = 5000f; // có thể điều chỉnh tùy thuộc vào tốc độ bạn muốn

    // Update được gọi mỗi khung hình
    void Update()
    {
        // Kiểm tra xem Weapon có được gán hay không
        if (Weapon != null)
        {
            // Quay Weapon quanh trục Y của nó
            Weapon.Rotate(new Vector3(0,0,-1), rotationSpeed * Time.deltaTime);
        }
    }
}
