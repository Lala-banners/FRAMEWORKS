using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreadAndButter
{
    public class GridManager : MonoBehaviour
    {
        #region Grid Stuff
        public List<Sprite> candies = new List<Sprite>(); //Images of tiles
        public GameObject tilePrefab; //display of tile sprites
        public int gridDimension = 8; //Stores the size of the Grid
        public float distance = 1.0f; //Distance of the cells in the game
        private GameObject[,] grid; //2D array IRL Grid
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            grid = new GameObject[gridDimension, gridDimension];
            InitialiseGrid();
        }

        public void InitialiseGrid()
        {
            //Calculate offset so the grid is centered in the position of the gameobject (this value will be added to the position of every tile/cell)
            Vector3 posOffset = transform.position - new Vector3(gridDimension * distance / 2.0f, gridDimension * distance / 2.0f, 0);
            for (int row = 0; row < gridDimension; row++) //loop through all candy sprites
            {
                for (int column = 0; column < gridDimension; column++)
                {
                    #region Spawn Grid with no matches

                    #endregion

                    #region Spawning Random Grid
                    GameObject newTile = Instantiate(tilePrefab);
                    SpriteRenderer spriteRenderer = newTile.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = candies[Random.Range(0, candies.Count)];
                    newTile.transform.parent = transform;
                    newTile.transform.position = new Vector3(column * distance, row * distance, 0) + posOffset;
                    grid[column, row] = newTile; //Save reference to newTile
                    #endregion
                }
            }

        }
    }
}
