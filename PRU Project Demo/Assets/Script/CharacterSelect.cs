using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public static CharacterSelect instance;
    [SerializeField] public GunScriptableObject gunData;
    [SerializeField] public PlayerScriptableObject playerData;

    private GameObject currentStartingWeapon;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static PlayerScriptableObject GetPlayerData()
    {
        return instance.playerData;
    }

    public static GunScriptableObject GetGunData()
    {
        return instance.gunData;
    }

    public void SelectWeaponData(GunScriptableObject gun)
    {
        gunData = gun;
    }

    public void SelectWeapon(GameObject gun)
    {
        currentStartingWeapon = gun;
        playerData.startingWeapon = currentStartingWeapon;
    }

    public void SelectPlayer(PlayerScriptableObject player)
    {
        playerData = player;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
