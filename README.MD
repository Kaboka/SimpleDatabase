Welcome to SimpleDB!


Tbis database is written in C#, to View the code open the project in visual studio or any other IDE that supports C#.
To use SimpleDB just place SimpleDB.exe in the folder you want the database to be placed and then click the file to start.
this file can be found in \SimpleDatabase\bin\Debug

Features of SimpleDB
*Read/Write data using key,value pairs.
*Uses inmemory indices to read data fast from the database.
*Crash/restart protection, when you close the database the indices will be saved on disk and loaded into memory when you start the database.


Supported commands of SimpleDB:

db_write: This command will save a key and value to the database. The format needs to be like this "db_write int data".
db_read: This command will find the data record in the database using the key value. The format needs to be like this "db_read int".