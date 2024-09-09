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


       

        Panel0 =GameObject.Find("CharSkinPoint1").GetComponent<RectTransform>();

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


        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(true);


        if (!IsHairDiffirenceNone() && !IsTrousersDiffirenceNone() && !IsShieldDiffirenceNone() && !IsFullSetDiffirenceNone())
        {


            foreach (Transform item in HairSkinManager.instance.HairItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem == PlayerPrefs.GetString("IsHair", "NoneHair"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                }
            }
            foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem == PlayerPrefs.GetString("IsShield", "NoneShield"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsShield", "NoneShield"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem, 0) == 1)
                //{

                //    item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().IsUnlock = true;
                //}
                //if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                //{
                //    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                //}
            }
            foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("IsTrousers", "Yellow"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", "Yellow"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                }
            }

            if (HairSkinManager.instance.CheckHair == null)
            {

                HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
                HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
            }


            GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);




            GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
            ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);

            enableAllPanel();
            if (HairSkinManager.instance.IsHair == HairSkinManager.instance.HairItemPosition[4])
            {
                Debug.Log("NOOO");
                HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
                HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
                HairSkinManager.instance.CheckHair.gameObject.SetActive(true);

                HairSkinManager.instance.disableAllPanel();
                HairSkinManager.instance.HairItemButtons[0].Find("Border").gameObject.SetActive(true);
                HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.HairItemButtons[0];
                HairSkinManager.instance.ButtonHairItemChose = null;
                GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(false);
                GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(true);
                GameManager.Instance.HairSelectUnequip.Find("GoldHairItem").gameObject.SetActive(false);
                GameManager.Instance.HairSelectUnequip.Find("ADSHairItem").gameObject.SetActive(false);
                Debug.Log("loi r");
            }
            //if (HairSkinManager.instance.IsHair != HairSkinManager.instance.HairItemPosition[4])
            //{
            //    Debug.Log("okokokokok");
            //    ////HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            //    HairSkinManager.instance.IsHair.gameObject.SetActive(true);
            //    GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(true);
            //    GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(false);


            //}
            GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);

            GameManager.Instance.HairSkin.gameObject.SetActive(true);
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
            GameManager.Instance.FullSetSkin.gameObject.SetActive(false);


            //GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(true);
            //GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(true);
            //GameManager.Instance.HairSelectUnequip.Find("GoldHairItem").gameObject.SetActive(false);
            //GameManager.Instance.HairSelectUnequip.Find("ADSHairItem").gameObject.SetActive(false);
            //CharSkinManager.instance.ADSHairItem.gameObject.SetActive(false);
            //CharSkinManager.instance.GoldHairItem.gameObject.SetActive(false);

        }
        if (IsTrousersDiffirenceNone())
        {

            foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("IsTrousers", "Yellow"))
                {
                    TrousersSkinManager.instance.ButtonTrousersItemChose = item;
                    item.Find("EquippedText").gameObject.SetActive(true);
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", "Yellow"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));

                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                }
            }
            foreach (Transform item in HairSkinManager.instance.HairItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem == PlayerPrefs.GetString("IsHair", "NoneHair"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                }
            } 
            foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem == PlayerPrefs.GetString("IsShield", "NoneShield"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsShield", "NoneShield"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem, 0) == 1)
                //{

                //    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                //}
                //if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                //{
                //    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                //}
            }
            GameManager.Instance.HairSkin.gameObject.SetActive(false);
            GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
            GameManager.Instance.FullSetSkin.gameObject.SetActive(false);

            GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
            GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
            GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);
            GameManager.Instance.PanelTrousersButton.gameObject.SetActive(false);

            GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(true);
            GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);
            enableAllPanel();
            TrousersSkinManager.instance.ButtonTrousersItemClick = TrousersSkinManager.instance.ButtonTrousersItemChose;
            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.IsTrousers;

            TrousersSkinManager.instance.ButtonTrousersItemChose.Find("Border").gameObject.SetActive(true);
            GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(true);
            GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("ADSTrousersItem").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("GoldTrousersItem").gameObject.SetActive(false);

        }
        if (IsHairDiffirenceNone())
        {
            foreach (Transform item in HairSkinManager.instance.HairItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem == PlayerPrefs.GetString("IsHair", "NoneHair"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                }
            }
            foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("IsTrousers", "Yealow"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", "Yealow"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                }
            }

            GameManager.Instance.HairSkin.gameObject.SetActive(true);
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
            GameManager.Instance.FullSetSkin.gameObject.SetActive(false);

            GameManager.Instance.PanelHairButton.gameObject.SetActive(false);
            GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
            GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);
            GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);

            GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);
            enableAllPanel();
            HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.ButtonHairItemChose;
           HairSkinManager.instance.IsHair.gameObject.SetActive(true);
           
            HairSkinManager.instance.ButtonHairItemChose.Find("Border").gameObject.SetActive(true);
            GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(true);
            GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.Find("GoldHairItem").gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.Find("ADSHairItem").gameObject.SetActive(false);

            Debug.Log("duoc ma ta");

        }
      
        if (IsShieldDiffirenceNone())
        {
            foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem == PlayerPrefs.GetString("IsShield", "NoneShield"))
                {
                    ShieldSkinManager.instance.ButtonShieldItemChose = item;
                    item.Find("EquippedText").gameObject.SetActive(true);
                    Debug.Log(PlayerPrefs.GetString("IsShield", "NoneShield"));
                    ShieldSkinManager.instance.IsShield.gameObject.SetActive(true);
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));

                }

                //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                //{

                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                //}
                //if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                //{
                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                //}
            }
            foreach (Transform item in HairSkinManager.instance.HairItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem == PlayerPrefs.GetString("IsHair", "NoneHair"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                }
            }
            foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("IsTrousers", "Yealow"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", "Yealow"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                }
            }
            GameManager.Instance.HairSkin.gameObject.SetActive(false);
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
            GameManager.Instance.FullSetSkin.gameObject.SetActive(false);

            GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
            GameManager.Instance.PanelShieldButton.gameObject.SetActive(false);
            GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);
            GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);

            GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(true);
            GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);
            enableAllPanel();
            ShieldSkinManager.instance.ButtonShieldItemChose.Find("Border").gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(false);


        }
        if (IsFullSetDiffirenceNone())
        {
            foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem == PlayerPrefs.GetString("IsShield", "NoneShield"))
                {
                    //ShieldSkinManager.instance.ButtonShieldItemChose = item;
                    //item.Find("EquippedText").gameObject.SetActive(true);
                    //Debug.Log(PlayerPrefs.GetString("IsShield", "NoneShield"));
                    //ShieldSkinManager.instance.IsShield.gameObject.SetActive(true);
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));

                }

                //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                //{

                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                //}
                //if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                //{
                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                //}
            }
            foreach (Transform item in FullSetSkinManager.instance.FullSetItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().nameItem == PlayerPrefs.GetString("IsFullSet", "NoneFullSet"))
                {
                    FullSetSkinManager.instance.ButtonFullSetItemChose = item;
                    item.Find("EquippedText").gameObject.SetActive(true);
                    Debug.Log(PlayerPrefs.GetString("IsShield", "NoneShield"));
                    FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(true);
                 
                        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = item.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().material;
                        FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
                 
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));

                }

                //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                //{

                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                //}
                //if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                //{
                //    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                //}
            }
            foreach (Transform item in HairSkinManager.instance.HairItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem == PlayerPrefs.GetString("IsHair", "NoneHair"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().Lock.gameObject.SetActive(false);
                }
            }
            foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem == PlayerPrefs.GetString("IsTrousers", "Yealow"))
                {
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", "Yealow"));
                    //HairSkinManager.instance.IsHair = GameManager.Instance.FindChildWithName(GameManager.Instance.PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
                }

                if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 0) == 1)
                {

                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                }
                if (item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
                {
                    item.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Lock.gameObject.SetActive(false);
                }
            }

            GameManager.Instance.HairSkin.gameObject.SetActive(false);
            GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
            GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
            GameManager.Instance.FullSetSkin.gameObject.SetActive(true);

            GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
            GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
            GameManager.Instance.PanelFullSetButton.gameObject.SetActive(false);
            GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);

            GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
            GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(true);
            enableAllPanel();
            //FullSetSkinManager.instance.ButtonFullSetItemChose.Find("Border").gameObject.SetActive(true);
            GameManager.Instance.FullSetSelectUnequip.Find("UnequipFullSetItem").gameObject.SetActive(true);
            GameManager.Instance.FullSetSelectUnequip.Find("SelectFullSetItem").gameObject.SetActive(false);

        }





    }
    public bool IsHairDiffirenceNone() {
        if (HairSkinManager.instance.IsHair== HairSkinManager.instance.HairItemPosition[4])
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsTrousersDiffirenceNone() {
        if (TrousersSkinManager.instance.IsTrousers== TrousersSkinManager.instance.materials[0])
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool IsShieldDiffirenceNone() {
        
            if (ShieldSkinManager.instance.IsShield == ShieldSkinManager.instance.ShieldItemPosition[2])
            {
                return false;
            }
            else
            {
                return true;
            }
         }
    public bool IsFullSetDiffirenceNone()
    {
        if (FullSetSkinManager.instance.IsFullSet == FullSetSkinManager.instance.FullSetItemPosition[0])
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void enableAllPanel()
    {
        foreach (Transform item in HairSkinManager.instance.HairItemButtons)
        {

            //if (PlayerPrefs.GetInt(item.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 0) == 1)
            //{
            //    item.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
            //}
            if (HairSkinManager.instance.ButtonHairItemChose == null) break;
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
          
            //TrousersSkinManager.instance.ButtonTrousersItemClick.Find("Border").gameObject.SetActive(false);
            if (TrousersSkinManager.instance.ButtonTrousersItemChose == null) break;
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
        foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (ShieldSkinManager.instance.ButtonShieldItemChose == null) break;
            if (item.gameObject.GetComponent<RectTransform>()
                != ShieldSkinManager.instance.ButtonShieldItemChose.GetComponent<RectTransform>())
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
        foreach (Transform item in FullSetSkinManager.instance.FullSetItemButtons)
        {
            if (FullSetSkinManager.instance.ButtonFullSetItemChose == null) break;
            if (item.gameObject.GetComponent<RectTransform>()
                != FullSetSkinManager.instance.ButtonFullSetItemChose.GetComponent<RectTransform>())
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
