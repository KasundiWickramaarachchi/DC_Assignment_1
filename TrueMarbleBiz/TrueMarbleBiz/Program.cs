//Referencing Distributed Computing Worksheet 02 
//Creating the business logic tier as a third tier in the practical
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
using System.ServiceModel;

namespace TrueMarbleBiz
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Creating a ServiceHost 
            ServiceHost host;
            NetTcpBinding tcpBinding = new NetTcpBinding();

            //Using a ServiceHost bind TMBizControllerImpl to a TCP port 50002 with server name TMBiz in the URL
            host = new ServiceHost(typeof(TMBizControllerImpl));

            host.AddServiceEndpoint(typeof(ITMBizController), tcpBinding, "net.tcp://localhost:50002/TMBiz");

            Console.WriteLine("Opening Server");

            try
            {
                //Server Opening
                host.Open();

                //Block main() from exiting
                Console.WriteLine("Press Enter to EXIT: ");
                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Server Closing
            host.Close();

            Console.WriteLine("Closing Server");

        }
    }
}
