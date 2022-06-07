using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

 public class UIButtonAddon : MonoBehaviour, ISelectHandler , IPointerEnterHandler
 {
 	public UIManager UM;
 	Image ownSprite;
 	public List<Image> others;
 	
 	void Start()
 	{
 		ownSprite = this.GetComponent<Image>();
 	}
 	

	 public void OnPointerEnter(PointerEventData eventData)
	 {
	 	UM.HighLightOne();
		 ownSprite.enabled = true;
		 others[0].enabled = false;
		 others[1].enabled = false;
	 }
	 
	 
	 // When selected.
	 public void OnSelect(BaseEventData eventData)
	 {
		 // Do something.
		 Debug.Log("<color=red>Event:</color> Completed selection.");
	 }
	 
	 public void OnPointerExit(PointerEventData eventData)
	 {
	 	Debug.Log("pitard");
	 }
}
