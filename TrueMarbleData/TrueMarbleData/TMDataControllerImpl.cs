//Referencing Distributed Computing Worksheet 01 
//Making a Maps-style satellite imagery browser
//Creating console based DataServer
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
//Adding references
using System.ServiceModel;
using TrueMarbleLibrary;

namespace TrueMarbleData
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                UseSynchronizationContext = false)]

    //client should only access to the class via the ITMDataController interface
    internal class TMDataControllerImpl : ITMDataController
    {
        public TMDataControllerImpl()
        {

        }

        //implementing the methods by calling the appropriate functions in the dll
        public int GetTileWidth()
        {
                int tilewidth;
                int tileheight;

                TrueMarble.GetTileSize(out tilewidth, out tileheight);
                return tilewidth;
         }

         public int GetTileHeight()
         {
                int tilewidth;
                int tileheight;
  
                TrueMarble.GetTileSize(out tilewidth, out tileheight);
                return tileheight;
        }

         public int GetNumTilesAcross(int zoom)
         {
                
                int numtilesx;
                int numtilesy;

                TrueMarble.GetNumTiles(zoom, out numtilesx, out numtilesy);
               
                return zoom;
         }

         public int GetNumTilesDown(int zoom)
         {
               
                int numtilesx;
                int numtilesy;

                TrueMarble.GetNumTiles(zoom, out numtilesx, out numtilesy);

                return zoom;
         }

         public byte[] LoadTile(int zoom, int x, int y)
         {
            int jpgsize;

            int tilewidth  = this.GetTileWidth();
            int tileheight = this.GetTileHeight();
             
            //allocating buffer with size width*height*3
            int buffersize = tilewidth * tileheight  * 3;

            byte[] tilearray = new byte[buffersize];

            //using buffer to retrieve the JPEG data via TrueMarble.GetTileImageAsRawJPG() passing in x,y and zoom
            TrueMarble.GetTileImageAsRawJPG(zoom, x, y , out byte[] imagebuffer, buffersize, out jpgsize);

            //returning byte[] array to finish LoadTile()
            return tilearray; 

         }

        //adding default constructor to TMDataControllerImpl
        ~TMDataControllerImpl()
        {
            Console.WriteLine("client is no longer serviced");
        }

    }
}
