using UnityEngine;

public class ShootMagic : MonoBehaviour
{
    public float range = 50f;
    public Camera myCamera;

    [SerializeField] private GameObject magia;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            SlimeAzul sAzul = hit.transform.GetComponent<SlimeAzul>();
            if (sAzul != null)
            {
                sAzul.Charmed();
            }
            
            SlimeTarget slimes = hit.transform.GetComponent<SlimeTarget>();
            if((slimes != null) && (slimes.CompareTag("Pirata")) && (magia.CompareTag("Stun")))
            {
                slimes.Stun();
                Debug.Log("toquei!");
            }


            //Fazer com tags(os slimes têm diferentes tags)
            //Cada magia tem uma script
        }
    }
}
