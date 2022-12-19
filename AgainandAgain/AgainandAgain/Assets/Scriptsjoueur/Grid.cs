using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	void Awake() {
		nodeDiameter = nodeRadius*2;
		//Debug.Log ("nodeDiameter " + nodeDiameter);
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		//Debug.Log ("gridSizeX " + gridSizeX + "gridSizeY " + gridSizeY);
		CreateGrid();
	}

	void CreateGrid() {
		grid = new Node[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
		Debug.Log ("worldbuttonleft" + worldBottomLeft);
		for (int x = 0; x < gridSizeX; x ++) {
			for (int y = 0; y < gridSizeY; y ++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node) {
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}

		return neighbours;
	}


	public Node NodeFromWorldPoint(Vector3 worldPosition) 

	{	//Debug.Log (worldPosition.x + "en yyyyy" + worldPosition.y);
		//float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		//float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
	

		float percentX = (worldPosition.x - transform.position.x) / gridWorldSize.x + 0.5f - (nodeRadius / gridWorldSize.x);
		float percentY = (worldPosition.x - transform.position.z) / gridWorldSize.y + 0.5f - (nodeRadius / gridWorldSize.y);
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);

		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}

	public List<Node> path;
	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
		//Debug.Log (gridWorldSize.x + "  gridWorldSize  " + gridWorldSize.y);
		if (grid != null) {
			foreach (Node n in grid) {
				Gizmos.color = (n.walkable)?Color.white:Color.red;
				if (path != null)
				if (path.Contains (n)) {
					Gizmos.color = Color.black;
					//Debug.Log (n + "cell noire grille " + n.worldPosition);
				}
				Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
			}
		}
	}
}


/*
public class Grid : MonoBehaviour {
	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	Node[,] grid; // liste de couple de valeurs ( walkable,noeuds (x,y,z))

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	public List<Node> path;


	// Use this for initialization
	void Start () {
		nodeDiameter = nodeRadius*2;	 // diametre d 'une case de la grille
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);	// dimensions d une case en x nombre max de case en x
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);	// dimensions d une case en y
		CreateGrid ();
	}
		

	// cree tous les noeuds constituant la grille de jeu et les définit walkable ou non
	void CreateGrid() {
		grid = new Node[gridSizeX,gridSizeY];
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
		// constitue la grille entiere : cree des noeuds sur les parties walkable uniquement
		for (int x = 0; x < gridSizeX; x ++) {
			for (int y = 0; y < gridSizeY; y ++) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}
*/
/*
* affiche les grilles et les unwalkable de
void OnDrawGizmos() {
	Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,2,gridWorldSize.y));
	//affiche rendu de la grille dans le jeu
	if (grid != null) {
		foreach (Node n in grid) {
			Gizmos.color = (n.walkable)?Color.white:Color.red;
			Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
		}
	}

}
*/
/*
// convertit position dans le monde et le traduit en position dans la grille, avec son statut walkable
public Node NodeFromWorldPoint(Vector3 worldPosition) {
	float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
	float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
	percentX = Mathf.Clamp01(percentX);
	percentY = Mathf.Clamp01(percentY);

	int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
	int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
	return grid[x,y];
}

// recupere la liste des noeuds voisins
public List<Node> GetNeighbours(Node node) {
	List<Node> neighbours = new List<Node>();

	for (int x = -1; x <= 1; x++) {
		for (int y = -1; y <= 1; y++) {
			if (x == 0 && y == 0)
				continue;

			int checkX = node.gridX + x;
			int checkY = node.gridY + y;

			if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
				neighbours.Add(grid[checkX,checkY]);
			}
		}
	}

	return neighbours;
}

// reconstitue le chemin 
void OnDrawGizmos() {
	Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
	//Debug.Log ("taaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + path.Count);
	if (grid != null) {
		foreach (Node n in grid) {

			Gizmos.color = (n.walkable) ? Color.white : Color.red;
			if (path != null){
				if (path.Contains (n)) {
					//Debug.Log ("taaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" + path);
					Gizmos.color = Color.black;
				}
			}	
			Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
		}
	}
}

}

*/