using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTouch : MonoBehaviour
{
    public List<TouchLocation> touches = new List<TouchLocation>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int i = 0;
        
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("Touch began");
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch ended");
            }

            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("tocuhes moved");
            }
            ++i;
        }
    }
}
