// Client.cs created with MonoDevelop
// by Luc Castera at 3:58 PM 4/22/2009

using System;
using System.Net; 
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace MessagePub
{
  
  
  public class Client
  {
    
    private string apiKey;
    private string baseUrl;
    
    // Constructor
    public Client(string yourAPIKey)
    {
      baseUrl = "http://messagepub.com";
      apiKey = yourAPIKey;
    }
    
    // Properties
    public string APIKey
    {
      get
      {
        return apiKey;
      }
      
      set
      {
        apiKey = value;
      }
    }
    
    // Public Methods
    
    // returns HTTP Status Code
    public string createNotification(Notification note)
    {
      HttpWebRequest req = (HttpWebRequest) WebRequest.Create(baseUrl + "/notifications.xml");
      req.Credentials = new NetworkCredential(apiKey, "password");
      req.Method = "POST";
      req.ContentType = "text/xml";
      req.Accept = "text/xml";
      Stream s = req.GetRequestStream();
      string postData = note.getXML();
      s.Write(System.Text.Encoding.ASCII.GetBytes(postData),0,postData.Length );
      s.Close();      
      HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
      return resp.StatusCode.ToString();
    }    
    
    // Gets one notification based on id
    public Notification getNotification(int notificationId) 
    {
      HttpWebRequest req = (HttpWebRequest) WebRequest.Create(baseUrl + "/notifications/" + notificationId + ".xml");
      req.Credentials = new NetworkCredential(apiKey, "password");
      req.Method = "GET";     
      req.Accept = "text/xml";
      
      HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
      Notification note = new Notification();      

      if (resp.StatusCode == System.Net.HttpStatusCode.OK) 
      {        
        Stream receiveStream = resp.GetResponseStream();
        XmlReader reader = new XmlTextReader(receiveStream);        
                
        while (reader.Read()) {
          if (reader.NodeType == XmlNodeType.Element) {
            if (reader.Name == "notification") {
              note = parseNotificationXML(reader.ReadOuterXml());
            }
          }
        }
      } else {
        throw new Exception();
      }      
      return note;
    }
    
    
    public List<Notification> getNotifications() 
    {
      HttpWebRequest req = (HttpWebRequest) WebRequest.Create(baseUrl + "/notifications.xml");
      req.Credentials = new NetworkCredential(apiKey, "password");
      req.Method = "GET";     
      req.Accept = "text/xml";
      
      HttpWebResponse resp = (HttpWebResponse) req.GetResponse();
      List<Notification> list = new List<Notification>();      

      if (resp.StatusCode == System.Net.HttpStatusCode.OK) 
      {        
        Stream receiveStream = resp.GetResponseStream();
        XmlReader reader = new XmlTextReader(receiveStream);        
                
        while (reader.Read()) {
          if (reader.NodeType == XmlNodeType.Element) {
            if (reader.Name == "notification") {
              Notification note = parseNotificationXML(reader.ReadOuterXml());
              list.Add(note);
            }
          }
        }
      } else {
        throw new Exception();
      }      
      return list;      
    }
    
    
    private Notification parseNotificationXML(string notificationXMlString)
    {
      XmlReader reader = new XmlTextReader(new StringReader(notificationXMlString));     
      Notification note = new Notification();
      while (reader.Read()) {
        if (reader.NodeType == XmlNodeType.Element) {
          if (reader.Name == "id") {
            reader.Read(); 
            note.Id = int.Parse(reader.Value);
          }
          else if (reader.Name == "escalation") {
            reader.Read();
            note.Escalation = int.Parse(reader.Value);
          }
          else if (reader.Name == "body") {
            reader.Read();
            note.Body = reader.Value;
          }
          else if (reader.Name == "subject") {
            reader.Read();
            note.Subject = reader.Value;
          }
          else if (reader.Name == "recipients") {
            while (reader.Read()) {
              if (reader.Name == "recipient" && reader.NodeType == XmlNodeType.Element) {
                Recipient newRcpt = new Recipient();
                while (reader.Read()) {
                  if (reader.NodeType == XmlNodeType.Element) {
                    if (reader.Name == "channel") {
                      reader.Read();
                      newRcpt.Channel = reader.Value;
                    } else if (reader.Name == "address") {
                      reader.Read();
                      newRcpt.Address = reader.Value;
                    } else if (reader.Name == "send_at") {
                      reader.Read();
                      newRcpt.SentAt = reader.Value;
                    } else if (reader.Name == "status") {
                      reader.Read();
                      newRcpt.Status = reader.Value;
                    }                         
                  }
                }
                note.addRecipient(newRcpt);
              }
            }
          }
        }
      }
      return note;
    }
    
  }
}
