using UnityEngine;

public class moveWalls : MonoBehaviour
{
    [Header("Скорость")]
    public float moveSpeed = 2.0f;
    //Позиция границ
    private Vector3 pos{
        get { return transform.position;}
        set { transform.position = value;}
    }

    private void OnEnable() {
        transform.position = Vector3.zero;
    }
    void FixedUpdate(){
        transform.position = transform.position + new Vector3((moveSpeed * Time.deltaTime) * -1, 0, 0);
        if(transform.position.x <= -15){
            pos = Vector3.zero;
        }
    }
}
