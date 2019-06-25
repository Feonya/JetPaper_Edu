using UnityEngine;

public class CaputureChecker : MonoBehaviour
{
    private EvilCat evilCat;
    private Animator evilCatAnimator;
    private YellowCat yellowCat;
    private Animator yellowCatAnimator;
    private BlackCat blackCat;
    private Animator blackCatAnimator;
    private PurpleCat purpleCat;
    private Animator purpleCatAnimator;

    private void Start()
    {
        evilCat = GameObject.Find("EvilCat").GetComponent<EvilCat>();
        evilCatAnimator = evilCat.GetComponent<Animator>();
        yellowCat = GameObject.Find("YellowCat").GetComponent<YellowCat>();
        yellowCatAnimator = yellowCat.GetComponent<Animator>();
        blackCat = GameObject.Find("BlackCat").GetComponent<BlackCat>();
        blackCatAnimator = blackCat.GetComponent<Animator>();
        purpleCat = GameObject.Find("PurpleCat").GetComponent<PurpleCat>();
        purpleCatAnimator = purpleCat.GetComponent<Animator>();
    }

    public void CheckCaputure()
    {
        if (evilCat.caputured && !evilCatAnimator.GetBool("flying"))
        {
            Destroy(evilCat.gameObject);
        }
        else if (yellowCat.caputured && !yellowCatAnimator.GetBool("flying"))
        {
            Destroy(yellowCat.gameObject);
        }
        else if (blackCat.caputured && !blackCatAnimator.GetBool("flying"))
        {
            Destroy(blackCat.gameObject);
        }
        else if (purpleCat.caputured && !purpleCatAnimator.GetBool("flying"))
        {
            Destroy(purpleCat.gameObject);
        }
    }
}
