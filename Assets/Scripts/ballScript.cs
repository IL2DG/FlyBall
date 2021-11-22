using UnityEngine.UI;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    private bool buttonDown;
    private float ySpeed;
    public GameObject ball;
    GameObject gobj;
    Text txt;
    public GameObject txtObj;
    void OnEnable() {
        ySpeed = PlayerPrefs.GetFloat("Dificulty");
        gobj = Instantiate(ball,new Vector3(-7, 3, 0), Quaternion.identity);
        gobj.name = "Ball";
        Debug.Log(ySpeed);
        PointerUp();
    }
    void OnDisable() {
        Destroy(gobj);    
    }

    void FixedUpdate(){
        Rigidbody2D rb = gobj.GetComponent<Rigidbody2D>();
        if(buttonDown){
            rb.velocity = rb.velocity + new Vector2(0, ySpeed * Time.deltaTime);
        } else {
            rb.velocity = rb.velocity - new Vector2(0, ySpeed * Time.deltaTime);
        }   
        if(Time.fixedTime % 15 == 0){
            ySpeed++;
            Debug.Log("Speed Up!");
        }
    }
    public void PointerDown(){
        buttonDown = true;
    }
    public void PointerUp(){
        buttonDown = false;
    }

    public void EDif(){
        PlayerPrefs.SetFloat("Dificulty",2f);
        PlayerPrefs.SetString("DificultyText", "Легко");
        txt = txtObj.GetComponent<Text>();
        txt.text = PlayerPrefs.GetString("DificultyText");
    }
    public void MDif(){
        PlayerPrefs.SetFloat("Dificulty",4f);
        PlayerPrefs.SetString("DificultyText", "Средне");
        txt = txtObj.GetComponent<Text>();
        txt.text = PlayerPrefs.GetString("DificultyText");
    }
    public void HDif(){
        PlayerPrefs.SetFloat("Dificulty",8f);
        PlayerPrefs.SetString("DificultyText", "Трудно");
        txt = txtObj.GetComponent<Text>();
        txt.text = PlayerPrefs.GetString("DificultyText");
    }
}
