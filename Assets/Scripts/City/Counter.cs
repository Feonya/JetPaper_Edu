using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text countDownText;
    private Rigidbody2D playerBody;
    private PlayerController playerController;
    private Rigidbody2D planeBody;
    private GameObject countDownSounds;
    private AudioSource countSound;
    private AudioSource goSound;

    private void Start()
    {
        countDownText = GetComponent<Text>();
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerController = playerBody.GetComponent<PlayerController>();
        planeBody = GameObject.FindGameObjectWithTag("Plane").GetComponent<Rigidbody2D>();
        countDownSounds = GameObject.Find("CountDownSounds");
        countSound = countDownSounds.transform.GetChild(0).GetComponent<AudioSource>();
        goSound = countDownSounds.transform.GetChild(1).GetComponent<AudioSource>();

        StartCoroutine(CountDown());
    }

    private void FixedUpdate()
    {
        CheckPlaneSimulation();
    }

    private void CheckPlaneSimulation()
    {
        if (!playerController.canControl)
        {
            planeBody.simulated = false;
        }
        else
        {
            planeBody.simulated = true;
        }
    }

    private IEnumerator CountDown()
    {
        countSound.Play();

        yield return new WaitForSeconds(1.0f);

        countSound.Play();
        countDownText.text = "2";

        yield return new WaitForSeconds(1.0f);

        countSound.Play();
        countDownText.text = "1";

        yield return new WaitForSeconds(1.0f);

        goSound.Play();
        countDownText.text = "GO";
        playerController.canControl = true;

        yield return new WaitForSeconds(1.0f);

        Destroy(countDownSounds);
        Destroy(gameObject);
    }
}
