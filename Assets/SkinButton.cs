using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;



public class SkinButton : MonoBehaviour
{
    public CameraFollow cameraFollow; // Tham chiếu đến script CameraFollow
    public float transitionDuration = 0.1f; // Thời gian để chuyển đổi từ từ
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform Panel0;
    public RectTransform Panel1;
    public void Awake()
    {
  

    }
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();

    }

    public void OnButtonClick()
    {
        
        GameManager.Instance.CharSkin.gameObject.SetActive(true);
        Panel0=GameObject.Find("CharSkinPoint1").GetComponent<RectTransform>();

        GameManager.Instance.CharSkin.gameObject.GetComponent<RectTransform>().anchoredPosition = Panel0.anchoredPosition;
        StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        // Bắt đầu coroutine để thay đổi offset.z và offsetRotation.x
        StartCoroutine(ChangeCameraOffsetAndRotation());
        GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().anim.Play("Dance");
        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        GameManager.Instance.PanelHairButton.gameObject.SetActive(false);
        GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
        GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);
        GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);
        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        if (HairSkinManager.instance.CheckHair==null)
        {

            HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
            HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        }


        enableAllPanel();



    }

    public void enableAllPanel()
    {
        foreach (Transform item in HairSkinManager.instance.HairItemButtons)
        {
            if (HairSkinManager.instance.ButtonHairItemChose == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                != HairSkinManager.instance.ButtonHairItemChose.GetComponent<RectTransform>())
            {
                Debug.Log("click");
                item.Find("Border").gameObject.SetActive(false);
                //item.Find("Border").gameObject.SetActive(true);

            }
            else
            {
                item.Find("Border").gameObject.SetActive(true);

            }

        }
        foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (TrousersSkinManager.instance.TrousersItemButtons == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                != TrousersSkinManager.instance.ButtonTrousersItemChose.GetComponent<RectTransform>())
            {
                Debug.Log("click");
                item.Find("Border").gameObject.SetActive(false);
                //item.Find("Border").gameObject.SetActive(true);

            }
            else
            {
                item.Find("Border").gameObject.SetActive(true);

            }

        }

    }
    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Smoothly move the UI element from start to target position
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is set accurately
        uiElement.anchoredPosition = targetPosition;
    }
    private IEnumerator ChangeCameraOffsetAndRotation()
    {
        // Lưu trữ giá trị ban đầu
        float startOffsetZ = cameraFollow.offset.z;
        float endOffsetZ = -0.95f;

        float startRotationOffsetX = cameraFollow.offsetRotation.x;
        float endRotationOffsetX = 33.1f;

        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            // Tính toán tỷ lệ thời gian đã trôi qua
            elapsed += Time.deltaTime;
            float t = elapsed / transitionDuration;

            // Lerp giữa startOffsetZ và endOffsetZ
            cameraFollow.offset.z = Mathf.Lerp(startOffsetZ, endOffsetZ, t);

            // Lerp giữa startRotationOffsetX và endRotationOffsetX
            cameraFollow.offsetRotation.x = Mathf.Lerp(startRotationOffsetX, endRotationOffsetX, t);

            yield return null; // Đợi đến frame tiếp theo
        }

        // Đảm bảo giá trị kết thúc là giá trị mong muốn
        cameraFollow.offset.z = endOffsetZ;
        cameraFollow.offsetRotation.x = endRotationOffsetX;
    }
}
