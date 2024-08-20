using System.Collections;
using TMPro;
using UnityEngine;

public class Die : MonoBehaviour
{
    public Transform Load;
    public Transform Timer;
    public float countdownDuration = 5f; // Thời gian đếm ngược bắt đầu
    private TextMeshProUGUI timeText;
    private float rotationSpeed = 300f; // Tốc độ quay quanh trục Z
    public float interval = 1f;
    private float elapsedTime = 0f; // Biến đếm thời gian
    [SerializeField] private bool isCounting = false; // Biến để kiểm soát trạng thái đếm ngược

    private void Start()
    {
        Load = transform.Find("Canvas").Find("Panel").Find("Load");
        Timer = transform.Find("Canvas").Find("Panel").Find("Time");
        timeText = Timer.GetComponent<TextMeshProUGUI>();

        // Đảm bảo rằng component timeText đã được tìm thấy
        if (timeText == null)
        {
            Debug.LogError("Component TextMeshProUGUI không tìm thấy trên Timer.");
            return;
        }

        // Bắt đầu coroutine đếm ngược
        StartCoroutine(CountdownCoroutine());
    }

    private void Update()
    {
        // Quay Load quanh trục Z
        if (Load != null)
        {
            Load.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        // Chỉ cập nhật khi đối tượng đang được kích hoạt
        if (isCounting)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= interval)
            {
                StartCoroutine(CallMethodEveryInterval());
                elapsedTime = 0f; // Reset biến đếm thời gian
            }
        }
    }

    IEnumerator CallMethodEveryInterval()
    {
        // Cập nhật thời gian còn lại
        int intTime;
        string timerText = transform.Find("Canvas").Find("Panel").Find("Time").GetComponent<TextMeshProUGUI>().text;
        intTime = int.Parse(timerText);

        intTime -= 1;
        if (intTime < 0)
        {
            intTime = 5;
            transform.Find("Canvas").Find("Panel").Find("Time").GetComponent<TextMeshProUGUI>().text = intTime.ToString();

        }
        transform.Find("Canvas").Find("Panel").Find("Time").GetComponent<TextMeshProUGUI>().text = intTime.ToString();

        yield return null; // Không cần chờ thêm thời gian vì coroutine này chỉ cần thực hiện một lần
    }

    private IEnumerator CountdownCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < countdownDuration)
        {
            float remainingTime = countdownDuration - elapsedTime;
            timeText.text = Mathf.Max(Mathf.Ceil(remainingTime), 0).ToString();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo giá trị cuối cùng được đặt là 0
        timeText.text = "0";
    }

    private void OnEnable()
    {
        // Kích hoạt di chuyển đối tượng "Rank" trong 0.5s
        StartCoroutine(MoveRankAndSeting());
        isCounting = true; // Kích hoạt đếm ngược khi đối tượng được kích hoạt
    }

    private void OnDisable()
    {
        isCounting = false; // Ngừng đếm ngược khi đối tượng bị vô hiệu hóa
        elapsedTime = 0f; // Reset biến đếm thời gian khi vô hiệu hóa
    }

    private IEnumerator MoveRankAndSeting()
    {
        GameObject rankObject = GameObject.Find("Rank");
        Vector3 startPosition1 = rankObject.transform.position;
        Vector3 targetPosition1 = GameObject.Find("PointEnemy1").GetComponent<RectTransform>().position;

        GameObject SettingObject = GameObject.Find("Setting");
        if (SettingObject == null)
        {
            Debug.LogError("Setting object not found!");
            yield break;
        }
        Vector3 startPosition2 = SettingObject.transform.position;
        Vector3 targetPosition2 = GameObject.Find("PointSetting1").GetComponent<RectTransform>().position;

        float duration = 0.3f;
        float time = 0f;

        while (time < duration)
        {
            rankObject.transform.position = Vector3.Lerp(startPosition1, targetPosition1, time / duration);
            SettingObject.transform.position = Vector3.Lerp(startPosition2, targetPosition2, time / duration);

            Debug.Log("Moving Setting to: " + SettingObject.transform.position);

            time += Time.deltaTime;
            yield return null;
        }

        rankObject.transform.position = targetPosition1;
        SettingObject.transform.position = targetPosition2;

        Debug.Log("Final Position of Setting: " + SettingObject.transform.position);
    }

}
