# ------------------ SQL
# start mysql
# sudo /usr/local/mysql/support-files/mysql.server start 
brew services start mysql

# stop mysql
# sudo /usr/local/mysql/support-files/mysql.server stop
brew services stop mysql 

# connect mysql
mysql -u root

# ------------------ DOTNET
# run the project
dotnet run

# create migration
dotnet ef migrations add Initial

# remove migration
dotnet ef migrations remove

# update database
dotnet ef database update



# ------------------ CREER EXECUTABLE
# 1 
dotnet publish -c Release -r osx-arm64 \
  --self-contained true \
  -p:PublishSingleFile=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  -p:EnableCompressionInSingleFile=true \
  -p:PublishTrimmed=false \
  -o ./dist

# 2
sudo mkdir -p /Applications/Fideo
sudo cp ./dist/Fideo /Applications/Fideo/Fideo
sudo chmod +x /Applications/Fideo/Fideo