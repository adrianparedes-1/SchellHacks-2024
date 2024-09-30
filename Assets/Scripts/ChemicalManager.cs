using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChemicalManager : MonoBehaviour
{
	public static ChemicalManager instance;

	public List<string> chemicals = new List<string>();
	private StringBuilder b = new StringBuilder();
	
	[SerializeField] private TMP_Text chemDisplay;
	[SerializeField] private TMP_Text nameDisplay;
	
	private string acidName;
	private string acidForm;

	private void Awake()
	{
		if (!instance)
		{
		    instance = this;
		}
	}

	private void Update()
	{
		nameDisplay.text = acidName;
		chemDisplay.text = b.ToString(); // Update display text with concatenated string
		//CheckFormula(b.ToString());
	}

	public void AddChemical(string chemical)
	{
		b.Append(chemical); // Append the new chemical
		Debug.Log(b.ToString()); // Log the current concatenated string
		CheckFormula(b.ToString());
		chemicals.Add(chemical); // Optionally keep the list if needed
	}

	public void RandomChemical(string name, string form)
	{
	    acidForm = form;
	    acidName = name;
	}
	
	public void CheckFormula(string chemical)
	{
	    Debug.Log(chemical);
	    Debug.Log(acidForm);

	    if (chemical.Equals(acidForm))
	    {
		winGame(true); // Exact match
	    }
	    else if (acidForm.StartsWith(chemical))
	    {
		// Still building the correct formula
		// Do nothing or provide feedback if needed
	    }
	    else
	    {
		winGame(false); // Incorrect input
	    }
	}

	
	public void winGame(bool win)
	{
		if(win)
		{
			SceneManager.LoadSceneAsync(2);
		}
		else
		{
			SceneManager.LoadSceneAsync(3);
		}
	}
}

