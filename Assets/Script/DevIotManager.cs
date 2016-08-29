using UnityEngine;
using System.Collections;
using System.Net;

public class DevIotManager : MonoBehaviour {

	// Use this for initialization

	bool isLoadingConfig = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		GetThingsConfig ();
	}

	void GetThingsConfig(){
		if (isLoadingConfig == false) {
			isLoadingConfig = true;
			WebClient client = new WebClient ();
			client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => {
				if (e.Error == null) {
					print (e.Result);

				} else {
					isLoadingConfig = false;
				}
			};
			client.DownloadStringAsync (new System.Uri("http://www.baidu.com"));
		}

	}
}
