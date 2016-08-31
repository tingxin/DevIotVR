using UnityEngine;
using System.Collections;
using System.Net;
using DevIotResource;
using Newtonsoft.Json;
using System;

public class DevIotManager : MonoBehaviour {

	// Use this for initialization

	public string ServerAddress = "10.140.92.25:9000";

	bool isLoadingConfig = false;
	bool thingsLoaded = false;

	WorkSpace workspace;

	string testData = "{\"things\":{\"devices\":[{\"id\":\"MQ2\",\"name\":\"Gas & Smoke-01\",\"kind\":\"gas\",\"gateway\":\"GatewayTools-mock\",\"description\":\"\",\"icon\":\"/images/icons/MQ2.png\",\"active\":true,\"properties\":[{\"name\":\"value\",\"type\":0.0,\"required\":false,\"value\":300.0,\"description\":\"getValue\"}],\"actions\":[],\"settings\":[{\"name\":\"Base\",\"type\":0.0,\"description\":\"setBase\"},{\"name\":\"Step\",\"type\":0.0,\"description\":\"setStep\"}],\"location\":{\"latitude\":40.7324,\"longitude\":-73.8248079}}]}}";
	string testDevice="{\"id\":\"MQ2\",\"name\":\"Gas & Smoke-01\",\"kind\":\"gas\",\"gateway\":\"GatewayTools-mock\",\"description\":\"\",\"icon\":\"/images/icons/MQ2.png\",\"active\":true,\"properties\":[{\"name\":\"value\",\"type\":0.0,\"required\":false,\"value\":300.0,\"description\":\"getValue\"}],\"actions\":[],\"settings\":[{\"name\":\"Base\",\"type\":0.0,\"description\":\"setBase\"},{\"name\":\"Step\",\"type\":0.0,\"description\":\"setStep\"}],\"location\":{\"latitude\":40.7324,\"longitude\":-73.8248079}}";
	string testProperty="{\"name\":\"value\",\"type\":0.0,\"required\":false,\"value\":300.0,\"description\":\"getValue\"}";
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
		GetThingsConfig ();

		LoadThings ();
	}

	void GetThingsConfig(){
		if (isLoadingConfig == false) {
			isLoadingConfig = true;
			WebClient client = new WebClient ();
			client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => {
				if (e.Error == null) {
					print (e.Result);

					try{
						
						this.workspace = JsonConvert.DeserializeObject<WorkSpace>(e.Result);
						thingsLoaded = true;
					}
					catch(Exception ex){
						print("Json format error: when format the WorkSpace data" +ex.Message);
						thingsLoaded = false;
					}
						
				} else {
					isLoadingConfig = false;
					print(e.Error.Message);
				}
			};
			string requestApi = string.Format ("http://{0}/api/v2/registries", ServerAddress);
			client.DownloadStringAsync (new System.Uri(requestApi));
		}

	}

	void LoadThings(){
		if (thingsLoaded) {
			print (this.workspace.things.devices.Count.ToString());
			if (this.workspace.things.devices.Count > 0) {
				for (int i = 0; i < this.workspace.things.devices.Count; i++) {
					Device device = this.workspace.things.devices [i];

				}
			}
		}
	}
}
