using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public ChemicalManager cm;
    
    string [] formula = { "HClO", "HCl", "HBr" };
    string [] name = { "hypochlorous acid", "hydrochloric acid", "hydrobromic acid" };
    
    public bool isOpen;
    public void OpenChest()
    {
        if (!isOpen){
            isOpen = true;
            int randomIndex = Random.Range(0, formula.Length - 1);
	    cm.RandomChemical(name[randomIndex], formula[randomIndex]);
        }
    }

}

