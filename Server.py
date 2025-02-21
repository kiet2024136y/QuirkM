import socket
import threading
import signal
import sys

clients = []
server = None  # Biến toàn cục để lưu server socket

def handle_client(client_socket, address):
    print(f"[+] Kết nối từ {address}")
    clients.append(client_socket)

    try:
        while True:
            data = client_socket.recv(1024).decode("utf-8")
            if not data:
                break

            print(f"[{address}] {data}")

            # Gửi tin nhắn đến tất cả client khác
            for client in clients:
                if client != client_socket:
                    try:
                        client.send(f"[{address}] {data}".encode("utf-8"))
                    except:
                        clients.remove(client)

    except Exception as e:
        print(f"Lỗi {address}: {e}")

    print(f"[-] Mất kết nối {address}")
    clients.remove(client_socket)
    client_socket.close()

def stop_server(signal_received, frame):
    """Hàm xử lý khi nhận tín hiệu dừng (Ctrl + C)"""
    global server
    print("\n[!] Đang dừng server...")

    # Đóng tất cả kết nối client
    for client in clients:
        client.close()

    if server:
        server.close()

    sys.exit(0)  # Thoát chương trình

def start_server(host="0.0.0.0", port=5001):
    global server
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server.bind((host, port))
    server.listen(5)

    print(f"[*] Server đang chạy trên {host}:{port}")
    
    # Bắt tín hiệu Ctrl + C để dừng server
    signal.signal(signal.SIGINT, stop_server)

    while True:
        try:
            client_socket, address = server.accept()
            client_thread = threading.Thread(target=handle_client, args=(client_socket, address))
            client_thread.start()
        except OSError:
            break  # Thoát vòng lặp khi server bị đóng

if __name__ == "__main__":
    start_server()
