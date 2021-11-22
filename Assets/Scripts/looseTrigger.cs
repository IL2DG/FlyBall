using UnityEngine;

public class looseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Ball"){
            gameController.use.gC.SetActive(false);
            gameController.use.wC.SetActive(false);
            gameController.use.gUI.SetActive(false);
            gameController.use.rUI.SetActive(true);
        }
    }
}
