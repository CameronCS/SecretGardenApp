
@echo off
    curl -X POST http://192.168.0.187:3050/add/child -H "Content-Type: multipart/form-data" -F "firstname=John" -F "lastname=Botha" -F "classname=Butterfly" -F "parentID1=66ba6a8f4c5de8d09861ad8d" -F "parentID2=N/A" -F "image=@../images/kid5.jpg"