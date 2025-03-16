# ------------------ SQL
# start mysql
sudo /usr/local/mysql/support-files/mysql.server start 
brew services start mysql

# stop mysql
sudo /usr/local/mysql/support-files/mysql.server stop
brew services stop mysql 

# connect mysql
mysql -u root -p

# ------------------ DOTNET
# run the project
dotnet run

# create migration
dotnet ef migrations add Initial

# remove migration
dotnet ef migrations remove

# update database
dotnet ef database update