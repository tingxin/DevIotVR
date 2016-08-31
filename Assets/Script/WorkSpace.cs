using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DevIotResource{

	public class WorkSpace {

		public Things things;
	}


	public class Things{
		public List<Device> devices;
	}

	public class Tools{
		//TODO:
	}

	public class Device{
		public string id;
		public string name;
		public string kind;
		public string gateway;
		public string description;
		public string icon;
		public bool active;

		public List<Property> properties;
		public List<Setting> settings;
		public List<Action> actions;

		public Location location;
	}


	public class Property{
		public string name;
		public double type;
		public bool required;
		public object value;
		public string description;
	}

	public class Flog{

		public string name;
		public string kind;
		public bool enabled;
		public string link;
		public string description;
		public string connector;
		public string icon;
	}

	public class Tool{
		//TODO:
	}

	public class Setting{

		public string name;
		public string description;
		public float type;

	}

	public class Action{

		public string name;
		public string description;
		public string id;

		public List<Parameter> parameters;
	}

	public class Parameter{
		public string id;
		public string name;
		public double type;
		public bool required;
		public object value;
		public string description;
	}

	public class Location{
		public double latitude;
		public double longitude;
	}
}
