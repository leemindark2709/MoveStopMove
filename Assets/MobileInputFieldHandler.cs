using TMPro;
using UnityEngine;

public class MobileInputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField; // Sử dụng TMP_InputField

    void Start()
    {
        // Đăng ký sự kiện khi người dùng bắt đầu nhập liệu
        inputField.onSelect.AddListener(ShowVirtualKeyboard);
        inputField.onEndEdit.AddListener(OnInputEnd);
    }

    // Phương thức được gọi khi người dùng chọn vào InputField (hiển thị bàn phím ảo)
    void ShowVirtualKeyboard(string text)
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Phương thức được gọi khi người dùng hoàn tất nhập liệu
    private void OnInputEnd(string text)
    {
        Debug.Log("User entered: " + text);
        // Xử lý văn bản mà người dùng đã nhập, chẳng hạn như cập nhật tên người chơi
        GameManager.Instance.namePlayer.gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }
}
