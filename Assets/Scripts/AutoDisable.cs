using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    StartCoroutine(WaitScreen());
    }
    
	IEnumerator WaitScreen()
	{
		yield return new WaitForSeconds(0.5f);
		this.gameObject.SetActive(false);
	}
}
