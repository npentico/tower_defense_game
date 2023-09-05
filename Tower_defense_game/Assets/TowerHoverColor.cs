
using UnityEngine;

public class TowerHoverColor : MonoBehaviour
{
   
    void OnMouseOver(){
        Debug.Log("xdd");
        transform.parent.GetComponent<TowerScript>().ShowRangeIndicator();
    }

    void OnMouseExit(){
        transform.parent.GetComponent<TowerScript>().HideRangeIndicator();
    }
}
