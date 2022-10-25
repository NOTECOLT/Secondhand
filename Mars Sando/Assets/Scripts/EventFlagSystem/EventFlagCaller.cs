using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFlagCaller : MonoBehaviour {
	// Couples with EventFlagManager. Sends EventFlag Information
	// Stolen from Help Me Find My Doll Code lmao
	
	public string flagName;

	public void CallEventFlag() {
		EventFlagManager.Instance.FlagTickTrue(flagName);
	}
}
