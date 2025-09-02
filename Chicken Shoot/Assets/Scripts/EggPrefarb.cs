using System.Collections;
using UnityEngine;

public class eggPrefarb : MonoBehaviour
{
    public GameObject Egg;
    void Start()
    {
        StartCoroutine(eggDrop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator eggDrop()
    {
        while (true)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            var egg = Instantiate(Egg, transform.position, rotation);
            yield return new WaitForSeconds(2f);
        }
    }    
}
