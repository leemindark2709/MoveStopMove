using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrousersSkinManager : MonoBehaviour
{
    public static TrousersSkinManager instance;
    public List<Transform> TrousersItemButtons = new List<Transform>();
    public List<Transform> TrousersItemPosition = new List<Transform>();
    public List<Material> materials = new List<Material>(); // Danh sách các vật liệu
    public Transform Player; // Đối tượng Player
    public Material CheckTrousers;
    public Material IsTrousers;
    public Transform ButtonTrousersItemClick;
    public Material PantMaterial;
    public Renderer pantsRenderer;
    public Transform pantsTransform;
    public Transform ButtonTrousersItemChose;

      public Transform FindPositionTrousersItem(string nameItem)
    {
        return FindInChildren(Player.transform, nameItem);
    }

    private void Awake()
    {
       
        Player = GameManager.Instance.PLayer;
        //pantsTransform = FindPositionHariItem("Pants");
        //if (pantsTransform != null)
        //{
        //    // Kiểm tra nếu đối tượng "Pants" có Renderer
        //    pantsRenderer = pantsTransform.GetComponent<Renderer>();
        //    if (pantsRenderer != null)
        //    {
        //        // Gán material đầu tiên từ danh sách materials cho Pants
        //        PantMaterial = materials[2];
        //        pantsRenderer.material = PantMaterial;
        //    }
        //}

        int index = 0;
        foreach (Transform t in transform)
        {
            Debug.Log(PlayerPrefs.GetString("Trousers", "Yealow"));
            t.Find("EquippedText").gameObject.SetActive(false);
            if (t.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("Trousers", "Yealow"))
            {
                ButtonTrousersItemChose = t;
                t.Find("EquippedText").gameObject.SetActive(true);
            }

            if (index != 0)
            {
                t.Find("Border").gameObject.SetActive(false);
            }
            index++; // Tăng chỉ số index
        }

        if (transform.name == "TrousersSkin")
        {
            GameManager.Instance.TrousersSkin.GetComponent<TrousersSkinManager>().ButtonTrousersItemClick
= GameManager.Instance.TrousersSkin.GetComponent<TrousersSkinManager>().TrousersItemButtons[0];

        }

        IsTrousers = FindMaterialByName( PlayerPrefs.GetString("IsTrousers", "Yealow"));
        instance = this;
    }

    private void Update()
    {

    }
    public Material FindMaterialByName(string materialName)
    {
        // Duyệt qua tất cả các material trong mảng
        foreach (Material mat in materials)
        {
            // Kiểm tra nếu tên của material trùng khớp với tên cần tìm
            if (mat.name == materialName)
            {
                return mat; // Trả về material tìm được
            }
        }

        // Nếu không tìm thấy material nào, trả về null
        return null;
    }

    private void Start()
    {
        // Sử dụng FindPositionHariItem để lấy đối tượng "Pants" và sau đó lấy Renderer
      
     

    }
    public void DisableEquippedText()
    {
        foreach (Transform t in TrousersItemButtons)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
        }
    }
    public Transform FindPositionHariItem(string nameItem)
    {
        return FindInChildren(Player, nameItem);
    }

    private Transform FindInChildren(Transform parent, string nameItem)
    {
        foreach (Transform child in parent)
        {
            if (child.name == nameItem)
            {
                return child;
            }

            Transform found = FindInChildren(child, nameItem); // Gọi đệ quy
            if (found != null)
            {
                return found;
            }
        }
        return null; // Không tìm thấy
    }
    public void disableAllPanel()
    {

        foreach (Transform t in TrousersItemButtons)
        {
            t.Find("Border").gameObject.SetActive(false);
        }

    }

    public void enableAll()
    {
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(true);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(false);
        //HairSkinManager.instance.DisableHair();
        //HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        //HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");

        TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.CheckTrousers = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.materials[0];


        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (Button == TrousersSkinManager.instance.ButtonTrousersItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }

    }
}
