using System.Collections;
using TMPro;
using UnityEngine;

public class Die : MonoBehaviour
{   public static Die Instance { get; private set; }
    public Transform Load;
    public Transform Timer;
    public float countdownDuration = 5f; // Thời gian bắt đầu đếm ngược
    private TextMeshProUGUI timeText;
    private float rotationSpeed = 300f; // Tốc độ quay quanh trục Z
    public float interval = 1f; // Khoảng thời gian cập nhật đồng hồ
    private float elapsedTime = 0f; // Biến đếm thời gian
    [SerializeField] private bool isCounting = false; // Điều khiển trạng thái đếm ngược

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Load = transform.Find("Canvas").Find("Panel").Find("Load");
        Timer = transform.Find("Canvas").Find("Panel").Find("Time");
        timeText = Timer.GetComponent<TextMeshProUGUI>();

        if (timeText == null)
        {
            Debug.LogError("Không tìm thấy component TextMeshProUGUI trên Timer.");
            return;
        }

        StartCoroutine(CountdownCoroutine());
    }

    private void Update()
    {
        if (Load != null)
        {
            Load.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if (isCounting)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= interval)
            {
                StartCoroutine(CallMethodEveryInterval());
                elapsedTime = 0f; // Reset thời gian
            }
        }
    }

    private IEnumerator CallMethodEveryInterval()
    {
        int intTime;
        string timerText = timeText.text;
        intTime = int.Parse(timerText);

        intTime -= 1;
        if (intTime < 0)
        {
            GameManager.Instance.TouchToContinue.gameObject.SetActive(true);
            intTime = 5;

            GameManager.Instance.EndGame = false;
            GameManager.Instance.Dead.gameObject.SetActive(false);
            isCounting = false;
        }

        timeText.text = intTime.ToString();
        yield return null; // Thực hiện một lần
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

    timeText.text = "0";
    
    // Thêm log để kiểm tra
    Debug.Log("Countdown finished. Disabling object.");

    // Vô hiệu hóa đối tượng mà script này đang gắn vào
    gameObject.SetActive(false);
}



    private void OnEnable()
    {
        StartCoroutine(MoveRankAndSetting());
        isCounting = true; // Kích hoạt đếm ngược
    }

    private void OnDisable()
    {
        isCounting = false; // Ngừng đếm ngược
        elapsedTime = 0f; // Reset thời gian
    }

   public IEnumerator MoveRankAndSetting()
    {
        GameObject rankObject = GameObject.Find("Rank");
        Vector3 startPosition1 = rankObject.transform.position;
        Vector3 targetPosition1 = GameObject.Find("PointEnemy1").GetComponent<RectTransform>().position;

        GameObject SettingObject = GameObject.Find("Setting");
        if (SettingObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Setting!");
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

            time += Time.deltaTime;
            yield return null;
        }

        rankObject.transform.position = targetPosition1;
        SettingObject.transform.position = targetPosition2;
    }
    public IEnumerator ReturnPositionRankAndSetting()
    {
       
        GameObject rankObject = GameObject.Find("Rank");
        if (rankObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Rank!");
            yield break;
        }

        Vector3 startPosition1 = rankObject.transform.position;
        Vector3 targetPosition1 = GameObject.Find("PointEnemy0").GetComponent<RectTransform>().position;

        GameObject SettingObject = GameObject.Find("Setting");
        if (SettingObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Setting!");
            yield break;
        }

        Vector3 startPosition2 = SettingObject.transform.position;
        Vector3 targetPosition2 = GameObject.Find("PointSetting0").GetComponent<RectTransform>().position;

        float duration = 0.3f; // Thời gian cho quá trình di chuyển
        float time = 0f;

        while (time < duration)
        {
            // Nội suy vị trí cho rankObject
            rankObject.transform.position = Vector3.Lerp(startPosition1, targetPosition1, time / duration);

            // Nội suy vị trí cho SettingObject
            SettingObject.transform.position = Vector3.Lerp(startPosition2, targetPosition2, time / duration);

            time += Time.deltaTime;
            yield return null; // Chờ đến khung hình tiếp theo
        }

        // Đảm bảo vị trí cuối cùng chính xác tại vị trí đích
        rankObject.transform.position = targetPosition1;
        SettingObject.transform.position = targetPosition2;
        GameManager.Instance.SettingTouch.gameObject.SetActive(false);
    }

}
