namespace MailClient;

public class Mail
{
	private string sender;
    private string receiver;
    private string body;

    public Mail(string sender, string receiver, string body)
    {
        Sender = sender;
        Receiver = receiver;
        Body = body;
    }

    public string Sender
    {
		get { return sender; }
		set { sender = value; }
	}

    public string Receiver 
    {
        get { return receiver; }
        set { receiver = value; }
    }

	public string Body
	{
		get { return body; }
		set { body = value; }
	}

    public override string ToString()
    {
        return $"From: {Sender} / To: {Receiver}{Environment.NewLine}Message: {Body}";
    }
}
