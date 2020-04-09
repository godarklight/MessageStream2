#!/bin/sh
find ../MessageStream2/ -iname *.cs > generate-cs.txt
sed "/.*Compile Include.*/d" -i MessageWriter2.csproj
sed "s/^/    <Compile Include=\"/g" -i generate-cs.txt
sed "s/$/\"\/>/g" -i generate-cs.txt
sed "/<ItemGroup>/r generate-cs.txt" -i MessageWriter2.csproj
rm generate-cs.txt
