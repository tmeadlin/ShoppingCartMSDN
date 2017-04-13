# ShoppingCart

This is a simple project with two pages:
 - Products page
 - Checkout page
 
Click on the cart icon after an item has been added. Refresh the page to refresh the cart.

# Setup Instructions
 - Download/Clone the code
 - In the DocumentDb section of the MainSite/appsettings.json file, insert the appropriate "Endpoint" and "Key" for your Azure DocumentDb setup
 - Open a Console Window and navigate to MainSite
 - Run "npm install"
 - Run "dotnet restore"
 - Run "dotnet build"
 - Run "dotnet run"
 
# Note of Caution
The solution is currently setup to run through the dotnet cli. If you are planning on running this through Visual Studio 2017, please adjust the "apiEndpoint" configuration setting located in MainSite/ClientApp/app/app.config.ts. This should change to your port number, which can be found in MainSite/Properties/launchSettings.json