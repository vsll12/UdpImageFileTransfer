using System.Net;
using System.Net.Sockets;

var ipAddress = IPAddress.Parse("192.168.1.82");
var port = 54751; ;

var ep = new IPEndPoint(ipAddress, port);

var server = new UdpClient(ep);


var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);


while (true)
{

    var info =  Directory.CreateDirectory("C:\\Users\\DELL\\Desktop\\ServerUdp");
    var bytes = new byte[64000];
    var dInfo = Directory.CreateDirectory($"{info.FullName}\\FolderForUdp");
    int len;

    using (var fs = new FileStream($"{dInfo.FullName}\\Image.png", FileMode.OpenOrCreate, FileAccess.Write))
    {
        while ((len = (bytes = server.Receive(ref remoteEndPoint)).Length) > 0)
        {
            fs.Write(bytes, 0, len);
        }
    }

    Console.WriteLine("Process completed");

    Console.ReadKey();
}