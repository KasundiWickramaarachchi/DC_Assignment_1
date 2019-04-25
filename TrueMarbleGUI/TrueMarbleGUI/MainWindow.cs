//Referencing Distributed Computing Worksheet 01 
//Making a Maps-style satellite imagery browser
//Creating a GUI client as a presentation/GUI tier in the practical
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
using Gtk;
using System.ServiceModel;
using System.Runtime.Serialization;
//using TrueMarbleData;
using TrueMarbleBiz;

public partial class MainWindow : Gtk.Window
{
    //adding class fields for the current zoom,x and y positions

    //ITMDataController m_tmData;
    ITMBizController m_biz;
    int m_zoom;
    int m_x;
    int m_y;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        m_zoom = 4;
        m_x = 0;
        m_y = 0;

        Build();

        //ChannelFactory<ITMDataController> chanFac;
        ChannelFactory<ITMBizController> chanFac;

        Console.WriteLine("Connecting to the server");

        //creating NetTcpBinding object

        NetTcpBinding Binding = new NetTcpBinding();

        //set max message size and array size

        Binding.MaxReceivedMessageSize = System.Int32.MaxValue;
        Binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

        //client connects on the server URL

        //String tURL = "net.tcp://localhost:50001/TMData";
        String tURL = "net.tcp://localhost:50002/TMBiz";

        //chanFac= new ChannelFactory<ITMDataController>(Binding, tURL);
        chanFac = new ChannelFactory<ITMBizController>(Binding, tURL);

        //m_tmData = chanFac.CreateChannel();
        m_biz = chanFac.CreateChannel();

        try
        {
            //img.Pixbuf = new Gdk.Pixbuf(m_tmData.LoadTile(m_zoom, m_x, m_y));
            img.Pixbuf = new Gdk.Pixbuf(m_biz.LoadTile(m_zoom, m_x, m_y));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
