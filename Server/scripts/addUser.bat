    @echo off
curl -X POST http://192.168.133.239:3050/add/user -H "Content-Type: multipart/form-data" -F "username=ribotha" -F "firstname=Riley" -F "lastname=Reid" -F "password=Password01" -F "isAdmin=false" -F "contactno=0833031908" -F "ctx=user" -F "image=@../images/user1.jpg"