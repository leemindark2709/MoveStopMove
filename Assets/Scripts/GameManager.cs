using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //Map//
    public Transform MainMap;
    public Transform ZomBieMap;
    public Transform PlayerCamera;
    public int Gold;
    public Transform namePlayer;
    public bool checkShopWeapon;
    public static GameManager Instance;
    public GameObject enemyPrefab; // Prefab of the enemy
    public GameObject rankObject;
    public GameObject SettingObject;
    public int numEnemyAlive;
    public List<Transform> spawnPoints = new List<Transform>();
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
    private float lastSpawnTime; // Time of the last spawn
    public int NumEnemySpawn = 10;
    public int counyEnemy = 11;
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


    public int NumOfRevice = 2;
    public bool EndGame;
    public bool isPause;
    public Transform PLayer;
    public int numofSpawnDie = 1;
    public Transform UiNamePoint;

    public RectTransform GoldHome;

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
        //CharSkin.gameObject.SetActive(false);
    }
    public Material GetRandomMaterial()
    {
        if (EnemyMaterial.Count == 0)
        {
            Debug.LogWarning("Danh sách EnemyMaterial rỗng. Trả về null.");
            return null; // Xử lý trường hợp danh sách rỗng
        }

        int randomIndex = Random.Range(0, EnemyMaterial.Count);
        return EnemyMaterial[randomIndex];
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
        Gold = 5000;
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

    // Update is called once per frame
    void Update()
    {
        GoldHome  = Home.GetComponent<Home>().Gold;
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
        SkinnedMeshRenderer renderer = shadingGroup.GetComponent<SkinnedMeshRenderer>();
                // Chọn một material ngẫu nhiên từ danh sách EnemyMaterial
                Material randomMaterial = GetRandomMaterial();
                if (randomMaterial != null)
                {
                    renderer.material = randomMaterial;
                    spawnedEnemy.transform.Find("Canvas").Find("UIPoint").GetComponent<Image>().color=randomMaterial.color;
                }
        /////////////////////////////////Weapon///////////////////////////////////////
        RandomWeapon(spawnedEnemy);
        ///////////////////////////////////Skin/////////////////////////////////////
        RandomSkin(spawnedEnemy);
        spawnedEnemy.GetComponent<EnemyMoving>().name = "Enemy" + NumEnemySpawn;
        spawnedEnemy.transform.Find("Canvas").Find("Name").GetComponent<TextMeshProUGUI>().text = "Enemy" + NumEnemySpawn;




    }
    public  void RandomSkin(GameObject spawnedEnemy)
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
