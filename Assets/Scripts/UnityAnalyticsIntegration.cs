using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;
public class UnityAnalyticsIntegration : MonoBehaviour {
	void Start () {
		const string projectId = "44e4f3d7-03b4-41da-aeca-225cf0cb4181";
		UnityAnalytics.StartSDK (projectId);
	}
}