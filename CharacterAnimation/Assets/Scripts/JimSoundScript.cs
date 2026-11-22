using UnityEngine;

public class JimSoundScript : MonoBehaviour
{
    public AudioSource jumpSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        jumpSource.Play();
    }
}
