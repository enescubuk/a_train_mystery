using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgrounAnim : MonoBehaviour
{
    public GameObject objectPrefab;
    public int speed = 7;
    void Start()
    {
        // Sürekli olarak obje oluştur
        InvokeRepeating("CreateObject", 0, 2);
    }
    
    void Update()
    {
        // Obje'nin x pozisyonunu sürekli olarak azalt
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

        // Obje ekrandan çıktıysa sil
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
    
    void CreateObject()
    {
        // Obje prefabının bir kopyasını oluştur ve ekranın sağından başlat
        GameObject obj = Instantiate(objectPrefab, new Vector3(10, 0, 0), Quaternion.identity);

        obj.GetComponent<BackgrounAnim>().ChangeScale(1.333313f, 1.333313f, 1.333313f);


    }
    
    void ChangeScale(float scalex, float scaley, float scalez)
    {
        // Obje'nin ölçeğini değiştir
        objectPrefab.transform.localScale = new Vector3(scalex, scaley, scalez);
    }

}
