using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject fadePanel;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fadePanel = GameObject.Find("FadePanel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(EndState());
        }
    }

    IEnumerator EndState()
    {
        anim.SetTrigger("Activate");
        yield return new WaitForSeconds(2f);
        fadePanel.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
