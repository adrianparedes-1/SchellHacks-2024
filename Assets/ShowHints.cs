using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHints : MonoBehaviour
{
    public GameObject uiElement; // Assign your UI GameObject in the Inspector

	void Update()
	{
	    if (Input.GetKey(KeyCode.Tab))
	    {
		ShowUI();
	    }
	    else
	    {
		HideUI();
	    }
	}


	void ShowUI()
	{
		if (uiElement != null)
		{
		    uiElement.SetActive(true);
		}
	}

	void HideUI()
	{
		if (uiElement != null)
		{
		    uiElement.SetActive(false);
		}
	}
}

