using System.Reflection.Metadata;

namespace MailClient;

public class MailBox
{
	private int capacity;
    private List<Mail> inbox;
    private List<Mail> archive;

    public MailBox(int capacity)
    {
        Capacity = capacity;
        Inbox = new List<Mail>();
		Archive = new List<Mail>();
    }

    public int Capacity 
	{
		get { return capacity; }
		set { capacity = value; }
	}

	public List<Mail> Inbox
	{
		get { return inbox; }
		set { inbox = value; }
	}

    public List<Mail> Archive
    {
		get { return archive ; }
		set { archive  = value; }
	}

	public void IncomingMail(Mail mail)
	{
		if (Capacity > Inbox.Count)
		{
            Inbox.Add(mail);

        }
	}

	public bool DeleteMail(string sender)
	{
		int senderIndex = Inbox.FindIndex(s => s.Sender == sender);

		if (senderIndex < 0)
		{
			return false;
		}
		else
		{
			Inbox.RemoveAt(senderIndex);
			return true;
		}
	}

	public int ArchiveInboxMessages()
	{
		int count = 0;
		while (Inbox.Any())
		{
			Mail mail = Inbox.ElementAt(0);
			Archive.Add(mail);
			Inbox.RemoveAt(0);
			count++;
        }
		return count;
    }

	public string GetLongestMessage()
	{
		Mail mailIn = Inbox.OrderByDescending(b => b.Body.Length).First();
		return mailIn.ToString();
    }
	public string InboxView()
	{
		return $"Inbox:{Environment.NewLine}{string.Join(Environment.NewLine,Inbox)}";
		
    }
}
