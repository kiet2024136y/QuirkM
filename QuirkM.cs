using System;

using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net.NetworkInformation;

namespace QuirkM
{

    public static class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"____                      __   __
 / __ \                    |  \ /  |
| | __ | | _   _ _   ___  _  _ | v |
| __ | | | | | / _ \| |/ / |\_ /| |
| | __ | | | _ | | || | _) )   <| |   | |
 \____ / \___ / \_)  __ /| _ |\_\_ |   | _ |
                | |
                | _ | ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("go: exit (de thoat),vui long khong nhap chu thuong,chi duong phep nhap chung in hoa");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            String[,] mat_ma = {{"Q","{1}"},{"W","{2}"},{"E","{3}"} ,{"R","{4}"},{"T","{5}"},
        {"Y","{6}"},{"U","{7}"},{"I","{8}"},{"O","{9}"},{"P","{0}"},{"A","{11}"},{"S","{12}"},{"D","{13}"},{"F","{14}"},
        {"G","{15}"},{"H","{16}"},{"J","{17}"},{"K","{18}"},{"L","{19}"},{"Z","{20}"},{"X","{21}"},{"C","{22}"},{"V","{23}"},
        {"B","{24}"},{"N","{25}"},{"M","{26}"},{"1","{93}"},{"2","{59})"},{"3","{53}"},{"4","{144}"},{"5","{64}"},{"6","{1221}"},
        {"7","{1226}"},{"8","{35}"},{"9","{253}"},{"0","{209}"},{".","{135}"},{",","{2211}"},{"!","{3252618}"},{"?","{1252618}"},{"+","{012}"},
        {"—","{2612}"},{"*","{26251225}"},{"÷","{13251225}"},{"=","{3191225}"},{" ","{%}"},{"/","{1216}"}};
            String[,] mat_ma2 = new String[mat_ma.GetLength(0), 2];
            for (int j = 0; j < mat_ma.GetLength(0); j++)
            {
                mat_ma2[j, 0] = mat_ma[j, 1];
                mat_ma2[j, 1] = mat_ma[j, 0];
            }
            Console.ResetColor();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Hay nhap cac ki tu sau de chuyen doi");
                Console.WriteLine("Tieng Viet-->Quirkm");
                Console.WriteLine("Tieng viet<--Quirmk");
                Console.WriteLine("Tinh nhan:TN");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("~/");
                Console.ResetColor();
                String chuoi = Console.ReadLine();

                if (chuoi.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Dung thanh cong");
                    Console.ResetColor();
                    break;
                }
                if (chuoi == "->")
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Neu muong thoat hay go :exit");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Nhap chu:");
                        chuoi = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        for (int j = 0; j < chuoi.Length; j++)
                        {
                            bool tim_thay = false;
                            String ki_tu_chuoi = chuoi[j].ToString();
                            for (int i = 0; i < mat_ma.GetLength(0); i++)
                            {
                                if (ki_tu_chuoi == mat_ma[i, 0])
                                {
                                    Console.Write(mat_ma[i, 1] + "$");
                                    tim_thay = true;
                                    break;
                                }

                            }
                            if (!tim_thay)
                            {
                                Console.Write(ki_tu_chuoi);
                            }
                            Console.Write("");
                        }

                        if (chuoi == "exit")
                        {
                            Console.WriteLine("Da thoat");
                            break;
                        }
                    }
                }
                else if (chuoi == "<-")
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Neu muong thoat hay go :exit");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("nhap ma:");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        chuoi = Console.ReadLine();
                        String[] maHoaArr = chuoi.Split("$");
                        chuoi = chuoi.Replace("%", " ");
                        foreach (String ma in maHoaArr)
                        {
                            bool tim_thay2 = false;
                            for (int i = 0; i < mat_ma2.GetLength(0); i++)
                            {
                                if (ma == mat_ma2[i, 0])
                                {
                                    Console.Write(mat_ma2[i, 1]);

                                    tim_thay2 = true;
                                    break;
                                }
                            }
                            if (!tim_thay2)
                            {
                                Console.Write(ma);
                            }
                            Console.Write("");
                        }
                        if (chuoi == "exit")
                        {
                            Console.WriteLine("Da thoat");
                            break;
                        }
                    }

                }
                else if (chuoi == "TN")
                {
                    string ip = "192.168.1.7";
                    int port = 5001;

                    try
                    {
                        TcpClient client = new TcpClient(ip, port);
                        NetworkStream ns = client.GetStream();

                        // Bắt đầu luồng nhận tin nhắn từ server
                        Thread recvThread = new Thread(() => RecvMsg(ns));
                        recvThread.Start();

                        // Gửi tin nhắn đến server
                        while (true)
                        {
                            Console.Write("Nhap tin nhan: ");
                            string msg = Console.ReadLine();
                            if (msg.ToLower() == "exit")
                            {
                                client.Close();
                                break;
                            }

                            byte[] data = Encoding.UTF8.GetBytes(msg);
                            ns.Write(data, 0, data.Length); // Gửi tin nhắn tới server
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Loi khi ket noi server: " + e.Message);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vui long nhap -> hoac <- de thuc hien dich vi ,xin cam on");
                    Console.ResetColor();
                }


                // Phương thức nhận tin nhắn từ server
                static void RecvMsg(NetworkStream ns)
                {
                    byte[] buffer = new byte[1024];
                    try
                    {
                        while (true)
                        {
                            int bytesRead = ns.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                                break;

                            // Hiển thị tin nhắn từ server
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            Console.WriteLine("Received message: " + message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

            }
        }
    }
}
