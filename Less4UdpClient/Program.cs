using System.Net;
using System.Net.Sockets;

var ipAddress = IPAddress.Parse("192.168.1.82");
var port = 54751;

var ep = new IPEndPoint(ipAddress, port);

var client = new UdpClient(); 

while (true)
{
    var bytes = new byte[64000];
    int len = 0;

    using(var fs = new FileStream("C:\\Users\\DELL\\Desktop\\table-hw (1).png", FileMode.Open, FileAccess.Read))
    {
        while((len = fs.Read(bytes, 0, bytes.Length)) > 0)
        {
            client.Send(bytes,len,ep);
        }

    }
    Console.WriteLine("Process completed successfully");

    Console.ReadKey();
}
