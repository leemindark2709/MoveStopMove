using System.Collections;
using TMPro;
using UnityEngine;

public class Die : MonoBehaviour
{
    public static Die Instance { get; private set; }
    public Transform Load;
    public Transform Timer;
    public float countdownDuration = 5f; // Thời gian bắt đầu đếm ngược
    public TextMeshProUGUI timeText;
    private float rotationSpeed = 300f; // Tốc độ quay quanh trục Z
    public float interval = 1f; // Khoảng thời gian cập nhật đồng hồ
    private float elapsedTime = 0f; // Biến đếm thời gian
    [SerializeField] private bool isCounting = false; // Điều khiển trạng thái đếm ngược
    public bool isClickButtonRevive = false; // Biến kiểm tra xem nút hồi sinh có được bấm không
    Transform GameManagerLMD;
    public Transform Revive;
    private void Awake()
    {
        Instance = this;
        GameManagerLMD = GameObject.Find("GameManager").transform;
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
        if (intTime < 0 || isClickButtonRevive)
        {
            if (isClickButtonRevive)
            {
                intTime = 5;

                GameManager.Instance.EndGame = false;
                GameManager.Instance.Dead.gameObject.SetActive(false);
                isCounting = false;
            }
            else
            {

                intTime = 5;

                GameManager.Instance.EndGame = false;

                isCounting = false;
            }
        }

        timeText.text = intTime.ToString();
        yield return null; // Thực hiện một lần
    }

    public IEnumerator CountdownCoroutine()
    {
        float elapsedTime = -1f;

        while (elapsedTime < countdownDuration)
        {
            float remainingTime = countdownDuration - elapsedTime;
            timeText.text = Mathf.Max(Mathf.Ceil(remainingTime) - 1, 0).ToString();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        timeText.text = "0";

        // Thêm log để kiểm tra
        Debug.Log("Countdown finished. Disabling object.");

        // Vô hiệu hóa đối tượng mà script này đang gắn vào
        if (GameManager.Instance.Mode != "ZombieCity")
        {
            GameManager.Instance.TouchToContinue.gameObject.SetActive(true);
            gameObject.SetActive(false);

        }
        else
        {
            GameManager.Instance.Home.GetComponent<Home>().PanelEndGameZombie.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        //GameManager.Instance.Dead.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        isClickButtonRevive = false;
        //isClickButtonRevive = false;
        elapsedTime = 0;
        if (GameManagerLMD.GetComponent<GameManager>() != null && GameManagerLMD.GetComponent<GameManager>().Mode != "ZombieCity")
        {
            StartCoroutine(MoveRankAndSetting());
            isCounting = true; // Kích hoạt đếm ngược
        }
        else
        {
            isCounting = true; // Kích hoạt đếm ngược
        }
        StartCoroutine(CountdownCoroutine());
    }


    private void OnDisable()
    {
        isCounting = false; // Ngừng đếm ngược
        elapsedTime = 0f; // Reset thời gian
        isClickButtonRevive = false;
        timeText.text = "5";
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


}