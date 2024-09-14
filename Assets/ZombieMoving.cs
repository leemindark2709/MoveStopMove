using UnityEngine;

public class ZombieMoving : MonoBehaviour
{
    public Transform player;    // Biến tham chiếu đến vị trí của Player
    public float zombieSpeed = 0.5f;  // Tốc độ di chuyển của zombie

    private void Awake()
    {
        player = GameManager.Instance.Armature;
    }

    private void Update()
    {
        // Kiểm tra xem player có tồn tại không
        if (player != null&&! player.GetComponent<PlayerAttack>().isDead)
        {
            // Di chuyển zombie về phía Player với tốc độ zombieSpeed
            transform.position = Vector3.MoveTowards(transform.position, player.position, zombieSpeed * Time.deltaTime * 0.1f);

            // Quay mặt zombie về phía Player
            Vector3 direction = (player.position - transform.position).normalized;  // Lấy hướng từ zombie tới Player
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)); // Tạo một Quaternion để xoay theo hướng
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5); // Xoay mượt mà

            // Nếu zombie đã đến gần Player, có thể thêm hành động khác tại đây
            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                Debug.Log("Zombie has reached the player!");
            }
        }
    }
}
