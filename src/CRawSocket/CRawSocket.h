/* Archivo: CRawSocket.h
   Fecha: Octubre 2004 
   Autor: Angel J. Hernández M
   Lenguaje: Microsoft (R) 32-bit C/C++ Optimizing Compiler Version 13.10.3077 for 80x86
   E-m@il: angeljesus14@hotmail.com
   URL: http://groups.msn.com/desarrolladoresmiranda 

   Notas: Encapsula funcionalidad del Sniffer Socket y clase CCommon. 
*/

#pragma once
#using <System.Dll>
#using <Mscorlib.Dll>

#include "Winsock2.h"
#include <Iphlpapi.h>
#include <stdio.h>
#include <shellapi.h>
#include <stdlib.h>
#include <string.h>
#include <vcclr.h>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;
using namespace System::Runtime::InteropServices;
using namespace Microsoft::Win32;

namespace Sniffer {
	public __gc class CCommon {
        private:
            /* Miembros */
            static PIP_ADAPTER_INFO m_adapterinfo;

            /* Constantes */
            static String *EXCEPTIONMSG1 = "El número de dirección IP indicado no es válido. Verifique, por favor";
            static char *NOADAPTER = "No existen adaptadores de Red instalados en el equipo local";
            static char *NOSUPPORTED = "Función no soportada por el sistema operativo ";
            static char *MSGBOXCAPTION = "Información";
            static String *NOTAVAILABLE = "No Disponible"; 

            /* Métodos */
            static PIP_ADAPTER_INFO QueryListForSpecificAddress(String *ip);
		public:
            /* Enumeraciones */
            __value enum Protocols {
                ICMP = 1,
                TCP = 6,
                UDP = 17,
                NONE = 0,
             };

            /* Estructuras */
            [StructLayout(LayoutKind::Explicit)]
             __value struct IPHeader {
                [FieldOffset(0)] Byte verlen; // IP Version & IP Header length
                [FieldOffset(1)] Byte tos; // Type of service
                [FieldOffset(2)] UInt16 length; // Packet's total length
                [FieldOffset(4)] UInt16 id; // Unique identifier
                [FieldOffset(6)] UInt16 offset; // Flags & Offset
                [FieldOffset(8)] Byte ttl; // Time To Live
                [FieldOffset(9)] Byte protocol; // Protocol (TCP, UDP, any other)
                [FieldOffset(10)] UInt16 checksum; // IP Header checksum
                [FieldOffset(12)] Int64 source; // Source address
                [FieldOffset(16)] Int64 destination; // Destination address
             };

             __value struct TreeviewDetails {
                String *AdapterName;
                String *Type;
                String *IPAddress;
                String *NetworkSubMask;
                String *MAC;
                String *Gateway;
                String *WINS;
                String *DHCP;
             };

             __value struct PacketContent {
                Int32 HeaderLength;
                String *Protocol;
                String *SourceIP;
                String *TargetIP;
                Int32 PacketLength;
                Int32 DataLength;
                Byte RawPacket[];
             };

             __value struct NetworkStats {
                 Int32 dwMsgs;
                 Int32 dwEchos;
                 Int32 dwDestUnreachs;
                 Int32 dwInReceives;
                 Int32 dwInDelivers;
                 Int32 dwOutDiscards;
                 Int32 dwInSegs;
                 Int32 dwOutSegs;
                 Int32 dwNumConns;
                 Int32 dwInDatagrams;
                 Int32 dwOutDatagrams;
             };

			/* Constantes */
			static const int MAXBUFFERSIZE = 4096;
			static const int SIO_RCVALL = (int) 0x98000001;
			static const int HEADEROFFSET = 0x0F;

            /* Métodos */
			static String* GetIPAddressFromLong(u_long ipaddress);
            static String* GetNetworkAdapterAddresses()[];
            static void ShowWindowsAboutBox(IntPtr hWnd, String *szApp, String *szOtherStuff, IntPtr hIcon);
            static CCommon::TreeviewDetails ParseAdapterInfoData(String *ip);
            static char* ConvertFromStringToCharPtr(String *exprtoconvert);
	};

    public __gc class CRawSocket: public IDisposable {
        private:
            /* Miembros */
            Socket *m_socket;
            Int64 m_bytesreceived;
            Thread *m_listener;
            Boolean m_islistening;
            CCommon::Protocols m_filteredprotocol;

            /* Métodos */
            int SetSocketIOControl();
            void StartListening();
            void StopListening();
            void ListenerThread();
            void PacketReceiver(Byte packet[], int length);

        public:
            /* Constructor */
            CRawSocket(String *ipaddress, int port);

            /* Delegados */
            __delegate void PacketReceivedHandler(Object *sender,  CCommon::PacketContent packetdata);
            __delegate void SocketHandler(Object *sender);

            /* Eventos */
            __event  PacketReceivedHandler *OnPacketReceived;
            __event  SocketHandler *OnStartSniffing;
            __event  SocketHandler *OnStopSniffing;

            /* Propiedades */
            __property Socket* get_RawSocket() {
                return m_socket;
            }

            __property Int64  get_BytesReceived() {
                return m_bytesreceived;
            }

            __property Boolean get_IsListening() {
                return m_islistening;
                }

            __property void set_IsListening(Boolean value) {
                m_islistening = value;

                if (value) StartListening();
                else StopListening();
            }

            __property void set_FilteredProtocol(CCommon::Protocols value) {
                m_filteredprotocol = value;
            }

            __property CCommon::Protocols get_FilteredProtocol() {
                return m_filteredprotocol;
            }

            /* Métodos */
           CCommon::NetworkStats GetNetworkStats();
           void Dispose();

        protected:
            /* Métodos */
            virtual void DummyCallBackFunction(IAsyncResult *ar);
            virtual  CCommon::PacketContent ParseIPHeader(Byte packet[], int length);
        };
    }