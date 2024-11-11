using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWalker : MonoBehaviour
{
    public Transform player; // Pelaajaobjekti
    public GameObject cube; // Kuutio, jolla pelaaja kävelee
    private Vector3 playerPos;
    private Vector3 cubeFacesDirection; // Suunta, johon kuution tahko osoittaa

    void Update()
    {
        Renderer rend = cube.GetComponent<Renderer>();
        Bounds bounds = rend.bounds;
        playerPos = player.transform.position;

        // Tarkista, onko pelaaja kuution reunalla
        if (IsPlayerAtEdge(player.position, bounds))
        {
            Debug.Log("Pelaaja on kuution reunalla");
            // Määritä suunta, johon kuution tahko osoittaa
            cubeFacesDirection = DetermineCubeFaceDirection();

            // Käännä kuutiota niin, että pelaaja siirtyy seuraavalle tahkolle
            RotateCubeToNextFace(cubeFacesDirection);
        }
    }

    bool IsPlayerAtEdge(Vector3 playerPos, Bounds bounds)
{
    // Tarkista, onko pelaajan x- tai z-koordinaatti kuution reunan sisällä
    bool isAtXEdge = Mathf.Approximately(playerPos.x, bounds.min.x) || Mathf.Approximately(playerPos.x, bounds.max.x);
    bool isAtZEdge = Mathf.Approximately(playerPos.z, bounds.min.z) || Mathf.Approximately(playerPos.z, bounds.max.z);
    
    // Jos pelaaja on jommankumman akselin reunalla, mutta ei y-akselin ylä- tai alapuolella
    return (isAtXEdge || isAtZEdge);
}

    Vector3 DetermineCubeFaceDirection()
    {
        
    Vector3 frontFaceDirection = cube.transform.forward; // Kuution etusivun suunta
    Vector3 backFaceDirection = -cube.transform.forward; // Kuution takasivun suunta
    Vector3 leftFaceDirection = -cube.transform.right; // Kuution vasemman sivun suunta
    Vector3 rightFaceDirection = cube.transform.right; // Kuution oikean sivun suunta
    Vector3 topFaceDirection = cube.transform.up; // Kuution yläsivun suunta
    Vector3 bottomFaceDirection = -cube.transform.up; // Kuution alasivun suunta
    Vector3 faceDirection = Vector3.up;

    float dotUp = Vector3.Dot(cube.transform.up, Vector3.up);
        if (dotUp > 0) 
        {
            Debug.Log("katsoo ylös");
            faceDirection = topFaceDirection;
        } else if (dotUp < 0) 
        {
            Debug.Log("katsoo alas");
            faceDirection = bottomFaceDirection;
        }

    float dotForward = Vector3.Dot(cube.transform.forward, Vector3.up);
        if (dotForward > 0) 
        {
            Debug.Log("katsoo eteen");
            faceDirection = frontFaceDirection;
        } else if (dotForward < 0) 
        {
            Debug.Log("katsoo taakse");
            faceDirection = backFaceDirection;
            // Kuution takasivu osoittaa ylöspäin
        }
    
    float dotSide = Vector3.Dot(cube.transform.right, Vector3.up);
        if (dotForward > 0) 
        {
            Debug.Log("katsoo oikee");
            faceDirection = rightFaceDirection;
            
        } else if (dotForward < 0) 
        {
            Debug.Log("katsoo vasen");
            faceDirection = leftFaceDirection;
            
        }
        
        // Toteuta logiikka, joka määrittää, mihin suuntaan kuution tahko osoittaa
        // Tämä voi perustua pelaajan sijaintiin suhteessa kuution keskipisteeseen
        return faceDirection;
    }

    void RotateCubeToNextFace(Vector3 faceDirection)
    {
        // Käännä kuutiota niin, että pelaaja siirtyy seuraavalle tahkolle
        // Voit käyttää esimerkiksi Quaternion.Lerp tai RotateAround-metodeja
        cube.transform.RotateAround(cube.transform.position, faceDirection, 90f);
    }
}
    