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


    public void CreateObject()
    {
        // a prefab is need to perform the instantiation
        if (equipPrefab != null)
        {
            // get a random postion to instantiate the prefab - you can change this to be created at a fied point if desired
            Vector3 position = transform.position;
            
            position.x += 1;
            position.z -= 1;
            Quaternion rotation = Quaternion.identity;
            rotation.y += 250;
            rotation.x -= 10;

            // instantiate the object
            GameObject go = (GameObject)Instantiate(equipPrefab, position, rotation);
			Handheld.PlayFullScreenMovie ("videoplayback.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
            createdObjects.Add(go);
        }
    }    
}
