using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class SpawnLightning : MonoBehaviour
{
    public static float ölenKöylü =0f;
    public GameObject Lightning;
    public GameObject uyarı;
    public AudioSource lightingSound;
    private bool uyarıControl;
    private float yıldırımDöngü = 0f;
    //private float yıldırımİvmesi = 0.2f;
    //private float yıldırımHızı = 0f;
    private float yıldırımZamanı = 3f;

    private void Start()
    {
        ölenKöylü = 0;
    }


    void Update()
    {
        yıldırımDöngü += Time.deltaTime;

        if (yıldırımDöngü >= yıldırımZamanı)
        {
            StartCoroutine(spawnLightning());
            if (yıldırımZamanı>0.4f)
            { 
                yıldırımZamanı = yıldırımZamanı - (yıldırımZamanı /50);
            }
            yıldırımDöngü = 0f;
        }
        /*
        timeLeft -= 1;
        if (timeLeft % 1000 == 0)
        {
            StartCoroutine(spawnLightning());
        }
        */
    }
    public IEnumerator spawnLightning()
    {
        Vector3 position = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-7.0f, 7.0f), 0);
        var clone = Instantiate(Lightning, position, Quaternion.identity);
        clone.SetActive(false);
        var uyarıClone = Instantiate(uyarı, clone.transform.position, Quaternion.identity);
        uyarıControl = true;
        Object.Destroy(uyarıClone, 3.0f);
        yield return new WaitForSeconds(3);
        uyarıControl = false;
        if(uyarıControl == false)
        {
            lightingSound.Play();
            clone.SetActive(true);
        }
        Object.Destroy(clone, 0.2f);
    }
}
