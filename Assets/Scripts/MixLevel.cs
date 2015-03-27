using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MixLevel : MonoBehaviour {
	public AudioMixer MasterMixer;
	public void SetSfxLevel(float sfxLvl){
		MasterMixer.SetFloat ("sfxVol", sfxLvl);

	} 

	public void SetMusicLevel(float MusicLvl){
		MasterMixer.SetFloat ("musicVol", MusicLvl);
	} 
}
