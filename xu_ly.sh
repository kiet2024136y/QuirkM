#!/bin/bash 
echo -e "\e[33m[*]dang cai dat......\e[0m"
pkg install python3 -y
pkg install wget -y
pkg install mono -y
pkg update -y
wget https://raw.githubusercontent.com/kiet2024136y/QuirkM/main/QuirkM.cs
echo -e "\e[33m[*]tai ca goi phu thuoc..\e[0m"

echo -e "\e[32m[*]da cai dat hoan tam\e[0m"
mcs QuirkM.cs
echo -e "\e[32m[*]da bien dich thanh cong\e[0m"
echo -e "\e[33m[*]dang tao file run.sh\e[0m"
echo -e "mono QuirkM.exe" > run.sh
echo -e "\e[32m[*]da tao thanh conm\e[32m"
chmod +x run.sh 
echo -e "\e[32m[*]da cap quyen thuc thi\e[0m"
echo -e "\e[32m[*]da khoi dong Qurikm\e[0m"
echo -e "\e[33m[*]exit:de thoat\e[0m"
./run.sh

