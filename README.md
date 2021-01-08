# FreakyFashionServices

## Docker support
Every microservice and application within this solution is supposed to be run within a Docker container.
There is no docker-compose configured at the moment and therefore the containera require a certain 
starting order - or IP adresses must be configured and updated in appsettings.json respectively.

1. SQL Server: 172.17.0.2
2. Catalog service: 172.17.0.3
3. Basket service: 172.17.0.4
4. Redis: 172.17.0.5
5. ProductPrice: 172.17.0.6
6. RabbitMQ: 172.17.0.7
7. Order: 172.17.0.8
9. API Gateway: 172.17.0.9

Console app is run through Visual studio.

## API Gateway
A gateway to reach all functionality provided by the microservices in this solution.

## Services

### Catalog
This service serves as the product register. From this service it is possible to GET one or all products in the 
database. Uses EF Core to store and get data from SQL Server.

### Basket
This service represents the shopping cart. It is possible to add a product to the cart and get the cart. 
This service uses Redis for caching basket data.

### ProductPrice
This service is the price database. For now the price is randomly generated to a double in the range 0 - 1000.

### Order
This service provides the ability to create an order.

### OrderConsole
Saves incomming orders in a SQL server database with EF Core and presents a list of all orders currently
undelivered. New orders will show up when they arrive from the Order service.
