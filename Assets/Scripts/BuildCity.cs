using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour
{

    public  GameObject[]  buildings  ;
    public  GameObject  xStreets  ;
    public  GameObject  zStreets  ;
    public  GameObject  crossroad  ;
    public  int  mapWidth  =  10  ;
    public  int  mapHeight  =  10  ;
    public  int  buildingSpace  =  3  ;
    int  [  ,  ]   mapGrid  ;

    void Start()
    {

        mapGrid  =  new int  [  mapWidth  ,  mapHeight  ]  ;

        float  cityScapeSeed  =  Random.Range  (  0  ,  100  )  ;

        //map generation data
        for  (  int  mapH  =  0  ;  mapH  <  mapHeight  ;  mapH++  )
        {
            for  (  int  mapW  =  0  ;  mapW  <  mapWidth  ;  mapW++  )
            {
                mapGrid  [ mapW  , mapH  ]  =  (int)  (  Mathf.PerlinNoise  (  mapW  /  10.0f  +  cityScapeSeed  , mapH  /  10.0f  + cityScapeSeed  )  *  10  )  ;
            }
        }

        //build streets
        int  x  =  0;
        for  (int  n  =  0;  n  <  50;  n++)
        {
            for  (int  mapH  =  0;  mapH  <  mapHeight;  mapH++)
            {
                mapGrid  [x,  mapH]  =  -1;
            }
            x  +=  Random.Range  (3,  3);
            if  (x  >=  mapWidth)  break;
        }

        int  z  =  0;
        for (int  n  =  0;  n  <  50;  n++)
        {
            for  (int  mapW  =  0;  mapW  <  mapWidth;  mapW++)
            {
                if (mapGrid  [mapW,  z]  ==  -1)//crossroad
                    mapGrid  [mapW,  z]  =   -3;
                else
                    mapGrid  [mapW,  z]  =   -2;
            }
            z  +=  Random.Range  (5, 10);
            if  (z  >=  mapHeight)  break;
        }

        //generate city
        for  (int  mapH  =  0;  mapH  <  mapHeight;  mapH++)
        {
            for  (int  mapW  =  0;  mapW  <  mapWidth;  mapW++)
            {
                int  result  =  mapGrid  [mapW,  mapH];
                Vector3  pos  =  new Vector3  (mapW  *  buildingSpace,  0,  mapH  *  buildingSpace);

                if        (result  <  -2)
                    Instantiate  (crossroad, pos, crossroad.transform.rotation);
                else  if  (result  <  -1)
                    Instantiate  (xStreets,  pos,  xStreets.transform.rotation);
                else  if  (result  <   0)
                    Instantiate  (zStreets,  pos,  zStreets.transform.rotation);
                else  if  (result  <   1)
                    Instantiate  (buildings[0],  pos,  Quaternion.identity);
                else  if  (result  <   2)
                    Instantiate  (buildings[1],  pos,  Quaternion.identity);
                else if   (result  <   3)
                    Instantiate  (buildings[2],  pos,  Quaternion.identity);
                else  if  (result  <   4)
                    Instantiate  (buildings[3],  pos,  Quaternion.identity);
                else  if  (result  <   5)
                    Instantiate  (buildings[4],  pos,  Quaternion.identity);
                else  if  (result  <   6)
                    Instantiate  (buildings[5],  pos,  Quaternion.identity);
                else  if  (result  <   7)
                    Instantiate  (buildings[6],  pos,  Quaternion.identity);
                else  if  (result  <  10)
                    Instantiate  (buildings[7],  pos,  Quaternion.identity);
            }
        }


        

        

    }

    void Update()
    {
        
    }
}
