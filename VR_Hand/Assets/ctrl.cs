using System;
using UnityEngine;
using System.IO.Ports;

public class ctrl : MonoBehaviour
{

	SerialPort stream = new SerialPort("COM12", 9600, Parity.None, 8, StopBits.One);
	void Start()
	{
		stream.Open();
	}
	void OnApplicationQuit()
	{
		stream.Close();
	}
	string tmp = null;
	void Update()
	{
		try
		{
			if (stream.IsOpen)
			{
				//Debug.Log(stream.ReadLine());
				tmp = stream.ReadLine();
				stream.ReadTimeout = 30;
				string[] result = tmp.Split(new char[] {','});  // ,를 기준으로 잘라서 배열 result 에 넣어라.
				for (int i = 0; i < result.Length; i++)  // 배열은 0 부터 저장되며, 배열의 길이만큼 순환
				{
					Debug.Log(i + ": " + result[i]);
				}
			}
			
		}
		catch (TimeoutException e)
		{
			//Debug.Log(e);
		}
	}
}