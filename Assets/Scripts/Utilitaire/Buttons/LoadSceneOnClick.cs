using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {

    [SerializeField]
    private string sceneName;
    private Ray ray;
    RaycastHit[] hits;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray, 100);

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[i].transform == gameObject.transform)
            {
                if(Input.GetKeyUp(KeyCode.Mouse0))
                    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    //just for test 
                    //SceneManager.LoadSceneAsync("Yohan");
                }
            }
        }


    }
}
