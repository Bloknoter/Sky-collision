using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplanesDatabase : MonoBehaviour
{
    [SerializeField]
    private Airplane[] m_airplanes;

    [SerializeField]
    private Airplane[] m_redAirplanes;

    [SerializeField]
    private Airplane[] m_blueAirplanes;

    public int AirplanesCount => m_airplanes.Length;
    public int RedAirplanesCount => m_redAirplanes.Length;
    public int BlueAirplanesCount => m_blueAirplanes.Length;

    public Airplane AirplaneAt(int index) => m_airplanes[index];
    public Airplane RedAirplaneAt(int index) => m_redAirplanes[index];
    public Airplane BlueAirplaneAt(int index) => m_blueAirplanes[index];
}
