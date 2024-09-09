using System.Collections;
using UnityEngine;

public class ButtonCancelCharSkin : MonoBehaviour
{
    public RectTransform Panel0;
    public RectTransform Panel1;
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public CameraFollow cameraFollow; // Reference to CameraFollow script
    public float transitionDuration = 0.1f; // Time to smoothly transition

    // Start is called before the first frame update
    void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        Panel0 = GameObject.Find("CharSkinPoint0").gameObject.GetComponent<RectTransform>();
        Panel1 = GameObject.Find("CharSkinPoint1").gameObject.GetComponent<RectTransform>();

        // Initialize cameraFollow reference
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Move smoothly from start to target position
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for next frame
        }

        // Ensure the final position is set accurately
        uiElement.anchoredPosition = targetPosition;
    }

    public void OnButtonClick()
    {
        if (!GameManager.Instance.CharSkin.gameObject.activeSelf)
        {
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));

        }
        else
        {
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
            transform.parent.GetComponent<RectTransform>().anchoredPosition = Panel0.anchoredPosition;

            // Start coroutine to smoothly change camera offset and rotation
            StartCoroutine(ChangeCameraOffsetAndRotation());
            GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().anim.Play("Idle");

        }
        foreach (var hair in HairSkinManager.instance.HairItemPosition)
        {
            hair.gameObject.SetActive(false);


        }
        GameManager.Instance.FullSetSkin.gameObject.SetActive(true);

            HairSkinManager.instance.IsHair.gameObject.SetActive(true);
            HairSkinManager.instance.CheckHair = null;
            GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
            TrousersSkinManager.instance.FindPositionHariItem("Pants").GetComponent<Renderer>().material
        = TrousersSkinManager.instance.IsTrousers;
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
            ShieldSkinManager.instance.DisableShield();
            ShieldSkinManager.instance.IsShield.gameObject.SetActive(true);
            //ShieldSkinManager.instance.CheckShield = null;
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);

        GameManager.Instance.FullSetSkin.gameObject.SetActive(true);
        FullSetSkinManager.instance.DisableFullSet();
        FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(true);
        if (FullSetSkinManager.instance.IsFullSet != FullSetSkinManager.instance.FullSetItemPosition[0])
        {
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").gameObject.GetComponent<Renderer>().material =
          FullSetSkinManager.instance.ButtonFullSetItemChose.Find("BackGround").gameObject.GetComponent<ButtonItemFullSetSkin>().material;
            FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
        }
        else
        {
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").gameObject.GetComponent<Renderer>().material =
     GameManager.Instance.Yeallow;
            FullSetSkinManager.instance.ButtonFullSetItemChose = null;
            FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = GameManager.Instance.Pants;
        }
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        //}
        //GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        //if (TrousersSkinManager.instance.IsTrousers= TrousersSkinManager.instance.materials[0])
        //{
        //    FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
        //}
        //GameManager.Instance.TrousersSkin.gameObject.SetActive(false);

    }

    private IEnumerator ChangeCameraOffsetAndRotation()
    {
        // Store initial values
        float startOffsetY = cameraFollow.offset.y;
        float endOffsetY = 0.36f;

        float startOffsetZ = cameraFollow.offset.z;
        float endOffsetZ = -0.6f;

        float startRotationOffsetX = cameraFollow.offsetRotation.x;
        float endRotationOffsetX = 39f;

        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / transitionDuration;

            // Lerp between start and end offset Y
            cameraFollow.offset.y = Mathf.Lerp(startOffsetY, endOffsetY, t);

            // Lerp between start and end offset Z
            cameraFollow.offset.z = Mathf.Lerp(startOffsetZ, endOffsetZ, t);

            // Lerp between start and end rotation offset X
            cameraFollow.offsetRotation.x = Mathf.Lerp(startRotationOffsetX, endRotationOffsetX, t);

            yield return null; // Wait for next frame
        }

        // Ensure the final values are set
        cameraFollow.offset.y = endOffsetY;
        cameraFollow.offset.z = endOffsetZ;
        cameraFollow.offsetRotation.x = endRotationOffsetX;
    }
}
