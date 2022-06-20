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
            
            SlimeTarget slimes = hit.transform.GetComponent<SlimeTarget>();

            //AZUL
            if ((slimes != null) && (slimes.CompareTag("SliAzul")) && (magia.CompareTag("Charm")))
            {
                slimes.Charmed();
                Debug.Log("toquei!");
            }

            //GALINHA


            //FOCA


            //FLOR


            //BORBOLETA

            //PIRATA
            if ((slimes != null) && (slimes.CompareTag("Pirata")) && (magia.CompareTag("Stun")))
            {
                slimes.Stun();
                Debug.Log("toquei!");
            }
            if ((slimes != null) && (slimes.CompareTag("Pirata")) && (magia.CompareTag("Charm")))
            {
                slimes.Charmed();
                Debug.Log("toquei!");
            }

            //PESADELO

            //Fazer com tags(os slimes têm diferentes tags)
            //Cada magia tem uma script
        }
    }
}
