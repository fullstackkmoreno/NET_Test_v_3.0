# NET_Test_v_3.0


1 get the two projects from repository back-end and front-end
2 go to folder from back-end and open project at visual studio
3 now go menu tools/package nuget manage/console package manage and execute the commands next:
to create database:
open and execute file: 0-Script Data Base 
to create estados, publicaciones, comentarios tables:
open and execute file: 1-Script Base ó
execute the commands next:
Add-Migration initial1
Update-Database
to create SistemaDeUsuarios tables:
Add-Migration SistemaDeUsuarios
Update-Database
4 now go menu build/ build solution
4 now go menu debug/debug solution
6 open window powershell and write commands next:
 cd folder from front-end eg: D:\PruebaTecnica\front-end
 code .
7 now go to menu Terminal/new Terminal and execute the command next:
 ng serve -o
