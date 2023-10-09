
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastTest : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler
{
    public void OnPointerClick(PointerEventData eventData){
        
        if(gameObject.layer != LayerMask.NameToLayer("Range")){
            Debug.Log("Clicked Object" + gameObject.name);
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
       
    }

}
