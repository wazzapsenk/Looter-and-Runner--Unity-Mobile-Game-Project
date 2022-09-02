using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerEffects : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    public Animator myAnimator;

    public GameObject winEffect;
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject point;
    public GameObject spawn;
    public GameObject parent;
    public GameObject[] clones;

    public Text pointText;

    public static int counter;

    private void Start()
    {
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Points")
        {
            counter++;
            clones[counter] = Instantiate(spawn, point.transform.position, point.transform.rotation, parent.transform);
            point.transform.Translate(0, .75f, 0);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag=="Obstacle")
        {
            BaseObstacle baseObstacle = other.GetComponent<BaseObstacle>();

            if (baseObstacle.killType == KillType.All)
            {
                if (counter == 0)
                {
                    Debug.Log("FAIL SCREEN");
                    loseScreen.SetActive(true);
                    InputController.isMoving = false;
                    myAnimator.SetTrigger("finish");
                }
                if (counter!=0)
                {
                    Destroy(other.gameObject);
                    for (int i = 0; i < clones.Length; i++)
                    {
                        Destroy(clones[i]);
                        counter = 0;
                        point.transform.localPosition = new Vector3(-0.014f, 0.107f, 0.063f);
                    }

                }
                
            }
            else if(baseObstacle.killType == KillType.One)
            {
                if (counter == 0)
                {
                    Debug.Log("FAIL SCREEN");
                    loseScreen.SetActive(true);
                    InputController.isMoving = false;
                    myAnimator.SetTrigger("finish");
                }
                if (counter!=0)
                {
                    counter--;
                    Destroy(other.gameObject);
                    Destroy(clones[counter +1]);
                    point.transform.Translate(0, -.75f, 0);
                }

                
            }
            if (baseObstacle.killType == KillType.Wall)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
                //GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        if (other.gameObject.tag=="Finish")
        {
            if (counter>0)
            {
                Debug.Log("particle");
                winEffect.SetActive(true);
                winScreen.SetActive(true);
            }
            else if (counter <= 0)
            {
                InputController.isMoving = false;
                loseScreen.SetActive(true);
                myAnimator.SetTrigger("finish");
            }
        }

        if (other.gameObject.tag=="Real Finish")
        {
            winScreen.SetActive(true);
            pointText.enabled = true;
            InputController.isMoving = false;
            myAnimator.SetTrigger("finish");
        }
    }
}
