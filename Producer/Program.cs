using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { UserName = "myuser", Password = "mypassword" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

string message = "Hello World!";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "",
                     routingKey: "hello",
                     basicProperties: null,
                     body: body);
Console.WriteLine(" [x] Sent {0}", message);

channel.Close();
connection.Close();
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();