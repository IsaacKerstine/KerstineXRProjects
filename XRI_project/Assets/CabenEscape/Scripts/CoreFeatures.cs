using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeatureUsage
{
    Once,
    Toggle
}

public class CoreFeatures : MonoBehaviour
{
    /*
     * We need a common way to access this code outside of this class
     * Create a Property value - "Encapsulation"
     * Properties have acessors to basically define the properties
     * Get Accessor (read) return encapsulated variable
     * Set Accessor (Write) allocates new values new valuse to felds
     */

    public bool AudioSFXSourceCreated {  get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audioSource;

    public FeatureUsage featureUsage = FeatureUsage.Once;

    protected virtual void Awake()
    {
        MakeAudioSFXSource();
    }

    private void MakeAudioSFXSource()
    {
        audioSource = GetComponent<AudioSource>();

        //if this is equal to null, create it right here

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        //Regardless of null or not, we still need to make sure this true on awake
        AudioSFXSourceCreated = true;
    }

    protected void PlayOnStart()
    {
        if (AudioSFXSourceCreated && AudioClipOnStart != null)
        {
            audioSource.clip = AudioClipOnStart;
            audioSource.Play();
        }
    }

    protected void PlayOnEnd()
    {
        if (AudioSFXSourceCreated && AudioClipOnEnd != null)
        {
            audioSource.clip = AudioClipOnEnd;
            audioSource.Play();
        }
    }
}
