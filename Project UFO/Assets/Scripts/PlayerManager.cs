using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private AudioSource hitImpactSFX;

    private void Start()
    {
        hitImpactSFX = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        hitImpactSFX.Play();
        gameObject.GetComponent<HoverController>().enabled = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
