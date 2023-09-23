using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.UI.GridLayoutGroup;

public class Projectile : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    private void Start()
    {
        source = GameManager.instance.sfxSource;
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        source.PlayOneShot(clip);
    }
}
