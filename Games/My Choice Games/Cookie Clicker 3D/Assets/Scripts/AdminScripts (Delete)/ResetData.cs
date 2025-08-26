using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    int presscount = 0;
    // Function that can be called to reset the save data
    public void ResetSaveData()
    {
        presscount++;
        if (presscount >= 5){
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save(); // Ensure the deletion is committed
            Debug.Log("All PlayerPrefs data has been deleted.");
        }
        
    }
}
