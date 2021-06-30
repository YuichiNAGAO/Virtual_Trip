using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TestCompass : MonoBehaviour
{
    void Start()
    {
        Input.compass.enabled = true;
		Input.location.Start();
    }
 
    void OnGUI ()
    {
    	var sb = new System.Text.StringBuilder();
    	sb.Append( "Enabled        :").AppendLine( Input.compass.enabled.ToString() );
    	sb.Append( "headingAccuracy:").AppendLine( Input.compass.headingAccuracy.ToString() );
    	sb.Append( "magneticHeading:").AppendLine( Input.compass.magneticHeading.ToString() );
    	sb.Append( "rawVector      :").AppendLine( Input.compass.rawVector.ToString() );
    	sb.Append( "timestamp      :").AppendLine( Input.compass.timestamp.ToString() );
    	sb.Append( "trueHeading    :").AppendLine( Input.compass.trueHeading.ToString() );
        sb.Append( "deviceLocation.latitude    :").AppendLine( Input.compass.trueHeading.ToString() );
    	GUI.Label( new Rect( 10, 10, 256, 256 ), sb.ToString() );
    }
}
