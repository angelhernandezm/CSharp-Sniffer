/* Archivo: CCommon.cs
   Fecha: Octubre 2004 
   Autor: Angel J. Hernández M
   Lenguaje: Microsoft (R) Visual C# .NET Compiler version 7.10.6001.4
   E-m@il: angeljesus14@hotmail.com
   URL: http://groups.msn.com/desarrolladoresmiranda 

   Notas: Métodos, enumeraciones, constantes y delegados comunes (Usados en la solución)
*/


using System;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Sniffer;
using Sniffer.Common;

namespace Sniffer.Common {
    #region "Clase CShare"
        public class CShare {
            #region "Enumeraciones"
                public enum ConnectionType: int {
                    LAN,
                    Internet
                }

                public enum IPAddressPart: int {
                    Address,
                    Port
                }
            #endregion

            #region "Constantes"
                public const string DMURL = "http://groups.msn.com/desarrolladoresmiranda";
                public const string MCPURL = "http://www.microsoft.com/mcp";
                public const string MCSDPBX = "PBXMCSD";
                public const string CONFIRMMSG = "Confirmación";
                public const string EXCLAMATIONMSG = "Información";
                public const string MSGBOXTEXT1 = "¿ Seguro que desea salir ?";
                public const string CONNECTED = "Traza en ejecución";
                public const string NOTCONNECTED = "Traza detenida";
                public const string TRACEDSNAME = "PacketTrace";
                public const string WORKINGDSNAME = "WorkingPacketTrace";
                public const string TRACETABLENAME = "PacketReceived";
                public const int HEADERBYTES = 40;
                public const string EVENTLOGENTRY = "%1 la escucha de paquetes entrantes. El objeto que recibe los paquetes es :";
                public const string STARTSNIFFING = "Se ha comenzado/reanudado ";
                public const string STOPSNIFFING = "Se ha pausado/suspendido ";
                public const string ADAPTERNOTSELECTED = "No ha seleccionado ninguna tarjeta de red para inspeccionar. "+
                                                                             "Verifique, por favor";
                public const string TABLEEMPTY = "No se han registrado eventos en la traza por lo que no se puede "+
                                                                "continuar con la exportación";
                public const string APPINFO = "CSharpSniffer ha sido desarrollado por Angel J. Hernández M. "+
                                                           "Octubre 2004";
            #endregion

            #region "Miembros"
                private static string m_targeturl;
            #endregion

            #region "Delegados"
                public delegate void SetFilterHandler(CCommon.Protocols protocol);
                public delegate void SelectAddressHandler(string selected);
                public delegate int ControlInvokeCallback(TreeNode newnode);
                public delegate DataSet CreateDataSetCallback(string datasetname);
            #endregion

            #region "Métodos"
                /// <summary>
                /// 
                /// </summary>
                /// <param name="targeturl"></param>
                public static void NavigateToURL(string targeturl) {
                    m_targeturl = targeturl;
                    Thread thread =  new Thread(new ThreadStart(NavigateToURLHelper));
                    thread.Start();
                }

                /// <summary>
                /// 
                /// </summary>
                private static void NavigateToURLHelper() {
                    Process.Start(m_targeturl);
                }

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                //public static DataSet CreateTraceDataSet() {
                  public static DataSet CreateTraceDataSet(string datasetname) {
                    DataSet retval = new DataSet(datasetname);
                    DataTable table = retval.Tables.Add(TRACETABLENAME);

                    table.Columns.AddRange(new DataColumn[] {new DataColumn("EventID", Type.GetType("System.Int32")),
                                                       new DataColumn("TimeStamp", Type.GetType("System.String")),
                                                       new DataColumn("SourceIP", Type.GetType("System.String")),
                                                       new DataColumn("SourcePort", Type.GetType("System.Int32")),
                                                       new DataColumn("Protocol", Type.GetType("System.String")),
                                                       new DataColumn("TargetIP", Type.GetType("System.String")),
                                                       new DataColumn("TargetPort", Type.GetType("System.Int32")),
                                                       new DataColumn("PacketContent", Type.GetType("System.String"))});

                    table.Columns["EventID"].AutoIncrement = true;
                    table.Columns["EventID"].AutoIncrementSeed = 1;
                   
                    return retval;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="tracecontainer"></param>
                /// <param name="packetdata"></param>
                public static void RegisterEvent(DataSet tracecontainer, CCommon.PacketContent packetdata) {
                        DataRow row = tracecontainer.Tables[TRACETABLENAME].NewRow();
                        row["SourceIP"] = GetPartFromIP(packetdata.SourceIP, IPAddressPart.Address);
                        row["SourcePort"] = GetPartFromIP(packetdata.SourceIP, IPAddressPart.Port);
                        row["Protocol"] = packetdata.Protocol;
                        row["TargetIP"] = GetPartFromIP(packetdata.TargetIP, IPAddressPart.Address);
                        row["TargetPort"] = GetPartFromIP(packetdata.TargetIP, IPAddressPart.Port);
                        row["PacketContent"] =   Encoding.Default.GetString(packetdata.RawPacket,  HEADERBYTES, packetdata.PacketLength);
                        tracecontainer.Tables[TRACETABLENAME].Rows.Add(row);
                 }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="ownip"></param>
                /// <param name="iptocompare"></param>
                /// <returns></returns>
                public static bool IsAnIPFromMyLAN(string ownip, string iptocompare) {
                    bool retval = false;
                    string[] local = ownip.Split('.');
                    string[] incoming = iptocompare.Split('.');

                    if (local[0].Equals(incoming[0]) && local[1].Equals(incoming[1]) &&
                        local[2].Equals(incoming[2])) retval = true;

                    return retval;
                }

                /// <summary>
                /// 
                /// </summary>
                /// <param name="address"></param>
                /// <param name="part"></param>
                /// <returns></returns>
                public static string GetPartFromIP(string address, IPAddressPart part) {
                    string retval;
                    string[] splitted = address.Split(':');
                    retval = part.Equals(IPAddressPart.Address) ? splitted[0] : splitted[1];

                    return retval;
                }
            #endregion
        }
    #endregion

    #region "Clase CCustomComboItem"
        public class CCustomComboItem {
            private string m_text;
            public string Text {
                get {return m_text;}
                set {m_text = value;}
            }

            private int m_imageIndex;
            public int ImageIndex {
                get {return m_imageIndex;}
                set {m_imageIndex = value;}
            }

            public CCustomComboItem() : this(string.Empty) {}

            public CCustomComboItem(string text) : this(text, -1) {}

            public CCustomComboItem(string text, int imageIndex) {
                m_text = text;
                m_imageIndex = imageIndex;
            }

            public override string ToString() {
                return m_text;
            }
        }
    #endregion
 }