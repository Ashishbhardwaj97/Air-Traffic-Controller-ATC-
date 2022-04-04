using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	public AudioSource gameSounds ,  bgSounds , allLoopSounds;
	public AudioClip bgMusic , buttonSound , tileSlideSound , eatingSound , mouseRunning , levelCompeteSound , pathCompleteSound;

    public List<GameObject> peopleSoundsList;
    // Use this for initialization
    void Awake () {

		instance = this;

	}
		
	// Update is called once per frame
	void Update () {

	}

	public void PlaySound (AudioClip clip , float volume) {

		gameSounds.PlayOneShot (clip , volume);
		//print ("sound");
	}

	public void PlayBgSound (AudioClip clip) {

		bgSounds.clip = clip;
		bgSounds.Play ();
	}

	public void AllLoopSounds (AudioClip clip) {

		allLoopSounds.Stop ();
		allLoopSounds.clip = clip;
		allLoopSounds.Play();

	}


    public void PlayATCSound(List<AudioClip> _clipList, AudioSource _audioSource)
    {
        StartCoroutine(PlayATCSoundCoroutine(_clipList, _audioSource));
    }

    IEnumerator PlayATCSoundCoroutine(List<AudioClip> _clipList, AudioSource _audioSource)
    {

        yield return new WaitForSeconds(.3f);
        for (int i = 0; i <= _clipList.Count - 1; i++)
        {
            if (_clipList[i] != null)
            {
                _audioSource.clip = _clipList[i];
                _audioSource.Play();
                yield return new WaitForSeconds(_audioSource.clip.length);
            }
            
        }
        _clipList.Clear();
    }

    public void SetPlaneAudioSource(List<GameObject> _planeList, int _planeNo)
    {
        for (int i = 0; i < _planeList.Count; i++)
        {
            _planeList[i].GetComponent<AudioSource>().volume = .1f;
        }
        _planeList[_planeNo].GetComponent<AudioSource>().volume = SaveAndLoad.atcVol;

        if (SaveAndLoad.atcVol == 0)
        {
            for (int i = 0; i < _planeList.Count; i++)
            {
                _planeList[i].GetComponent<AudioSource>().volume = 0f;
            }
        }
       
    }

    //...........flap Sound etc..............//
    public void SetPlaneOtherAudioSource(List<GameObject> _planeList, int _planeNo)
    {
        for (int i = 0; i < _planeList.Count; i++)
        {
            _planeList[i].transform.GetChild(0).GetComponent<AudioSource>().volume = .01f;
        }
        _planeList[_planeNo].transform.GetChild(0).GetComponent<AudioSource>().volume = SaveAndLoad.ingameVol / 10;

        if (SaveAndLoad.atcVol == 0)
        {
            for (int i = 0; i < _planeList.Count; i++)
            {
                _planeList[i].GetComponent<AudioSource>().volume = 0f;
            }
        }
    }

    public void SetPlaneOtherAudioSource1(List<GameObject> _planeList, int _planeNo)
    {
        //print(_planeList.Count);
        for (int i = 0; i < _planeList.Count; i++)
        {
            //print(i);
            _planeList[i].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<AudioSource>().volume = 0f;
        }
        _planeList[_planeNo].transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<AudioSource>().volume = SaveAndLoad.ingameVol;
    }
}

