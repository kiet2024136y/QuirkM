#!/bin/bash 
echo -e "\e[33mdang cai dat......\e[0m"
pkg install wget -y
pkg install mono -y
pkg update -y
wget https://raw.githubusercontent.com/kiet2024136y/QuirkM/main/QuirkM.cs
echo -e "\e[33mtai ca goi phu thuoc..\e[0m"

echo -e "\e[32mda cai dat hoan tam\e[0m"
mcs QuirkM.cs
echo -e "\e[32mda bien dich thanh cong\e[0m"
echo -e "\e[33mdang tao file run.sh\e[0m"
echo -e "mono QuirkM.exe" > run.sh
echo -e "\e[32mda tao thanh conm\e[32m"
chmod +x run.sh 
echo -e "\e[32mda cap quyen thuc thi\e[0m"
echo -e "\e[32mda khoi dong Qurikm\e[0m"
echo -e "\e[33mexit:de thoat\e[0m"
./run.sh

