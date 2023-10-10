
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthLossUIScript : MonoBehaviour
{
    public float TimeToFade = 1.5f;
    float Timer = 0;
    [SerializeField] Image HealthSprite;
    [SerializeField] TextMeshProUGUI HealthText;
    public float Step = 3f;

    void Start()
    {
        Timer = TimeToFade;



    }

    public void SetHealthLossText(int healthValue)
    {
        if (healthValue < 0)
        {
            HealthText.color = Color.red;
        }
        else if (healthValue > 0)
        {
            HealthText.color = Color.green;
        }
        HealthText.text = healthValue + "";
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        FadeSprite();
        FadeText();
        MoveObject();



        if (Timer <= 0)
        {
            Destroy(gameObject);
        }

    }
    void FadeSprite()
    {

        var tempColor = HealthSprite.color;
        tempColor.a = Timer / TimeToFade;
        HealthSprite.color = tempColor;
    }
    void FadeText()
    {
        var tempColor = HealthText.color;
        tempColor.a = Timer / TimeToFade;
        HealthText.color = tempColor;
    }

    void MoveObject()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 pos = rt.anchoredPosition;
        pos.y = pos.y + (Step * Time.deltaTime);
        rt.anchoredPosition = pos;

    }
}
