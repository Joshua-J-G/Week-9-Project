using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ISpawnable : MonoBehaviour
{
    
    public Texture2D EnemyFaceTexture;

    public string Name;

    public int spawnWeight;

    public bool isabletospawn = true;

    public bool completlydisable = false;

    //public virtual Texture2D EnemyImage()
    //{

    //}
    public void Start()
    {
        isabletospawn=true; 
    }

    public IEnumerator Timer()
    {
        Debug.Log("Spawning Enemy");
        isabletospawn = false;
        yield return new WaitForSeconds(Random.Range(1* spawnWeight, 30/ spawnWeight));
        isabletospawn = true;
        Debug.Log("Spawning Enemy");
    }

    public void OnDestroy()
    {
        isabletospawn = true;
        StopAllCoroutines();
    }

}
