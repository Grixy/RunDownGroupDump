using UnityEngine;
using System.Collections;

public class Genner : MonoBehaviour {

	//Game Objects forming the joints of the passage.
	public GameObject pivot1;
	public GameObject pivot2;

	//Pivot Position Vectors.
	private Vector3 firstPositionPivotTop;
	private Vector3 secondPositionPivotTop;
	private Vector3 thirdPositionPivotTop;
	private Vector3 firstPositionPivotBot;
	private Vector3 secondPositionPivotBot; 
	private Vector3 thirdPositionPivotBot;

	//Switch Number to see if number is above or below 50%.
	private float switchLongAndShort;

	//Float that regulates just how far the branches should be from each other. 
	//This is necessary due to "hubs" in between points.
	//The offset would be the distance that the hub is. 
	public float hubOffset;
	private float hubOffsetIncrement;
	private float hubOffsetIncrementAhead;

	//This handles the section of the branch currently being populated, between 2 nodes.
	private int upperBranchSection = 0;
	private int lowerBranchSection = 0;

	//This handles the new object being spawned between nodes, in this instance, it handles the passage.
	public GameObject newObject;

	//The length of a texture prefab block
	public int texturePrefabLength;

	//Variables that handle spacing and generation of the branches in the world.
	private float distance1;
	private int numberOfCubes1;
	private Vector3 creationPoint1;	
	private float distance2;
	private int numberOfCubes2;
	private Vector3 creationPoint2;	
	private Vector3 objectLine1;
	private Vector3 objectLine2;

	//This can be changed to allow for bigger prefabs, the system is flexible with this.
	private int texturePrefabAmountTracker1 = 0;
	private int texturePrefabAmountTracker2 = 0;

	//Scaler that modifies lengths of tunnels
	private float lengthScaler = 1;

	//the clone variable for the passage prefab
	private GameObject passageClone;

	public int branchCount;

