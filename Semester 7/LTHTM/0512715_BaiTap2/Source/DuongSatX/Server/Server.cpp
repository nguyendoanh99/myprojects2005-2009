// Server.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Winsock2.h"
#include <stdlib.h>
#include "iostream"
using namespace std;
struct LOAIVE
{
public:
	char *tenVe;
	int soLuong;
	int giaVe;
};
class CHUYEN
{
public:
	char *tenChuyen;
	LOAIVE dsLoaiVe[3];	
};
CHUYEN dsChuyen[3];
void KhoiTao()
{
	dsChuyen[0].tenChuyen = "TP.HCM - Ha Noi";
	dsChuyen[0].dsLoaiVe[0].tenVe = "A";
	dsChuyen[0].dsLoaiVe[0].soLuong = 50;
	dsChuyen[0].dsLoaiVe[0].giaVe = 100;
	dsChuyen[0].dsLoaiVe[1].tenVe = "B";
	dsChuyen[0].dsLoaiVe[1].soLuong = 80;
	dsChuyen[0].dsLoaiVe[1].giaVe = 80;
	dsChuyen[0].dsLoaiVe[2].tenVe = "C";
	dsChuyen[0].dsLoaiVe[2].soLuong = 40;
	dsChuyen[0].dsLoaiVe[2].giaVe = 60;

	dsChuyen[1].tenChuyen = "TP.HCM - Hue";
	dsChuyen[1].dsLoaiVe[0].tenVe = "A";
	dsChuyen[1].dsLoaiVe[0].soLuong = 35;
	dsChuyen[1].dsLoaiVe[0].giaVe = 60;
	dsChuyen[1].dsLoaiVe[1].tenVe = "B";
	dsChuyen[1].dsLoaiVe[1].soLuong = 54;
	dsChuyen[1].dsLoaiVe[1].giaVe = 50;
	dsChuyen[1].dsLoaiVe[2].tenVe = "C";
	dsChuyen[1].dsLoaiVe[2].soLuong = 48;
	dsChuyen[1].dsLoaiVe[2].giaVe = 40;

	dsChuyen[2].tenChuyen = "Ha Noi - Da Lat";
	dsChuyen[2].dsLoaiVe[0].tenVe = "A";
	dsChuyen[2].dsLoaiVe[0].soLuong = 70;
	dsChuyen[2].dsLoaiVe[0].giaVe = 120;
	dsChuyen[2].dsLoaiVe[1].tenVe = "B";
	dsChuyen[2].dsLoaiVe[1].soLuong = 50;
	dsChuyen[2].dsLoaiVe[1].giaVe = 90;
	dsChuyen[2].dsLoaiVe[2].tenVe = "C";
	dsChuyen[2].dsLoaiVe[2].soLuong = 30;
	dsChuyen[2].dsLoaiVe[2].giaVe = 70;
}
void XyLy(char RecvBuf[], char SendBuf[])
{
	char ten = RecvBuf[0];
	char loai = RecvBuf[1];
	unsigned char soluongmua = RecvBuf[2];
	char toString[11];
	long kq;

	if (dsChuyen[ten].dsLoaiVe[loai].soLuong >= soluongmua)
	{
		SendBuf[0] = 1;
		kq = soluongmua * dsChuyen[ten].dsLoaiVe[loai].giaVe;		
		dsChuyen[ten].dsLoaiVe[loai].soLuong -= soluongmua;
		cout << "Chuyen " << dsChuyen[ten].tenChuyen << " con " << dsChuyen[ten].dsLoaiVe[loai].soLuong << " ve loai " << dsChuyen[ten].dsLoaiVe[loai].tenVe << endl;
	}
	else // Khong du ve
	{
		SendBuf[0] = 0;
		kq = dsChuyen[ten].dsLoaiVe[loai].soLuong;
	}

	_ltoa(kq, toString, 10);
	for (int i = 0 ; i < sizeof(toString); ++i)
		SendBuf[1 + i] = toString[i];
}
int _tmain(int argc, _TCHAR* argv[])
{

	KhoiTao();
	WSADATA wsaData;
	SOCKET RecvSocket;
	sockaddr_in RecvAddr;
	int Port = 27015;
	char RecvBuf[1024];
	int  BufLen = 1024;
	sockaddr_in SenderAddr;	
	int SenderAddrSize = sizeof(SenderAddr);
	char SendBuf[100];
	int BufLenSend = 100;
	//-----------------------------------------------
	// Initialize Winsock
	WSAStartup(MAKEWORD(2,2), &wsaData);

	//-----------------------------------------------
	// Create a receiver socket to receive datagrams
	RecvSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);

	//-----------------------------------------------
	// Bind the socket to any address and the specified port.
	RecvAddr.sin_family = AF_INET;
	RecvAddr.sin_port = htons(Port);
	RecvAddr.sin_addr.s_addr = htonl(INADDR_ANY);

	bind(RecvSocket, (SOCKADDR *) &RecvAddr, sizeof(RecvAddr));

	//-----------------------------------------------
	// Call the recvfrom function to receive datagrams
	// on the bound socket.
	while (1)
	{
		printf("Receiving datagrams...\n");
		recvfrom(RecvSocket, 
			RecvBuf, 
			BufLen, 
			0, 
			(SOCKADDR *)&SenderAddr, 
			&SenderAddrSize);

		// Xu ly
		XyLy(RecvBuf, SendBuf);
		sendto(RecvSocket, 
			SendBuf, 
			BufLenSend, 
			0, 
			(SOCKADDR *) &SenderAddr, 
			sizeof(SenderAddr));
		//-----------------------------------------------
		// Close the socket when finished receiving datagrams
		printf("Finished receiving. Closing socket.\n\n");
	}
	closesocket(RecvSocket);

	//-----------------------------------------------
	// Clean up and exit.
	printf("Exiting.\n");
	WSACleanup();

	return 0;
}

