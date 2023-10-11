
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI TimerTextObj;

    public static UiManager instance;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI goldText;

    [Header("Health")]
    [SerializeField] GameObject HealthObject;
    [SerializeField] GameObject HealthLossPrefab;
    [SerializeField] float HealthOffset = -30;

    [Header("Gold")]
    [SerializeField] GameObject GoldObject;
    [SerializeField] GameObject GoldLossPrefab;
    [SerializeField] float GoldOffset = -30;


    public GameObject UiButtonPrefab;

    [SerializeField] GameObject spawnNextWaveButton;






    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        SetGoldText(GameManager.instance.GetGold().ToString());
        SetHealthText(GameManager.instance.GetHealth().ToString());
        EventManager.OnDamageTaken += UpdateHealthUiEvent;
        EventManager.OnGoldChange += UpdateGoldUiEvent;

    }

    void OnDisable()
    {
        EventManager.OnDamageTaken -= UpdateHealthUiEvent;
        EventManager.OnGoldChange -= UpdateGoldUiEvent;
    }

    public void SetTimerText(float time)
    {
        string timerTime = (Mathf.Floor(time) + 1).ToString();
        TimerTextObj.text = timerTime;
    }

    public void SetTimerText(string time)
    {
        TimerTextObj.text = time;
    }

    public void SetHealthText(string newHealthText)
    {
        healthText.text = newHealthText;
    }
    public void SetGoldText(string newGoldText)
    {
        goldText.text = newGoldText;
    }
    public void DisableTimerText()
    {
        TimerTextObj.gameObject.SetActive(false);
    }
    public void EnableTimerText()
    {
        TimerTextObj.gameObject.SetActive(true);
    }
    public void UpdateHealthText()
    {
        healthText.text = GameManager.instance.GetHealth().ToString();
    }

    public void UpdateGoldText()
    {
        goldText.text = GameManager.instance.GetGold().ToString();
    }

    public void DisableSpawnWaveButton()
    {
        spawnNextWaveButton.SetActive(false);
    }
    public void EnableSpawnWaveButton()
    {
        spawnNextWaveButton.SetActive(true);
    }

    public void SpawnHealthChangePrefab(int healthChange)
    {
        GameObject newHpObj = Instantiate(HealthLossPrefab, HealthObject.transform);
        Vector3 pos = newHpObj.GetComponent<RectTransform>().position;
        pos.y += HealthOffset;
        pos.x += HealthOffset * -1 / 3;
        newHpObj.GetComponent<RectTransform>().position = pos;
        newHpObj.GetComponent<HealthLossUIScript>().SetHealthLossText(healthChange);

    }

    void UpdateHealthUiEvent(int hpChange)
    {
        GameManager.instance.DoDamageToPlayer(hpChange);
        SpawnHealthChangePrefab(hpChange * -1);
        UpdateHealthText();
    }

    void UpdateGoldUiEvent(int goldToChange)
    {
        SpawnGoldChangePrefab(goldToChange);
        SetGoldText(GameManager.instance.GetGold().ToString());


    }
    public void SpawnGoldChangePrefab(int goldChange)
    {
        GameObject newHpObj = Instantiate(GoldLossPrefab, GoldObject.transform);
        Vector3 pos = newHpObj.GetComponent<RectTransform>().position;
        pos.y -=80;
        pos.x += 50;
        newHpObj.GetComponent<RectTransform>().position = pos;
        newHpObj.GetComponent<HealthLossUIScript>().SetHealthLossText(goldChange);

    }


}
