using UnityEngine.UI;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController use;
    [Header("Игровые компоненты")]
    //Игровой контроллер
    public GameObject gC;
    //Стены
    public GameObject wC;
    public GameObject textObj;
    [Header("Интерфейс")]
    //Игровой UI
    public GameObject gUI;
    //Стартовый UI
    public GameObject sUI;
    //Рестарт UI
    public GameObject rUI;

    private Text tryText;
    private void Awake() {
        use = this;

        MainMenu();
    }   
    public void Play(){
        PlayerPrefs.SetInt("NumOfTry",PlayerPrefs.GetInt("NumOfTry") + 1);
        sUI.SetActive(false);
        rUI.SetActive(false);
        gUI.SetActive(true);
        gC.SetActive(true);
        wC.SetActive(true);
    }

    public void MainMenu(){
        sUI.SetActive(true);
        rUI.SetActive(false);
        gUI.SetActive(false);
        gC.SetActive(false);
        wC.SetActive(false);
    }

    private void OnDisable() {
        tryText = textObj.GetComponent<Text>();
        tryText.text = $"Всего попыток - {PlayerPrefs.GetInt("NumOfTry")}";
    }
}
