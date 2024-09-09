using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public
    Transform newWeapon;
    //Map//
    public Transform MainMap;
    public Transform ZomBieMap;
    public Transform PlayerCamera;
    public int Gold;
    public Transform namePlayer;
    public bool checkShopWeapon;
    public static GameManager Instance;
    public GameObject enemyPrefab; // Prefab of the enemy
    public GameObject ZombiePrefab; // Prefab of the enemy

    public GameObject rankObject;
    public GameObject SettingObject;
    public int numEnemyAlive;
    public int numZombieAlive;
    public List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> spawnZombiePoints = new List<Transform>();
    public List<Material> EnemyMaterial = new List<Material>();
    public List<string> WeaponEnemys = new List<string>();
    public List<string> EnemySkinRandom = new List<string>();


    public List<string> HairEnemySkins = new List<string>();
    public List<string> ShieldEnemySkins = new List<string>();
    public List<Material> TrousersEnemySkins = new List<Material>();

    public List<string> FullSetEnemySkins = new List<string>();
    public List<Material> FullSetEnemySkinMaterials= new List<Material>();

    public Transform ShopWeapon;
    private float spawnCooldown = 2f; // Cooldown between spawns
    private float spawnZombieCooldown = 1.2f; // Cooldown between spawns
    private float lastSpawnTime; // Time of the last spawn
    public int NumEnemySpawn = 10;
    public int counyEnemy = 11;


    public int NumZombieSpawn =100;
    public int counyZombie = 103;

    public bool isStart;
    public Transform button;
    public Transform WinGame;
    public Transform Dead;
    public Transform InGame;
    public Transform TouchToContinue;
    public Transform SettingTouch;
    public Transform Home;
    public Transform Shop;
    public Transform HairSkin;
    public Transform TrousersSkin;
    public Transform ShieldSkin;
    public Transform FullSetSkin;
    public Transform TopButton;
    public Transform PanelHairButton;
    public Transform PanelTrousersButton;
    public Transform PanelShieldButton;
    public Transform PanelFullSetButton;
    public Transform CharSkin;
    public SkinnedMeshRenderer   Mesh;

    public Transform HairSelectUnequip;
    public Transform TrousersSelectUnequip;
    public Transform ShieldSelectUnequip;
    public Transform FullSetSelectUnequip;

    public Material Yeallow;

    public Mesh Pants;
    public Transform MainWeaponKnife;
    public Transform MainWeaponHammer;

    public Transform Armature;

    public int NumOfRevice = 2;
    public bool EndGame;
    public bool isPause;
    public Transform PLayer;
    public int numofSpawnDie = 1;
    public Transform UiNamePoint;

    public RectTransform GoldHome;
    public Transform newPosition;

    private int currentIndex = 0;
    public List<Transform> CorlorHammer = new List<Transform>();
    public bool IsWaitZombie ;
    public bool IsStartZomBie;
    public string Mode;
    public List<Transform> Zombies = new List<Transform>();
    private void Awake()
    {

     
        checkShopWeapon = false;
        UiNamePoint = GameObject.Find("UiNamePoint").transform;
        UiNamePoint.gameObject.SetActive(false);
        WinGame = GameObject.Find("WinGame").transform;
        WinGame.gameObject.SetActive(false);
        SettingObject = GameObject.Find("Setting");
        rankObject = GameObject.Find("Rank");
        FullSetSelectUnequip = GameObject.Find("FullSetSelectUnequip").transform;
        FullSetSelectUnequip.gameObject.SetActive(false);
        ShieldSelectUnequip = GameObject.Find("ShieldSelectUnequip").transform;
        ShieldSelectUnequip.gameObject.SetActive(false);
        HairSelectUnequip = GameObject.Find("HairSelectUnequip").transform;
        TrousersSelectUnequip = GameObject.Find("TrousersSelectUnequip").transform;
        TrousersSelectUnequip.gameObject.SetActive(false);
        ShopWeapon = GameObject.Find("ShopWeapon").transform;
        ShopWeapon.gameObject.SetActive(false);
        Instance = this;
        Dead = GameObject.Find("Dead").transform;
        Dead.gameObject.SetActive(false);
        button = GameObject.Find("ButtonResum").transform;
        button.gameObject.SetActive(false);
        InGame = GameObject.Find("InGame").transform;
        InGame.gameObject.SetActive(false);
        TouchToContinue = GameObject.Find("TouchToContinue").transform;
        TouchToContinue.gameObject.SetActive(false);
        SettingTouch = GameObject.Find("SettingTouch").transform;
        SettingTouch.gameObject.SetActive(false);
        Home = GameObject.Find("Home").transform;
        Shop = GameObject.Find("Shop").transform;
        Shop.gameObject.SetActive(false);
        PLayer = GameObject.Find("Player").transform;
        HairSkin = GameObject.Find("HairSkin").transform;
        HairSkin.gameObject.SetActive(false);
        TrousersSkin = GameObject.Find("TrousersSkin").transform;
        TrousersSkin.gameObject.SetActive(false);
        ShieldSkin = GameObject.Find("ShieldSkin").transform;
        ShieldSkin.gameObject.SetActive(false);
        FullSetSkin = GameObject.Find("FullSetSkin").transform;
        FullSetSkin.gameObject.SetActive(false);
        TopButton = GameObject.Find("TopButton").transform;
        PanelHairButton = TopButton.Find("HairButton").Find("Panel");
        PanelTrousersButton = TopButton.Find("TrousersButton").Find("Panel");
        PanelShieldButton = TopButton.Find("ShieldButton").Find("Panel");
        PanelFullSetButton = TopButton.Find("FullSetButton").Find("Panel");
        CharSkin = GameObject.Find("CharSkin").transform;
        //HammerChageCorlor();
        //CharSkin.gameObject.SetActive(false);
    }
    public Material GetNextMaterial()
    {
        if (EnemyMaterial.Count == 0)
        {
            Debug.LogWarning("Danh sách EnemyMaterial rỗng. Trả về null.");
            return null; // Xử lý trường hợp danh sách rỗng
        }

        // Lấy màu theo chỉ số hiện tại
        Material material = EnemyMaterial[currentIndex];

        // Cập nhật chỉ số hiện tại để lấy màu tiếp theo lần sau
        currentIndex = (currentIndex + 1) % EnemyMaterial.Count;

        return material;
    }
    public string GetRandomWeaponEnemy()
    {
        int randomIndex = Random.Range(0, WeaponEnemys.Count);
        return WeaponEnemys[randomIndex];
    }
    public string GetRandomSkin()
    {
        int randomIndex = Random.Range(0, EnemySkinRandom.Count);
        return EnemySkinRandom[randomIndex];
    }
    public string GetRandomHair()
    {
        int randomIndex = Random.Range(0, HairEnemySkins.Count);
        return HairEnemySkins[randomIndex];
    }
    public string GetRandomShield() {
        int randomIndex = Random.Range(0, ShieldEnemySkins.Count);
        return ShieldEnemySkins[randomIndex];
    }  
    public Material GetRandomTrousers()
    {
        int randomIndex = Random.Range(0, TrousersEnemySkins.Count);
        return TrousersEnemySkins[randomIndex];
    }
    public string GetRandomFullSet()
    {
        int randomIndex = Random.Range(0, FullSetEnemySkins.Count);
        return FullSetEnemySkins[randomIndex];
    }
    public void TurnOfComponentPlayer()
    {
        PLayer.Find("Canvas").gameObject.SetActive(false);
        PLayer.GetComponent<PlayerMovement>().enabled = false;

    } 
    public void TurnOnComponentPlayer()
    {
        PLayer.Find("Canvas").gameObject.SetActive(true);
        PLayer.GetComponent<PlayerMovement>().enabled = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("IsHair", "NoneHair"));
        GoldHome = Home.GetComponent<Home>().Gold;
        HairSkin.GetComponent<HairSkinManager>().IsHair = FindChildWithName(PLayer, PlayerPrefs.GetString("IsHair", "NoneHair"));
        FindChildWithName(PLayer, PlayerPrefs.GetString("IsHair", "NoneHair")).gameObject.SetActive(true);



        FindChildWithName(PLayer, "Pants").gameObject.GetComponent<SkinnedMeshRenderer>().sharedMesh = Pants;
        TrousersSkin.GetComponent<TrousersSkinManager>().IsTrousers = TrousersSkin.GetComponent<TrousersSkinManager>().FindMaterialByName(PlayerPrefs.GetString("IsTrousers", "Yealow"));
        FindChildWithName(PLayer,"Pants").gameObject.GetComponent<SkinnedMeshRenderer>().material= TrousersSkin.GetComponent<TrousersSkinManager>().IsTrousers;
        Gold = PlayerPrefs.GetInt("CountGold", 5000); // Đọc cấp độ nhân vật

        FindChildWithName(PLayer, PlayerPrefs.GetString("IsShield", "NoneHair")).gameObject.SetActive(true);

        if (PlayerPrefs.GetString("IsFullSet", "NoneFullSet") != "NoneFullSet")
        {
            FullSetSkin.GetComponent<FullSetSkinManager>().IsFullSet = FindChildWithName(PLayer, PlayerPrefs.GetString("IsFullSet", "NoneFullSet"));
            FindChildWithName(PLayer, PlayerPrefs.GetString("IsFullSet", "NoneFullSet")).gameObject.SetActive(true);
            foreach (Transform item in FullSetSkin.GetComponent<FullSetSkinManager>().FullSetItemButtons)
            {
                if (item.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().nameItem == PlayerPrefs.GetString("IsFullSet", "NoneFullSet"))
                {
                    FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = item.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().material;
                    FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
                }
            }

        }
        SetMainWeapon();







        TurnOfComponentPlayer();
        SetUpCamera();
        isStart = false;
        NumEnemySpawn = 20;
        numEnemyAlive = 0;
        counyEnemy = 21;
        lastSpawnTime = -spawnCooldown; // Allow spawning immediately at the start

        if (counyEnemy == 0)
        {
            PauseGame();
            return;
        }

        // Check if CheckPointSpawnEnemy.Instance is properly initialized
        if (CheckPointSpawnEnemy.Instance != null)
        {
            spawnPoints = CheckPointSpawnEnemy.Instance.Enemys;
        }
        else
        {
            Debug.LogError("CheckPointSpawnEnemy.Instance is not set.");
        }

    }

    public void HammerChageCorlor()
    {
        foreach (Transform Corlor in CorlorHammer)
        {
            if (PlayerPrefs.GetString("HammerLeftColor", "Red") == Corlor.GetComponent<ChoseCorlorWeapon>().NameColor)
            {
                Armature.GetComponent<PlayerAttack>().weapon.GetComponent<MeshRenderer>().materials[0].color = Corlor.GetComponent<ChoseCorlorWeapon>().color;
            }
            if (PlayerPrefs.GetString("HammerRightColor", "Red") == Corlor.GetComponent<ChoseCorlorWeapon>().NameColor)
            {
                Armature.GetComponent<PlayerAttack>().weapon.GetComponent<MeshRenderer>().materials[1].color = Corlor.GetComponent<ChoseCorlorWeapon>().color;
            }
        }
    }
    // Update is called once per frame
    public void SetMainWeapon()
    {
        MainWeaponHammer = GameManager.Instance.ShopWeapon.GetChild(1).Find("MainWeapon");
        MainWeaponKnife = GameManager.Instance.ShopWeapon.GetChild(0).Find("MainWeapon");

        // Lấy MeshRenderer của đối tượng trong ListWeapons[5].GetChild(0)
        MeshRenderer sourceRenderer = GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].GetChild(0).GetComponent<MeshRenderer>();

        // Lấy MeshRenderer của MainWeaponHammer
        MeshRenderer hammerRenderer = MainWeaponHammer.GetComponent<MeshRenderer>();

        if (sourceRenderer != null && hammerRenderer != null)
        {
            // Gán toàn bộ các materials từ sourceRenderer sang hammerRenderer
            hammerRenderer.materials = sourceRenderer.materials;
        }
        else
        {
            Debug.LogError("MeshRenderer không tìm thấy trên MainWeaponHammer hoặc ShopWeapon.");
        }

        // Lấy MeshRenderer của vũ khí trong PlayerAttack
     
      
        MeshRenderer weaponRenderer = Armature.GetComponent<PlayerAttack>().weapon.GetComponent<MeshRenderer>();

        // Lấy MeshRenderer của MainWeaponHammer
        MeshRenderer hammerRenderer2 = MainWeaponHammer.GetComponent<MeshRenderer>();

        if (weaponRenderer != null && hammerRenderer2 != null)
        {
            // Gán toàn bộ các materials từ hammerRenderer sang weaponRenderer
            weaponRenderer.materials = hammerRenderer.materials;
        }
        else
        {
            Debug.LogError("MeshRenderer không tìm thấy trên weapon hoặc MainWeaponHammer.");
        }

        foreach (Transform weapon in GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons)
        {
            if (weapon.GetChild(0).GetComponent<PlayerDameSender>().NameWeapon == PlayerPrefs.GetString("Weapon", "Knife1"))
            {
                Debug.Log(PlayerPrefs.GetString("Weapon", "Knife1"));
                if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
                {
                    MainWeaponHammer = weapon.GetComponent<ButtonPickWeapon>().MainWeapon;

                    // Tạo bản sao của Weapon
                    Transform weaponCopy = Instantiate(weapon.GetChild(0));

                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy.position = MainWeaponHammer.position;
                    weaponCopy.rotation = MainWeaponHammer.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy.SetParent(MainWeaponHammer.parent, true);
                    Destroy(MainWeaponHammer.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    MainWeaponHammer = weaponCopy;
                    MainWeaponHammer.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon;
                    oldWeapon = Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                    newWeapon = Instantiate(weapon.GetChild(0));
                    if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                    }
                    else
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                    }
                    newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý

                    if (PlayerPrefs.GetString("Weapon", "Hammer")=="Hammer")
                    {
                        Debug.Log("Is here");
                        Debug.Log(PlayerPrefs.GetString("HammerLeftColor", "Red"));
                        Debug.Log(PlayerPrefs.GetString("HammerRightColor", "Red"));
                        foreach (Transform Corlor in CorlorHammer)
                        {
                            if (PlayerPrefs.GetString("HammerLeftColor", "Red") == Corlor.GetComponent<ChoseCorlorWeapon>().NameColor)
                            {
                                newWeapon.GetComponent<MeshRenderer>().sharedMaterials[0].color = Corlor.GetComponent<ChoseCorlorWeapon>().color;
                            }
                            if (PlayerPrefs.GetString("HammerRightColor", "Red") == Corlor.GetComponent<ChoseCorlorWeapon>().NameColor)
                            {
                                newWeapon.GetComponent<MeshRenderer>().sharedMaterials[1].color = Corlor.GetComponent<ChoseCorlorWeapon>().color;
                            }
                        }

                    }
                 
                    newWeapon.parent = oldWeapon.parent;
                    newWeapon.localScale = oldWeapon.localScale;
                    newWeapon.localPosition = newPosition.localPosition;
                    newWeapon.localRotation = oldWeapon.localRotation;
                    newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                    Armature.GetComponent<PlayerAttack>().weapon = newWeapon;
                    //HammerChageCorlor();

                    Destroy(oldWeapon.gameObject);

                    /////////////////////////////////////////////////////////////////



                    Transform weaponCopy2 = Instantiate(GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[0].GetChild(0));

                    MainWeaponKnife = GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[0].GetComponent<ButtonPickWeapon>().MainWeapon;
                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy2.position = MainWeaponKnife.position;
                    weaponCopy2.rotation = MainWeaponKnife.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy2.SetParent(MainWeaponKnife.parent, true);
                    Destroy(MainWeaponKnife.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy2.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    MainWeaponKnife = weaponCopy2;
                    MainWeaponKnife.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon2;
                    oldWeapon2 = Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                    newWeapon = Instantiate(weapon.GetChild(0));
                    if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                    }
                    else
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                    }
                    newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                    newWeapon.parent = oldWeapon2.parent;
                    newWeapon.localScale = oldWeapon2.localScale;
                    newWeapon.localPosition = newPosition.localPosition;
                    newWeapon.localRotation = oldWeapon2.localRotation;
                    newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                    Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                    Destroy(oldWeapon2.gameObject);
                }




                if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Knife")
                {
                   /////////////////////////////////////////////////////////////////////////
                    MainWeaponHammer = GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].GetComponent<ButtonPickWeapon>().MainWeapon;

                    // Tạo bản sao của Weapon
                    Transform weaponCopy1 = Instantiate(GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].GetChild(0));

                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy1.position = MainWeaponHammer.position;
                    weaponCopy1.rotation = MainWeaponHammer.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy1.SetParent(MainWeaponHammer.parent, true);
                    Destroy(MainWeaponHammer.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy1.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    MainWeaponHammer = weaponCopy1;
                    MainWeaponHammer.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon1;
                    oldWeapon1 = Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                    newWeapon = Instantiate(weapon.GetChild(0));
                    if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                    }
                    else
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                    }
                    newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                    newWeapon.parent = oldWeapon1.parent;
                    newWeapon.localScale = oldWeapon1.localScale;
                    newWeapon.localPosition = newPosition.localPosition;
                    newWeapon.localRotation = oldWeapon1.localRotation;
                    newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                    Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                    Destroy(oldWeapon1.gameObject);
                    ///////////////////////////////////////////////////////////////////
                    // Tạo bản sao của Weapon





                    Transform weaponCopy = Instantiate(weapon.GetChild(0));

                    MainWeaponHammer = weapon.GetComponent<ButtonPickWeapon>().MainWeapon;
                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy.position = MainWeaponKnife.position;
                    weaponCopy.rotation = MainWeaponKnife.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy.SetParent(MainWeaponKnife.parent, true);
                    Destroy(MainWeaponKnife.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    MainWeaponKnife = weaponCopy;
                    MainWeaponKnife.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon;
                    oldWeapon = Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                    newWeapon = Instantiate(weapon.GetChild(0));
                    if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                    }
                    else
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                    }
                    newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                    newWeapon.parent = oldWeapon.parent;
                    newWeapon.localScale = oldWeapon.localScale;
                    newWeapon.localPosition = newPosition.localPosition;
                    newWeapon.localRotation = oldWeapon.localRotation;
                    newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                    Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                    Destroy(oldWeapon.gameObject);

                }


            }
        }
    }
    void Update()
    {
       
        GoldHome.transform.GetComponent<TextMeshProUGUI>().text = Gold.ToString();
        // Check if the player is dead
      
        if (EndGame&&numofSpawnDie==1)
        {
            StartCoroutine(DelayEnableDie());
        }

        // If there are fewer than 6 enemies and the cooldown has passed, spawn a new enemy
        if (numEnemyAlive < 8 && Time.time - lastSpawnTime >= spawnCooldown && NumEnemySpawn > 0&&isStart)
        {
            SpawnEnemy();
            numEnemyAlive += 1;
            lastSpawnTime = Time.time; // Update the last spawn time
        }
        if ( Time.time - lastSpawnTime >= spawnZombieCooldown && NumZombieSpawn > 0&&IsStartZomBie)
        {
            SpawnZombie();
            numZombieAlive += 1;
            lastSpawnTime = Time.time; // Update the last spawn time
        }

    }
    public void SetUpCamera()
    {
        
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -0.6f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 0.36f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offsetRotation.x = 39;
    }

    private IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PauseGame();
    }
    private IEnumerator DelayEnableDie()
    {
        yield return new WaitForSeconds(2);

        // Kiểm tra liên tục cho đến khi numofSpawnDie == 1
        while (numofSpawnDie != 1)
        {
            yield return null; // Chờ đến khung hình tiếp theo
        }

        // Khi numofSpawnDie == 1, thực hiện các hành động sau
        if (PlayerAttack.instance.NumOfDead == 0)
        {
            Dead.gameObject.SetActive(true);
            numofSpawnDie = 0;
        }
    }


    private void PauseGame()
    {
        button.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    public void SpawnEnemy()
    {
        NumEnemySpawn -= 1;
        if (enemyPrefab == null)
        {
            Debug.LogError("enemyPrefab is not assigned.");
            return;
        }

        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points available.");
            return;
        }

        // Chọn một vị trí spawn ngẫu nhiên từ danh sách
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform randomSpawnPoint = spawnPoints[randomIndex];

        // Tạo một bản sao của enemyPrefab tại vị trí và góc quay của spawn point ngẫu nhiên
        GameObject spawnedEnemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        ////////////////////////////////////Skin///////////////////////////////
        Transform shadingGroup = spawnedEnemy.transform.Find("Armature").Find("initialShadingGroup1");
        spawnedEnemy.transform.Find("Armature").localScale = PLayer.transform.Find("Armature").localScale;
        SkinnedMeshRenderer renderer = shadingGroup.GetComponent<SkinnedMeshRenderer>();
        // Chọn một material ngẫu nhiên từ danh sách EnemyMaterial
        Material randomMaterial = GetNextMaterial();
        if (randomMaterial != null)
        {
            renderer.material = randomMaterial;
            spawnedEnemy.transform.Find("Armature").Find("Canvas").Find("UIPoint").GetComponent<Image>().color = randomMaterial.color;
        }
        /////////////////////////////////Weapon///////////////////////////////////////
        RandomWeapon(spawnedEnemy);
        ///////////////////////////////////Skin/////////////////////////////////////
        RandomSkin(spawnedEnemy);
        spawnedEnemy.GetComponent<EnemyMoving>().name = "Enemy" + NumEnemySpawn;
        spawnedEnemy.transform.Find("Armature").Find("Canvas").Find("Name").GetComponent<TextMeshProUGUI>().text = "Enemy" + NumEnemySpawn;




    }
    public void SpawnZombie()
    {
        NumZombieSpawn -= 1;
        if (ZombiePrefab == null)
        {
            Debug.LogError("enemyPrefab is not assigned.");
            return;
        }

        if (spawnZombiePoints == null || spawnZombiePoints.Count == 0)
        {
            Debug.LogError("No spawn points available.");
            return;
        }

        // Chọn một vị trí spawn ngẫu nhiên từ danh sách
        int randomIndex = Random.Range(0, spawnZombiePoints.Count);
        Transform randomSpawnPoint = spawnZombiePoints[randomIndex];

        // Tạo một bản sao của enemyPrefab tại vị trí và góc quay của spawn point ngẫu nhiên
        GameObject spawnedZombieEnemy = Instantiate(ZombiePrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // Đảm bảo rằng bạn đang chỉnh sửa vị trí của Transform
        Vector3 newPosition = spawnedZombieEnemy.transform.position;
        newPosition.y = 0.58f; // Đặt giá trị y theo mong muốn
        spawnedZombieEnemy.transform.position = newPosition; // Cập nhật lại vị trí

        Zombies.Add(spawnedZombieEnemy.transform);
        spawnedZombieEnemy.GetComponent<ZombieMoving>().zombieSpeed = 2.5f;
        spawnedZombieEnemy.GetComponent<ZombirManager>().Run();



        Transform shadingGroup = spawnedZombieEnemy.transform.Find("lp_guy_mesh");
    
        SkinnedMeshRenderer renderer = shadingGroup.GetComponent<SkinnedMeshRenderer>();
        // Chọn một material ngẫu nhiên từ danh sách EnemyMaterial
        Material randomMaterial = GetNextMaterial();
        if (randomMaterial != null)
        {
            renderer.material = randomMaterial;
          
        }
     
    }
    public void RandomSkin(GameObject spawnedEnemy)
    {
        FindChildWithName(spawnedEnemy.transform,"Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
        string typeSkin;
        string HairEnemySkin;
        typeSkin = GetRandomSkin();
        List<Transform> AllHairSkin = new List<Transform>();
        if (typeSkin=="Hair")
        {
            HairEnemySkin = GetRandomHair();
            foreach (string hair in HairEnemySkins)
            {
                if (hair== HairEnemySkin)
                {
                    FindChildWithName(spawnedEnemy.transform, hair).gameObject.SetActive(true);
                }
                
            }
        }
        string ShieldEnemySkin;
        if (typeSkin=="Shield")
        {
            ShieldEnemySkin =GetRandomShield();
            foreach (string shield in ShieldEnemySkins)
            {
                if(shield== ShieldEnemySkin)
                {
                    FindChildWithName(spawnedEnemy.transform, shield).gameObject.SetActive(true);
                }

            }
        }
        if (typeSkin == "Trousers")
        {
            FindChildWithName(spawnedEnemy.transform, "Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = GameManager.Instance.Pants;
            FindChildWithName(spawnedEnemy.transform, "Pants").GetComponent<Renderer>().material = GetRandomTrousers();
        }
        string FullSetEnemySkin;
        int index;
        if (typeSkin == "FullSet")
        {
            FullSetEnemySkin = GetRandomFullSet();
            for (int i = 0; i < FullSetEnemySkins.Count; i++)
            {
                string fullset = FullSetEnemySkins[i];
                if (fullset == FullSetEnemySkin)
                {
                    index = i;
                    // Here, i is the index of the fullset in the array
                    FindChildWithName(spawnedEnemy.transform, fullset).gameObject.SetActive(true);
                    // Use the index i as needed
                    // Example: print or use the index
                    Debug.Log("Index of the fullset: " + i);

                    // Optional: use the commented-out code if needed
                    FindChildWithName(spawnedEnemy.transform, "initialShadingGroup1").GetComponent<Renderer>().material = FullSetEnemySkinMaterials[i];
                }
            }
        }



    }

    public void RandomWeapon(GameObject spawnedEnemy)
    {
        List<Transform> EnemyWeapon = new List<Transform>();
        string mainweapon = GetRandomWeaponEnemy();
        Transform mainWeapon = null;

        foreach (string weapon in WeaponEnemys)
        {
            Transform foundWeapon = FindChildWithName(spawnedEnemy.transform, weapon);

            if (foundWeapon != null)
            {
                if (weapon == mainweapon)
                {
                    mainWeapon = foundWeapon;

                    // Kiểm tra tồn tại của thành phần EnemyMoving trước khi gán
                    EnemyMoving enemyMoving = spawnedEnemy.transform.GetComponent<EnemyMoving>();
                    if (enemyMoving != null)
                    {
                        enemyMoving.Weapon = mainWeapon;
                    }
                    else
                    {
                        Debug.LogWarning("EnemyMoving component not found on spawned enemy.");
                    }
                }
                else
                {
                    Destroy(foundWeapon.gameObject);
                }
            }
        }

        if (mainWeapon != null)
        {
            mainWeapon.name = "Hammer";
        }
        else
        {
            Debug.LogWarning("Main weapon not found. Cannot rename to Hammer.");
        }
    }
    public Transform FindChildWithName(Transform parent, string nameToFind)
    {
        // Kiểm tra xem tên của Transform hiện tại có phải là tên cần tìm không
        if (parent.name == nameToFind)
        {
            return parent; // Trả về Transform nếu tên khớp
        }

        // Duyệt qua tất cả các đối tượng con của Transform hiện tại
        foreach (Transform child in parent)
        {
            // Gọi đệ quy để tìm kiếm trong các đối tượng con
            Transform result = FindChildWithName(child, nameToFind);
            if (result != null)
            {
                return result; // Trả về Transform nếu tìm thấy
            }
        }

        return null; // Trả về null nếu không tìm thấy
    }

    public void DeleteAllEnemies()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Destroy each object
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
    public void MovePositionRankAndSettinglmd()
    {
        StartCoroutine(MovePositionRankAndSetting());
    }

    public IEnumerator MovePositionRankAndSetting()
    {
        
        if (rankObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Rank!");
            yield break;
        }

        Vector3 startPosition1 = rankObject.transform.position;
        Vector3 targetPosition1 = GameObject.Find("PointEnemy1").GetComponent<RectTransform>().position;

        
        if (SettingObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Setting!");
            yield break;
        }

        Vector3 startPosition2 = SettingObject.transform.position;
        Vector3 targetPosition2 = GameObject.Find("PointSetting1").GetComponent<RectTransform>().position;

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
    }   public void ReturnPositionRankAndSettinglmd()
    {
        StartCoroutine(ReturnPositionRankAndSetting());
    }

    public IEnumerator ReturnPositionRankAndSetting()
    {
        
        if (rankObject == null)
        {
            Debug.LogError("Không tìm thấy đối tượng Rank!");
            yield break;
        }

        Vector3 startPosition1 = rankObject.transform.position;
        Vector3 targetPosition1 = GameObject.Find("PointEnemy0").GetComponent<RectTransform>().position;

        
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
