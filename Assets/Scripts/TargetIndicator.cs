using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TargetIndicator : MonoBehaviour
{
    public GameObject OffScreenTargetIndicator; // Đối tượng chứa nhiều hình ảnh
    public float OutOfSightOffset = 20f;
    private float outOfSightOffest { get { return OutOfSightOffset * canvasRect.localScale.x; } }

    [SerializeField] private GameObject target;
    private Camera mainCamera;
    private RectTransform canvasRect;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
       

    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Transform imageTransform = OffScreenTargetIndicator.transform.Find("Image");
            Image offScreenImage = imageTransform.GetComponent<Image>();

            Transform targetImageTransform = target.transform.Find("Armature").Find("Canvas").Find("UIPoint");
            if (targetImageTransform != null)
            {
                Image targetImage = targetImageTransform.GetComponent<Image>();
                if (targetImage != null)
                {
                    offScreenImage.sprite = targetImage.sprite; // Sao chép sprite
                    offScreenImage.color = targetImage.color;   // Sao chép màu sắc
                    Debug.Log("Đã sao chép sprite và màu sắc thành công.");
                }
            }

            // Kiểm tra và gán TextMeshProUGUI
            Transform pointTransform = OffScreenTargetIndicator.transform.Find("UIPoint/point");
            if (pointTransform != null)
            {
                TextMeshProUGUI offScreenText = pointTransform.GetComponent<TextMeshProUGUI>();
                Transform targetPointTransform = target.transform.Find("UIPoint/Point");
                if (targetPointTransform != null)
                {
                    TextMeshProUGUI targetText = targetPointTransform.GetComponent<TextMeshProUGUI>();
                    if (targetText != null)
                    {
                        offScreenText.text = targetText.text;  // Sao chép văn bản
                        offScreenText.color = targetText.color; // Sao chép màu sắc văn bản
                        Debug.Log("Đã sao chép văn bản và màu sắc thành công.");
                    }
                }
            }
            UpdateTargetIndicator();
        }
    }

    public void InitialiseTargetIndicator(GameObject target, Camera mainCamera, Canvas canvas)
    {
        this.target = target;
        this.mainCamera = mainCamera;
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    public void UpdateTargetIndicator()
    {
        if (target == null) return;

        SetIndicatorPosition();
    }

    protected void SetIndicatorPosition()
    {
        Vector3 indicatorPosition = mainCamera.WorldToScreenPoint(target.transform.position);

        if (indicatorPosition.z >= 0f && indicatorPosition.x <= canvasRect.rect.width * canvasRect.localScale.x
         && indicatorPosition.y <= canvasRect.rect.height * canvasRect.localScale.x && indicatorPosition.x >= 0f && indicatorPosition.y >= 0f)
        {
            indicatorPosition.z = 0f;
            targetOutOfSight(false, indicatorPosition);
        }
        else if (indicatorPosition.z >= 0f)
        {
            indicatorPosition = OutOfRangeindicatorPositionB(indicatorPosition);
            targetOutOfSight(true, indicatorPosition);
        }
        else
        {
            indicatorPosition *= -1f;
            indicatorPosition = OutOfRangeindicatorPositionB(indicatorPosition);
            targetOutOfSight(true, indicatorPosition);
        }

        rectTransform.position = indicatorPosition;
    }

    private Vector3 OutOfRangeindicatorPositionB(Vector3 indicatorPosition)
    {
        indicatorPosition.z = 0f;
        Vector3 canvasCenter = new Vector3(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f, 0f) * canvasRect.localScale.x;
        indicatorPosition -= canvasCenter;

        float divX = (canvasRect.rect.width / 2f - outOfSightOffest) / Mathf.Abs(indicatorPosition.x);
        float divY = (canvasRect.rect.height / 2f - outOfSightOffest) / Mathf.Abs(indicatorPosition.y);

        if (divX < divY)
        {
            float angle = Vector3.SignedAngle(Vector3.right, indicatorPosition, Vector3.forward);
            indicatorPosition.x = Mathf.Sign(indicatorPosition.x) * (canvasRect.rect.width * 0.5f - outOfSightOffest) * canvasRect.localScale.x;
            indicatorPosition.y = Mathf.Tan(Mathf.Deg2Rad * angle) * indicatorPosition.x;
        }
        else
        {
            float angle = Vector3.SignedAngle(Vector3.up, indicatorPosition, Vector3.forward);
            indicatorPosition.y = Mathf.Sign(indicatorPosition.y) * (canvasRect.rect.height / 2f - outOfSightOffest) * canvasRect.localScale.y;
            indicatorPosition.x = -Mathf.Tan(Mathf.Deg2Rad * angle) * indicatorPosition.y;
        }

        indicatorPosition += canvasCenter;
        return indicatorPosition;
    }

    private void targetOutOfSight(bool oos, Vector3 indicatorPosition)
    {
        if (oos)
        {
            if (!OffScreenTargetIndicator.activeSelf) OffScreenTargetIndicator.SetActive(true);

            RotateOffScreenIndicators(indicatorPosition);
        }
        else
        {
            if (OffScreenTargetIndicator.activeSelf) OffScreenTargetIndicator.SetActive(false);
        }
    }

    private void RotateOffScreenIndicators(Vector3 indicatorPosition)
    {
        Vector3 canvasCenter = new Vector3(canvasRect.rect.width / 2f, canvasRect.rect.height / 2f, 0f) * canvasRect.localScale.x;
        float angle = Vector3.SignedAngle(Vector3.up, indicatorPosition - canvasCenter, Vector3.forward);
        OffScreenTargetIndicator.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
