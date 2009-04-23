// Notification.cs created with MonoDevelop
// by Luc Castera at 2:59 PM 4/22/2009


using System;
using System.Collections.Generic;
using System.Text;

namespace MessagePub
{

  public class Notification
  {
    // private member variables
    private int id;
    private int escalation;
    private string sendAt;
    private string body;
    private string subject;
    List<Recipient> recipients;
    
    // Constructor
    public Notification() {
      escalation = 10;
      recipients = new List<Recipient>();
    }
    
    // Properties
    public int Id
    {
      get
      {
        return id;
      }
      
      set
      {
        id = value;
      }
    }
    
    public int Escalation
    {
      get
      {
        return escalation;
      }
      
      set
      {
        escalation = value;
      }
    }
    
    public string Body
    {
      get
      {
        return body;
      }
      
      set
      {
        body = value;
      }
    }
    
    public string Subject
    {
      get
      {
        return subject;
      }
      
      set
      {
        subject = value;
      }
    }
    
    public string SendAt
    {
      get
      {
        return sendAt;
      }
      
      set
      {
        sendAt = value;
      }
    }    
    
    public void addRecipient(Recipient rcpt)
    {
      recipients.Add(rcpt);  
    }
    
    public List<Recipient> Recipients
    {
      get
      {
        return recipients;
      }
    }
    
    public int getNumberOfRecipients()
    {
      return recipients.Count;
    }
    
    public string getXML() {
      StringBuilder sb = new StringBuilder("<notification>");
      sb.Append("<body>");
      sb.Append(body);
      sb.Append("</body>");
      sb.Append("<subject>");
      sb.Append(subject);
      sb.Append("</subject>");
      sb.Append("<escalation>");
      sb.Append(escalation);
      sb.Append("</escalation>");
      if ( sendAt != null) {
        sb.Append("<sendat>");
        sb.Append(sendAt);
        sb.Append("</sendat>");
      }
      sb.Append("<recipients>");
      for (int i=0; i < getNumberOfRecipients(); i++) {
        sb.Append("<recipient>");
        sb.Append("<position>");
        sb.Append(recipients[i].Position);
        sb.Append("</position>");
        sb.Append("<channel>");
        sb.Append(recipients[i].Channel);        
        sb.Append("</channel>");
        sb.Append("<address>");
        sb.Append(recipients[i].Address);
        sb.Append("</address>");        
        sb.Append("</recipient>");
      }
      sb.Append("</recipients>");
      sb.Append("</notification>");
      return sb.ToString();      
    }
    
  
  }

}