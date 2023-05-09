using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGeneration : MonoBehaviour
{

    [Header("Min ands Max")]
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    [Header("Tile Parameters")]

    public int tileSize = 10;

    public int xTiles;
    public int yTiles;

    [Header("Possible Room Arrays")]


    
    public GameObject[] possibleAdjacentRoom1N;
    public GameObject[] possibleAdjacentRoom1E;
    public GameObject[] possibleAdjacentRoom1S;
    public GameObject[] possibleAdjacentRoom1W;

    public GameObject[] possibleAdjacentRoom2N;
    public GameObject[] possibleAdjacentRoom2E;
    public GameObject[] possibleAdjacentRoom2S;
    public GameObject[] possibleAdjacentRoom2W;

    public GameObject[] possibleAdjacentRoom3N;
    public GameObject[] possibleAdjacentRoom3E;
    public GameObject[] possibleAdjacentRoom3S;
    public GameObject[] possibleAdjacentRoom3W;

    public GameObject[] possibleAdjacentRoom4N;
    public GameObject[] possibleAdjacentRoom4E;
    public GameObject[] possibleAdjacentRoom4S;
    public GameObject[] possibleAdjacentRoom4W;

    [Header("Rooms")]

    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;

    public GameObject[] rooms;

    public GameObject currentRoom;

    [Header("Coordinates")]

    public Vector3 startingRoomPosition;
    public Vector3 nextRoomPosition;
    public Vector3[] takenCoords;
    bool errorCoords;

    [Header("Cans")]

    public bool canNorth;
    public bool canEast;
    public bool canSouth;
    public bool canWest;

    public float currentX;


    


    [Header("Checks for coords")]

    public bool[] coordChecks = {false, false, false, false}; // North, east, south, west


    // Start is called before the first frame update
    void Start()
    {

        
        for(int i = 0; i < takenCoords.Length; i++){
            takenCoords[i] = new Vector3(0, 0, 1);
        }

        xTiles = (maxX - minX) / tileSize; // Calculates the possible amount of tiles in the map
        yTiles = (maxY - minY) / tileSize;

        float startingX = (maxX - minX) / 2; // Calculates the starting coordinates for the first room
        float startingY = (maxX - minX) / 2;

        startingRoomPosition = new Vector3(startingX, startingY, 0);
        nextRoomPosition = startingRoomPosition;


        for(int i = 0; i < takenCoords.Length; i++){
            if(takenCoords[i].z == 1){
                takenCoords[i] = nextRoomPosition; // Adds the current room position to the taken coordinates array; this means there will be no rooms on top of eachother
                break;
            }
        }

    
        rooms[0] = Instantiate(room1, startingRoomPosition, Quaternion.identity); // Creates the first room
        currentRoom = room1; // Sets the current room to the first room

        Generation();

        


    }

    public void Generation(){
        
        Debug.Log("Gen");
    
        int randomNumber = 0; // Initialises a random number variable to be used later

        if(currentRoom == room1){
            
            Debug.Log("Current room is room 1");

            randomNumber = Random.Range(0, possibleAdjacentRoom1N.Length); // Sets a random number between the range 0 - the possible north rooms to room 1
            
            coordChecks[0] = true; // Makes north true and everything else false
            coordChecks[1] = false;
            coordChecks[2] = false;
            coordChecks[3] = false;

            
            NextRoomCoords(); // Calls a check to see if its possible to create a room

            if(canNorth){

                Debug.Log("Can north");

                currentX = nextRoomPosition.x;

                nextRoomPosition = new Vector3(currentX, nextRoomPosition.y + tileSize, 0); // Creates a vector for the next rooms position
                
                for(int i = 0; i < rooms.Length; i++){
                    if(rooms[i] == null){
                        rooms[i] = Instantiate(possibleAdjacentRoom1N[randomNumber], nextRoomPosition, Quaternion.identity); 
                        Debug.Log($"Rooms[{i - 1}] is null");
                        break;
                    }
                }
                // Sets the next available slot for the rooms array to a new room that will be the chosen room with the random number, the vector that was made and idk what a quaternion does

                currentRoom = possibleAdjacentRoom1N[randomNumber];
            }
        }


        for(int k = 0; k < rooms.Length; k++){
            rooms[k].SetActive(true);
        }

    }


    public void NextRoomCoords(){

        Debug.Log("Next Room Coords");

        if(coordChecks[0]){ // Checks to see if its trying to create a room to the north
            Vector3 tempVector = new Vector3(nextRoomPosition.x, nextRoomPosition.y + tileSize, 0); // Creates a temporary vector of the position the room will be created in

            Debug.Log($"Temp Vector: {tempVector}");

            for(int k = 0; k < takenCoords.Length; k++){ // Loops through the taken coordinates array
                if(takenCoords[k] == tempVector){ // Checks to see if the temporary vector is in the taken coordinates array
                    Debug.Log("This position already exists");
                    canNorth = false; // If it is, you cannot generate a room there
                    break;
                }

                else{
                    Debug.Log($"Fine[{k}]");
                    canNorth = true;
                }
            }
        }
    }
}
