# NET_Test_v_3.0


1 get the two projects from repository  (https://git-scm.com/book/en/v2/Git-Tools-Bundling) back-end and front-end
2 go to folder from back-end and open project at visual studio
3 now go menu tools/package nuget manage/console package manage and execute the commands next:
to create estados, publicaciones, comentarios tables:
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
