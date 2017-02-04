using System;
using Sniffer;

namespace Testdrive
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
            CRawSocket x = new CRawSocket("192.168.37.140", 0);
            x.OnPacketReceived +=new Sniffer.CCommon.PacketReceivedHandler(x_OnPacketReceived);
            x.IsListening = true;

        }

        private static void x_OnPacketReceived(object sender, object[] packetdata) {
            Console.WriteLine("Se recibio paquete...");
            Console.WriteLine("Largo del encabezado: {0}",  ((object[]) ((object[])  packetdata)[0])[0]);
            Console.WriteLine("Protocolo: {0}",  ((object[]) ((object[])  packetdata)[0])[1]);
            Console.WriteLine("IP Origen: {0}",  ((object[]) ((object[])  packetdata)[0])[2]);
            Console.WriteLine("IP Destino: {0}",  ((object[]) ((object[])  packetdata)[0])[3]);
            Console.WriteLine("Tamaño del paquete: {0}",  ((object[]) ((object[])  packetdata)[0])[4]);
            Console.WriteLine("Tamaño de la data: {0}\n",  ((object[]) ((object[])  packetdata)[0])[5]);
        }
    }
}
