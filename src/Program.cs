using System.Text;
using Renci.SshNet;

const string host = "localhost";
const int port = 2222;

var users = new List<(string Username, string Password, string ReceivedDirectory, string SentDirectory)>
{
	("demouser", "demopass", "inbox", "sent"),
	("mockuser", "mockpass", "mock-inbox", "mock-sent"),
	("fakeuser", "fakepass", "fake-inbox", "fake-sent")
};


foreach (var user in users)
{
	using var client = new SftpClient(
		host,
		port,
		user.Username,
		user.Password);

	client.Connect();

	var now = DateTime.UtcNow;
	var fileContent = $"Hello, World!{Environment.NewLine}The current time is: {now:yyyy-MM-dd HH:mm:ss}";
	using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));

	var filePath = $"{user.SentDirectory}/{user.Username}-{now:yyyyMMddHHmmss}.txt";

	client.UploadFile(
	memoryStream,
	filePath,
	(call) => Console.WriteLine($"Uploading: {call}"));

	client.Disconnect();

	Console.WriteLine($"File uploaded successfully for user: {user.Username} - {filePath}");
}


Console.WriteLine("File uploaded successfully!");
Console.ReadLine();
