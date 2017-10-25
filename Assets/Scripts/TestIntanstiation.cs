using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// rename this class to suit your needs
public class TestIntanstiation : MonoBehaviour
{
    // the Equip prefab - required for instantiation
    public GameObject equipPrefab;
    
    // list that holds all created objects - deleate all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();

    bool active = true;

    public void CreateObject()
    {
        // a prefab is need to perform the instantiation
        if (equipPrefab != null & active == true) 
        {
            // get a random postion to instantiate the prefab - you can change this to be created at a fied point if desired
            Vector3 position = new Vector3 (-2.0f,1.5f,1.5f);
            

            Quaternion rotation = Quaternion.identity;
            rotation *= Quaternion.Euler(0, 230, 0);
            
            // instantiate the object
            GameObject go = (GameObject)Instantiate(equipPrefab, position, rotation);
			//Handheld.PlayFullScreenMovie ("videoplayback.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
            createdObjects.Add(go);
            active = false;
        }
        if (equipPrefab != null & active == false)
        {
            createdObjects.Clear();
            active = true;
        }
    }  
    
    
}
