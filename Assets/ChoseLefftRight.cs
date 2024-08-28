using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLefftRight : MonoBehaviour
{
    public Transform ChoseLeft;
    public bool isChoseLeft;
    public bool isChoseRight;
    public Transform ChoseRight;
    public MeshRenderer meshRenderer;
    public MeshRenderer meshRendererHAMMER;

    public List<Material> materials = new List<Material>(); // Sử dụng List để dễ thao tác hơn

    public void returnChoseColorWeapon()
    {
        // Xóa tất cả các phần tử trong List
        materials.Clear();

        // Kiểm tra sự tồn tại của MeshRenderer và MeshRendererHAMMER, sau đó thêm vật liệu vào List
        if (meshRenderer != null)
        {
            // Lấy tất cả các vật liệu từ meshRenderer và thêm vào List
            materials.AddRange(meshRenderer.materials);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy MeshRenderer trên đối tượng MainWeapon.");
        }

        if (meshRendererHAMMER != null)
        {
            // Lấy tất cả các vật liệu từ meshRendererHAMMER và thêm vào List
            materials.AddRange(meshRendererHAMMER.materials);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy MeshRenderer trên đối tượng HAMMER.");
        }
    }

    private void Start()
    {
        // Lấy thành phần MeshRenderer từ đối tượng cha
        meshRenderer = transform.parent.Find("MainWeapon").GetComponent<MeshRenderer>();
        meshRendererHAMMER = transform.parent.Find("HAMMER").Find("Hammer").GetComponent<MeshRenderer>();

        // Khởi tạo List materials bằng cách lấy tất cả các vật liệu từ meshRenderer và meshRendererHAMMER
        if (meshRenderer != null)
        {
            materials.AddRange(meshRenderer.materials);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy MeshRenderer trên đối tượng MainWeapon.");
        }

        if (meshRendererHAMMER != null)
        {
            materials.AddRange(meshRendererHAMMER.materials);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy MeshRenderer trên đối tượng HAMMER.");
        }

        // Khởi tạo trạng thái chọn
        isChoseLeft = true;
        isChoseRight = false;

        // Tìm và gán các đối tượng ChoseLeft và ChoseRight
        ChoseLeft = transform.Find("ChoseLeft").GetChild(0);
        ChoseRight = transform.Find("ChoseRight").GetChild(0);

        // Ẩn thành phần Image của ChoseRight
        if (ChoseRight != null && ChoseRight.parent != null)
        {
            Image imageComponent = ChoseRight.parent.gameObject.GetComponent<Image>();
            if (imageComponent != null)
            {
                imageComponent.enabled = false;
            }
            else
            {
                Debug.LogWarning("Không tìm thấy thành phần Image trên đối tượng cha của ChoseRight.");
            }
        }
        else
        {
            Debug.LogWarning("ChoseRight hoặc đối tượng cha của nó không tồn tại.");
        }
    }

    private void Update()
    {
        // Kiểm tra List materials có chứa ít nhất 2 phần tử
        if (materials != null && materials.Count >= 4)
        {
            if (ChoseLeft != null && ChoseRight != null)
            {
                // Lấy màu từ các thành phần Image
                Color chosenLeft = ChoseLeft.GetComponent<Image>().color;
                Color chosenRight = ChoseRight.GetComponent<Image>().color;

                // Cập nhật màu của vật liệu
                materials[0].color = chosenLeft;
                materials[1].color = chosenRight;
                materials[2].color = chosenLeft;
                materials[3].color = chosenRight;
            }
            else
            {
                Debug.LogWarning("ChoseLeft hoặc ChoseRight không tồn tại.");
            }
        }
        else
        {
            Debug.LogWarning("List materials không hợp lệ.");
        }
    }
}
