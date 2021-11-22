using System.Collections.Generic;
using UnityEngine;

public class barrierScript : MonoBehaviour
{
    //Список преград на уровне
    public List<GameObject> bList;
    public GameObject barrierPrefab;
    public GameObject wall;
    public float moveSpeed = 2.0f;

    //Переменная для создания расстояния между преградами
    private bool bga = true;
    private int numOfBarriers = 0;
    private int randomRange;

    void OnEnable()
    {
        bga = true;
        bList = new List<GameObject>();
        randomRange = Random.Range(1,16);
    }

    void OnDisable() {
        foreach(GameObject gTemp in bList){
            Destroy(gTemp);
        }
    }

    void FixedUpdate()
    {
        List<GameObject> destroyList = new List<GameObject>();
        //Создаем преграду через рандомное кол-во блоков
        if(Mathf.RoundToInt(wall.transform.position.x) == randomRange * -1 && bga){
            createBarrier();
            bga = false;
        }
        //Двигаем преграды
        foreach(GameObject gTemp in bList){
            gTemp.transform.position = gTemp.transform.position + new Vector3(moveSpeed * Time.deltaTime * -1, 0, 0);
            if(gTemp.transform.position.x <= -10.5f){
                destroyList.Add(gTemp);
            }
        }

        if(bList.Count > 0){
            if(bList[bList.Count-1].transform.position.x <= 7f){
                bga = true;
            }
        }
        
        //Удаляем лишние преграды
        foreach(GameObject gTemp in destroyList){
            bList.Remove(gTemp);
            Destroy(gTemp);
        }
    }

    //Создание преград
    private void createBarrier(){

        randomRange = Random.Range(1,16);

        GameObject gObj = Instantiate<GameObject>(barrierPrefab);
        gObj.transform.position = new Vector3(11f,Random.Range(-2.5f,2.6f),0);
        gObj.name = $"Barrier {numOfBarriers}";
        numOfBarriers++;
        bList.Add(gObj);

        Debug.Log("Barrier created!");
    }
}
