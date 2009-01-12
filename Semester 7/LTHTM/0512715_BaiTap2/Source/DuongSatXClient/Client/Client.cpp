// Client.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Winsock2.h"
#include <iostream>
using namespace std;
char *IP = "127.0.0.1";
void XuLy(char RecvBuf[])
{
	bool flag = RecvBuf[0] == 1;

	cout << "\n";
	long kq = atol(RecvBuf+1);
	if (flag)
		cout << "So tien ban phai tra la: " << kq << " USD";
	else
		cout << "So luong ve khong du.\n" << "Chi con " << kq << "ve";
}
int _tmain(int argc, _TCHAR* argv[])
{
	// Nhap IP cua server
	char sIP[100];
	cout << "Nhap IP cua server (mac dinh: 127.0.0.1) (nhan (B) de bo qua): ";	
	cin >> sIP;
	if (strcmpi(sIP, "b") != 0)
		IP = sIP;

	WSADATA wsaData;
	SOCKET SendSocket;
	sockaddr_in RecvAddr;
	int Port = 27015;
	char SendBuf[1024];
	int BufLen = 1024;
	char RecvBuf[100];
	int  BufLenRecv = 100;

	//---------------------------------------------
	// Initialize Winsock
	WSAStartup(MAKEWORD(2,2), &wsaData);

	//---------------------------------------------
	// Create a socket for sending data
	SendSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);

	//---------------------------------------------
	// Set up the RecvAddr structure with the IP address of
	// the receiver (in this example case "123.456.789.1")
	// and the specified port number.
	RecvAddr.sin_family = AF_INET;
	RecvAddr.sin_port = htons(Port);
	RecvAddr.sin_addr.s_addr = inet_addr(IP);

	// Xuat thong tin, nhap thong tin
	
	int chuyenxe;
	char loaive;
	int soluong;
	cout << "1. TP.HCM - Ha noi" << endl;
	cout << "\tA: gia ve 100 USD/ve" << endl;
	cout << "\tB: gia ve 80 USD/ve" << endl;
	cout << "\tC: gia ve 60 USD/ve" << endl;
	cout << "2. TP.HCM - Hue" << endl;
	cout << "\tA: gia ve 60 USD/ve" << endl;
	cout << "\tB: gia ve 50 USD/ve" << endl;
	cout << "\tC: gia ve 40 USD/ve" << endl;
	cout << "1. Ha noi - Da Lat" << endl;
	cout << "\tA: gia ve 120 USD/ve" << endl;
	cout << "\tB: gia ve 90 USD/ve" << endl;
	cout << "\tC: gia ve 70 USD/ve" << endl;
	cout << "Ban chon chuyen xe nao (1, 2, 3)? ";
	cin >> chuyenxe;
	cout << "Ban chon loai ve nao (A, B, C)? ";
	cin >> loaive;
	cout << "So luong ve muon dat? ";
	cin >> soluong;

	//---------------------------------------------
	// Send a datagram to the receiver
	//printf("Sending a datagram to the receiver...\n");
	SendBuf[0] = (char) (chuyenxe - 1);
	SendBuf[1] = (char) (toupper(loaive) - 'A');
	SendBuf[2] = (char) soluong;
	int t = sendto(SendSocket, 
		SendBuf, 
		BufLen, 
		0, 
		(SOCKADDR *) &RecvAddr, 
		sizeof(RecvAddr));
	int SenderAddrSize = sizeof(RecvAddr);

	if (t < 0)
	{	
		cout << "Loi ket noi! Khong the gui du lieu len may chu";
		exit(1);
	}
	t = recvfrom(SendSocket, 
		RecvBuf, 
		BufLenRecv, 
		0, 
		(SOCKADDR *)&RecvAddr, 
		&SenderAddrSize);

	if (t < 0)
		cout << "Loi ket noi! Khong nhan duoc du lieu tu may chu";
	else
		XuLy(RecvBuf);
	//---------------------------------------------
	// When the application is finished sending, close the socket.
	//printf("Finished sending. Closing socket.\n");
	closesocket(SendSocket);

	//---------------------------------------------
	// Clean up and quit.
//	printf("Exiting.\n");
	WSACleanup();

	return 0;
}

