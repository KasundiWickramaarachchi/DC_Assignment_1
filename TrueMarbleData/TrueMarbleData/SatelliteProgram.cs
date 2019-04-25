//Referencing Distributed Computing Worksheet 01 
//Making a Maps-style satellite imagery browser
//Creating console based DataServer
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TrueMarbleData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Server");

            //Creating a ServiceHost 
            ServiceHost host;

            //create the NetTcpBinding object
            NetTcpBinding tcpBinding = new NetTcpBinding();

            //In order to passing around tile images,need to make default low size bigger

            tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
            tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            //bind TMDataControllerImpl to the ITMDataController interface with the URL
            host = new ServiceHost(typeof(TMDataControllerImpl));

            host.AddServiceEndpoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:50001/TMData");

            Console.WriteLine("Opening Server");

            try
            {
                //Server Opening
                host.Open();

                //Otherwise server will exit before it can service clients

                Console.WriteLine("Press Enter to EXIT: ");
                Console.ReadLine();
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            //Server Closing
            host.Close();

            Console.WriteLine("Closing Server");
        }
    }
}
