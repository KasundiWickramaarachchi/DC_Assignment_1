//Referencing Distributed Computing Worksheet 01 
//Making a Maps-style satellite imagery browser
//Creating console based DataServer
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
//Include ServiceModel library to get ServiceContract
using System.ServiceModel;

namespace TrueMarbleData
{
    //Making the interface an RPC service with the [ServiceContract] attribute
    [ServiceContract]

    //creating an interface for RPC
    public interface ITMDataController
    {
        //Using OperationContract to make it RPC-callable
        [OperationContract]
        int GetTileWidth();
        int GetTileHeight();
        int GetNumTilesAcross(int zoom);
        int GetNumTilesDown(int zoom);
        byte[] LoadTile(int zoom, int x, int y);
    }
}
