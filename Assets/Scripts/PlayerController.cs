using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quello di cui avremo bisogno: movimento laterale, frontale, non uscire dal max di z e x(< e >)
//E poi la possibilità di "aggredire" il CEO

public class PlayerController : MonoBehaviour
{
    [Header("Parametri")]
    public float xLimit;
    public float speed = 2f;
    [Header("Oggetti")]
    
    [Header("Assets Audio")]
    private AudioSource playerAudio;
    public AudioClip barks;
    public AudioClip growl;

    [Header ("Stato player")]
    public float health = 10.0f;
    public float humanHealthPlus = 10.0f;
    public float childHealthMinus = 10.0f;

    //Variabili private
    private Rigidbody playerRb;
   

    // Start is called before the first frame update
    void Start()
    {
        //Attivazione dei vari componenti
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
        ConstrainPlayerPosition();
        Actions();

    }


    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        playerRb.AddForce(Vector3.forward * speed * verticalInput);


    }


    private void OnCollisionEnter(Collision collision)
    {
        //CONTATTI CON NPC//

        //Contatto col CEO: vengo distrutto
        if(collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Sei stato toccato dal CEO");
            Destroy(gameObject);

        }

        //Contatto col gatto: randomicamente prendo o perdo punti con un valore random
        if(collision.gameObject.CompareTag("Cat"))
        {

            Debug.Log("Hai colpito il gatto");

        }
        
        //Contatto con umano: guadagno salute
        if(collision.gameObject.CompareTag("Human"))
        {

            health = health + humanHealthPlus;
            Debug.Log("Hai colpito un umano, hai guadagnato " + humanHealthPlus + "punti salute");

        }

        //Contatto con un bambino: perdo salute
        if(collision.gameObject.CompareTag("Child"))
        {

            health = health - childHealthMinus;
            Debug.Log("Hai colpito un bambino, hai perso " + childHealthMinus + "punti salute");

        }

        //Distruggo gli altri powerup
        if(collision.gameObject.CompareTag("Powerup"))
        {

            Destroy(collision.gameObject);
            Debug.Log("Hai preso un powerup");


        }

    }


    private void OnTriggerEnter(Collider other)
    {




    }


    void Actions()
    {

        //Space = bark
        //bark = abbaio per tenere lontani i bambini
        //se barko sugli umani: non posso toccarli per qualche secondo
        //se barko contro i CEO: mi inseguono?
        //se i bimbi mi toccano -> perdo punti
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAudio.PlayOneShot(barks, 1.0f);
        }

        //growl = mi lancio contro i CEO
        //se i CEO mi toccano -> muoio
        //se aggredisco gli umani: perdo punti
        //se aggredisco i bambini: gli umani diventano CEO per qualche secondo (o comunque qualcosa di aggressivo)
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAudio.PlayOneShot(growl, 1.0f);
        }


    }

    void ConstrainPlayerPosition()
    {
        //Formuline per fare in modo che se il personaggio si trova agli estremi dell'asse x, non possa superarli
        if(transform.position.x < - xLimit)
        {
            transform.position = new Vector3(- xLimit, transform.position.y, transform.position.z);
        }

        if(transform.position.x >  xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
    }
}

