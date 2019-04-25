//Referencing Distributed Computing Worksheet 02 
//Creating the business logic tier as a third tier in the practical
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
//Adding references
using System.ServiceModel;
using System.Runtime.Serialization;
using TrueMarbleData;
using TrueMarbleLibrary;

namespace TrueMarbleBiz
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                UseSynchronizationContext = false)]

    //creating an implementation class which inherits from ITMBizController
    public class TMBizControllerImpl : ITMBizController
    {
        public TMBizControllerImpl()
        {
            ITMDataController m_data;
            
            ChannelFactory<ITMDataController> chanFac;

            Console.WriteLine("Connecting to the server");

            //creating NetTcpBinding object

            NetTcpBinding Binding = new NetTcpBinding();

            //set max message size and array size

            Binding.MaxReceivedMessageSize = System.Int32.MaxValue;
            Binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

            //client connects on the server URL

            String btURL = "net.tcp://localhost:50001/TMData";

            chanFac = new ChannelFactory<ITMDataController>(Binding, btURL);

            //storing m_data
            m_data = chanFac.CreateChannel();
        }

        //public bool VerifyTiles() {
        
       //}
    }
}