	void Start () {

		hubOffsetIncrement = 0;


		for (int i = 0; i <= branchCount; i++)
		{
		switchLongAndShort = Random.value; //Set up the switch value.
			hubOffsetIncrementAhead += hubOffset;
		Debug.Log (" Switch value: " + switchLongAndShort);

		if (switchLongAndShort >= 0.5)
		{

			//Generate the co-ordinates for the passage Pivots. 
			//An optimal method wil be implemented after the testing phase.
			//--------Top Chain--------------------------
			firstPositionPivotTop.x = (Random.Range (0, 10f) + hubOffsetIncrement) * lengthScaler;
			firstPositionPivotTop.y = 0;
			firstPositionPivotTop.z = Random.Range (5f, 10f);

				secondPositionPivotTop.x = (Random.Range (15f, 20f) + hubOffsetIncrement) * lengthScaler;
				secondPositionPivotTop.y = 0;
			secondPositionPivotTop.z = Random.Range (5f, 10f);

				thirdPositionPivotTop.x = (Random.Range (25f, 30f) + hubOffsetIncrement) * lengthScaler;
				thirdPositionPivotTop.y = 0;
			thirdPositionPivotTop.z = Random.Range (5f, 10f);
			//---------Bottom Chain-----------------------
				firstPositionPivotBot.x = (Random.Range (0, 10f)  + hubOffsetIncrement) * lengthScaler;
				firstPositionPivotBot.y = 0;
			firstPositionPivotBot.z = Random.Range (0, -5f);
				
				secondPositionPivotBot.x = (Random.Range (15f, 20f) + hubOffsetIncrement) * lengthScaler;
				secondPositionPivotBot.y = 0;
			secondPositionPivotBot.z = Random.Range (0, -5f);

				thirdPositionPivotBot.x = (Random.Range (25f, 30f) + hubOffsetIncrement) * lengthScaler;
				thirdPositionPivotBot.y = 0;
			thirdPositionPivotBot.z = Random.Range (0, -5f);

			//Place the Pivots, using the above co-ordinates. An array would be a better way to do this, 
			//but for the sake of debugging, a line-by-line method is being used.
			Object.Instantiate (pivot1, firstPositionPivotTop , transform.rotation);
			Object.Instantiate (pivot1, secondPositionPivotTop , transform.rotation);
			Object.Instantiate (pivot1, thirdPositionPivotTop , transform.rotation);

			Object.Instantiate (pivot2, firstPositionPivotBot , transform.rotation);
			Object.Instantiate (pivot2, secondPositionPivotBot , transform.rotation);
			Object.Instantiate (pivot2, thirdPositionPivotBot , transform.rotation);
			
			}

		if (switchLongAndShort < 0.5)
		{
			//Generate the co-ordinates for the passage Pivots. 
			//An optimal method wil be implemented after the testing phase.
			//--------Top Chain--------------------------
				firstPositionPivotTop.x = (Random.Range (0, 10f) + hubOffsetIncrement) * lengthScaler;
			firstPositionPivotTop.y = 0;
				firstPositionPivotTop.z = Random.Range (0, 5f);
			
				secondPositionPivotTop.x = (Random.Range (15f, 20f) + hubOffsetIncrement) * lengthScaler;
			secondPositionPivotTop.y = 0;
				secondPositionPivotTop.z = Random.Range (0, 5f);
			
				thirdPositionPivotTop.x = (Random.Range (25f, 30f) + hubOffsetIncrement) * lengthScaler;
			thirdPositionPivotTop.y = 0;
				thirdPositionPivotTop.z = Random.Range (0, 5f);
			//---------Bottom Chain-----------------------
				firstPositionPivotBot.x = (Random.Range (0, 10f) + hubOffsetIncrement) * lengthScaler;
			firstPositionPivotBot.y = 0;
				firstPositionPivotBot.z = Random.Range (-5f, -10f);
			
				secondPositionPivotBot.x = (Random.Range (15f, 20f) + hubOffsetIncrement) * lengthScaler;
			secondPositionPivotBot.y = 0;
				secondPositionPivotBot.z = Random.Range (-5f, -10f);
			
				thirdPositionPivotBot.x = (Random.Range (25f, 30f) + hubOffsetIncrement) * lengthScaler;
			thirdPositionPivotBot.y = 0;
				thirdPositionPivotBot.z = Random.Range (-5f, -10f);
			
			//Place the Pivots, using the above co-ordinates. An array would be a better way to do this, 
			//but for the sake of debugging, a line-by-line method is being used.
			Object.Instantiate (pivot1, firstPositionPivotTop , transform.rotation);
			Object.Instantiate (pivot1, secondPositionPivotTop , transform.rotation);
			Object.Instantiate (pivot1, thirdPositionPivotTop , transform.rotation);
			
			Object.Instantiate (pivot2, firstPositionPivotBot , transform.rotation);
			Object.Instantiate (pivot2, secondPositionPivotBot , transform.rotation);
			Object.Instantiate (pivot2, thirdPositionPivotBot , transform.rotation);

			}
//------------------------------------------------------------------------------------------
			{
				if (upperBranchSection == 0)
				{
					
					objectLine1 = (firstPositionPivotTop - new Vector3 (0 + hubOffsetIncrement,0,0));
					distance1 = objectLine1.magnitude;
					objectLine1 = objectLine1.normalized;
					numberOfCubes1 = (int)distance1;
					if (distance1 >= numberOfCubes1 + 0.5f)
					{
						numberOfCubes1 += 1;
					}
					while (texturePrefabAmountTracker1 <= numberOfCubes1 -1) {
						if (texturePrefabAmountTracker1 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (0 + hubOffsetIncrement + (texturePrefabAmountTracker1 * objectLine1.x) , 0, 0 + (texturePrefabAmountTracker1 * objectLine1.z)), transform.rotation)as GameObject;
							passageClone.transform.LookAt(firstPositionPivotTop);
						}
						texturePrefabAmountTracker1++;
						
					}
					if (texturePrefabAmountTracker1 >=numberOfCubes1)
					{
						texturePrefabAmountTracker1 = 0;
						upperBranchSection = 1;
					}
				}
				if (upperBranchSection == 1)
				{
					objectLine1 = (secondPositionPivotTop - firstPositionPivotTop);
					distance1 = objectLine1.magnitude;
					objectLine1 = objectLine1.normalized;
					numberOfCubes1 = (int)distance1;
					creationPoint1 = firstPositionPivotTop;
					if (distance1 >= numberOfCubes1 + 0.5f)
					{
						numberOfCubes1 += 1;
					}
					while (texturePrefabAmountTracker1 <= numberOfCubes1 - 1) {
						if (texturePrefabAmountTracker1 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint1.x + (texturePrefabAmountTracker1 * objectLine1.x), 0, creationPoint1.z+ (texturePrefabAmountTracker1 * objectLine1.z) ),  transform.rotation)as GameObject;
							passageClone.transform.LookAt(secondPositionPivotTop);
						}
						texturePrefabAmountTracker1++;
						
					}
					if (texturePrefabAmountTracker1 >=numberOfCubes1)
					{
						texturePrefabAmountTracker1 = 0;
						upperBranchSection = 2;
					}
				}
				if (upperBranchSection == 2)
				{
					
					objectLine1 = (thirdPositionPivotTop - secondPositionPivotTop);
					distance1 = objectLine1.magnitude;
					objectLine1 = objectLine1.normalized;
					numberOfCubes1 = (int)distance1;
					creationPoint1 = secondPositionPivotTop;
					if (distance1 >= numberOfCubes1 + 0.5f)
					{
						numberOfCubes1 += 1;
					}
					while (texturePrefabAmountTracker1 <= numberOfCubes1 - 1) {
						if (texturePrefabAmountTracker1 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint1.x + (texturePrefabAmountTracker1 * objectLine1.x), 0, creationPoint1.z + (texturePrefabAmountTracker1 * objectLine1.z) ),  transform.rotation)as GameObject;
							passageClone.transform.LookAt(thirdPositionPivotTop);
						}
						texturePrefabAmountTracker1++;
						
					}
					if (texturePrefabAmountTracker1 >=numberOfCubes1)
					{
						texturePrefabAmountTracker1 = 0;
						upperBranchSection = 3;
					}

				}

				if (upperBranchSection == 3)
				{
					
					objectLine1 = (new Vector3 (0 + hubOffsetIncrementAhead,0,0) - thirdPositionPivotTop);
					distance1 = objectLine1.magnitude;
					objectLine1 = objectLine1.normalized;
					numberOfCubes1 = (int)distance1;
					creationPoint1 = thirdPositionPivotTop;
					if (distance1 >= numberOfCubes1 + 0.5f)
					{
						numberOfCubes1 += 1;
					}
					while (texturePrefabAmountTracker1 <= numberOfCubes1 - 1) {
						if (texturePrefabAmountTracker1 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint1.x + (texturePrefabAmountTracker1 * objectLine1.x), 0, creationPoint1.z + (texturePrefabAmountTracker1 * objectLine1.z) ),  transform.rotation)as GameObject;
							passageClone.transform.LookAt(new Vector3 (0 + hubOffsetIncrementAhead,0,0));
						}
						texturePrefabAmountTracker1++;
						
					}
					if (texturePrefabAmountTracker1 >=numberOfCubes1)
					{
						texturePrefabAmountTracker1 = 0;
						upperBranchSection = 0;
					}
					
				}
				//----------------------------------------------------------------------------------------------------------------
				if (lowerBranchSection == 0)
				{
					objectLine2 = (firstPositionPivotBot - new Vector3 (0 + hubOffsetIncrement,0,0));
					distance2 = objectLine2.magnitude;
					objectLine2 = objectLine2.normalized;
					numberOfCubes2 = (int)distance2;
					if (distance2 >= numberOfCubes2 + 0.5f)
					{
						numberOfCubes2 += 1;
					}
					

					while (texturePrefabAmountTracker2 <= numberOfCubes2 - 1) {
						if (texturePrefabAmountTracker2 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (0 + hubOffsetIncrement + (texturePrefabAmountTracker2 * objectLine2.x) , 0, 0 + (texturePrefabAmountTracker2 * objectLine2.z) ), transform.rotation) as GameObject;
							passageClone.transform.LookAt(firstPositionPivotBot);
						}
						texturePrefabAmountTracker2++;
					}
					if (texturePrefabAmountTracker2 >= numberOfCubes2)
					{
						texturePrefabAmountTracker2 = 0;
						lowerBranchSection = 1;
					}

					
					
				}
				if (lowerBranchSection == 1)
				{
					
					objectLine2 = (secondPositionPivotBot - firstPositionPivotBot);
					distance2 = objectLine2.magnitude;
					objectLine2 = objectLine2.normalized;
					numberOfCubes2 = (int)distance2;
					creationPoint2 = firstPositionPivotBot;
					if (distance2 >= numberOfCubes2 + 0.5f)
					{
						numberOfCubes2 += 1;
					}
					

					
					while (texturePrefabAmountTracker2 <= numberOfCubes2 - 1) {
						if (texturePrefabAmountTracker2 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint2.x + (texturePrefabAmountTracker2 * objectLine2.x) , 0, creationPoint2.z + (texturePrefabAmountTracker2 * objectLine2.z) ), transform.rotation) as GameObject;
							passageClone.transform.LookAt(secondPositionPivotBot);
						}
						texturePrefabAmountTracker2++;
					}
					if (texturePrefabAmountTracker2 >= numberOfCubes2 )
					{
						texturePrefabAmountTracker2 = 0;
						lowerBranchSection = 2;
					}

				}
				if (lowerBranchSection == 2)
				{
					objectLine2 = (thirdPositionPivotBot - secondPositionPivotBot);
					distance2 = objectLine2.magnitude;
					objectLine2 = objectLine2.normalized;
					numberOfCubes2 = (int)distance2;
					creationPoint2 = secondPositionPivotBot;
					if (distance2 >= numberOfCubes2 + 0.5f)
					{
						numberOfCubes2 += 1;
					}
					

					while (texturePrefabAmountTracker2 <= numberOfCubes2 -1) {
						if (texturePrefabAmountTracker2 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint2.x + (texturePrefabAmountTracker2 * objectLine2.x) , 0, creationPoint2.z + (texturePrefabAmountTracker2 * objectLine2.z)), transform.rotation) as GameObject;
							passageClone.transform.LookAt(thirdPositionPivotBot);
						}
						texturePrefabAmountTracker2++;
					}
					if (texturePrefabAmountTracker2 >= numberOfCubes2 )
					{
						texturePrefabAmountTracker2 = 0;
						lowerBranchSection = 3;
					}
				}

				if (lowerBranchSection == 3)
				{
					
					objectLine2 = (new Vector3 (0 + hubOffsetIncrementAhead,0,0) - thirdPositionPivotBot);
					distance2 = objectLine2.magnitude;
					objectLine2 = objectLine2.normalized;
					numberOfCubes2 = (int)distance2;
					creationPoint2 = thirdPositionPivotBot;
					if (distance2 >= numberOfCubes2 + 0.5f)
					{
						numberOfCubes2 += 1;
					}
					while (texturePrefabAmountTracker2 <= numberOfCubes2 - 1) {
						if (texturePrefabAmountTracker2 >= 1)
						{
							passageClone = Instantiate (newObject, new Vector3 (creationPoint2.x + (texturePrefabAmountTracker2 * objectLine2.x), 0, creationPoint2.z + (texturePrefabAmountTracker2 * objectLine2.z) ),  transform.rotation)as GameObject;
							passageClone.transform.LookAt(new Vector3 (0 + hubOffsetIncrementAhead,0,0));
						}
						texturePrefabAmountTracker2++;
						
					}
					if (texturePrefabAmountTracker2 >=numberOfCubes2)
					{
						texturePrefabAmountTracker2 = 0;
						lowerBranchSection = 0;
					}
					
				}
				
				//generateNodes();
				//branchTracker++;
			}
//------------------------------------------------------------------------------------------
//			Debug.Log ("First pos Top: " + firstPositionPivotTop);
//			Debug.Log ("Offset: " + hubOffsetIncrement);
			hubOffsetIncrement += hubOffset;
		}

			
		}


	// Update is called once per frame
	void Update () {
	}
}