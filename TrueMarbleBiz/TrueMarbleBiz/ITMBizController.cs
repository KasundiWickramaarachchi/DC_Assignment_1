//Referencing Distributed Computing Worksheet 02 
//Creating the business logic tier as a third tier in the practical
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
//Include ServiceModel library to get ServiceContract
using System.ServiceModel;
using TrueMarbleLibrary;

namespace TrueMarbleBiz
{
    //Making the interface an RPC service with the [ServiceContract] attribute
    [ServiceContract]

    //creating an interface for RPC
    public interface ITMBizController
    {
        //Using OperationContract to make it RPC-callable
        //[OperationContract]

        //bool VerifyTiles();
    }
}
