using UnityEngine;

public class ShootMagic : MonoBehaviour
{
    public float range = 50f;
    public Camera myCamera;

    [SerializeField] private GameObject magia;

    [SerializeField] private AudioClip magicSound;
    [SerializeField] private AudioSource audiosource;

    private void Start()
    {
        audiosource = FindObjectOfType<MagicSwitching>().GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
            audiosource.PlayOneShot(audiosource.clip);
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
            if ((slimes != null) && (slimes.CompareTag("SliGalinha")) && (magia.CompareTag("Stun")))
            {
                slimes.Stun();
                Debug.Log("toquei!");
            }
            if ((slimes != null) && (slimes.CompareTag("SliGalinha")) && (magia.CompareTag("Charm")))
            {
                slimes.Charmed();
                Debug.Log("toquei!");
            }

            //FOCA
            if ((slimes != null) && (slimes.CompareTag("SliFoca")) && (magia.CompareTag("Sound")))
                {
                slimes.Sound();
                Debug.Log("toquei!");
            }
            if ((slimes != null) && (slimes.CompareTag("SliFoca")) && (magia.CompareTag("Charm")))
            {
                slimes.Charmed();
                Debug.Log("toquei!");
            }

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
            if ((slimes != null) && (slimes.CompareTag("SliPesadelo")) && (magia.CompareTag("Purify")))
            {
                slimes.Purify();
                Debug.Log("toquei!");
            }

            //Fazer com tags(os slimes têm diferentes tags)
            //Cada magia tem uma script
        }
    }
}
