using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using Unity.Burst;

[BurstCompile]
public class SetAudioVolume : MonoBehaviour 
{
	[SerializeField]
	private AudioMixer masterMixer;

	public void SetSfxLvl(float sfxLvl)
	{
		masterMixer.SetFloat("sfxVol", sfxLvl);
	}

	public void SetMusicLvl (float musicLvl)
	{
		masterMixer.SetFloat("musicVol", musicLvl);
	}
}
