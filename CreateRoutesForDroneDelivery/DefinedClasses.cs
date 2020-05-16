using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CreateRoutesForDroneDelivery
{ 
    //<--   Graph Class    -->
    public class Network
    {
        List<Vertex> IGraph;
        List<Vertex> IGeneratedRoute;
        double IRouteDistance;
        public static double INFINITE = Double.MaxValue;
        private static float PXtoKM = 33.5f;

        public Network()
        {
            this.IGraph = new List<Vertex>();
            this.IRouteDistance = -1;
        }

        public List<Vertex> Graph
        {
            get { return this.IGraph; }
        }

        public List<Vertex> GeneratedRoute
        {
            get { return this.IGeneratedRoute; }
            set { }
        }

        public double RouteDistance
        {
            get { return IRouteDistance; }
        }
        public void AddVertex(Vertex vertex)
        {
            this.IGraph.Add(vertex);
        }

        public void AddVertex(string vertex)
        {
            Vertex newVertex = GetVertexFromString(vertex.Split(';')[0]);

            if (newVertex == null)
                return;

            string vEdge = vertex.Split(';')[1];
            string[] e;

            if (vEdge.Length > 0)
            {
                e = vEdge.Split(',');

                foreach (string edge in e)
                    newVertex.AddEdge(edge);
            }

            this.IGraph.Add(newVertex);
        }

        public void ClearGraph()
        {
            this.IGraph.Clear();
            this.IRouteDistance = -1;
            this.IGeneratedRoute = null;
        }

        public static Vertex GetVertexFromString(string vertex)
        {
            string[] v;

            if (vertex.Length > 0)
            {
                v = vertex.Split('|');
                DateTime date = new DateTime();
                date = DateTime.FromFileTime(long.Parse(v[4]));
                int x = Convert.ToInt32(v[5].Split('-')[0]);
                int y = Convert.ToInt32(v[5].Split('-')[1]);

                return new Vertex(v[0], v[1], v[2], v[3], date, new Point(x, y));
            }

            return null;
        }

        public void SetRoute(List<Vertex> route)
        {
            this.IGeneratedRoute = new List<Vertex>(route);
        }

        public void UpdateDistance(double distance)
        {
            this.IRouteDistance = distance / PXtoKM;
        }

        public List<Edge> DijsktraAlgorithm()
        {
            return new List<Edge>();
        }
    }

    //<--   Vertex Class    -->

    public class Vertex
    {
        List<Edge> IEdges;
        string IName;
        string IAddress;
        string IContact;
        string IRole;
        readonly Point IPosition;
        readonly DateTime ICreationDate;

        public Vertex(string name, string address, string contact, string role, DateTime creationDate, Point position)
        {
            if (creationDate == null)
                this.ICreationDate = DateTime.Now;
            else
                this.ICreationDate = creationDate;

            this.IName = name;
            this.IAddress = address;
            this.IContact = contact;
            this.IRole = role;
            this.IPosition = position;
            this.IEdges = new List<Edge>();
        }

        public Vertex(Vertex otherVertex)
        {
            this.IEdges = new List<Edge>(otherVertex.IEdges);
            this.IName = otherVertex.IName;
            this.IAddress = otherVertex.IAddress;
            this.IContact = otherVertex.IContact;
            this.IRole = otherVertex.IRole;
            this.IPosition = otherVertex.IPosition;
            this.ICreationDate = otherVertex.ICreationDate;
        }

        public List<Edge> Edges
        {
            get { return this.IEdges; }
        }

        public string Name
        {
            get { return this.IName; }
        }

        public string Address
        {
            get { return this.IAddress; }
        }

        public string Contact
        {
            get { return this.IContact; }
        }

        public string Role
        {
            get { return this.IRole; }
        }

        public Point Position
        {
            get { return this.IPosition; }
        }
        public DateTime CreationDate
        {
            get { return this.ICreationDate; }
        }

        public void AddEdge(Edge edge)
        {
            this.IEdges.Add(edge);
        }

        public void AddEdge(string edge)
        {
            string vertex = edge.Split('~')[0];
            double distance = Double.Parse(edge.Split('~')[1]);

            if (vertex.Length > 0)
            {
                this.IEdges.Add(new Edge(distance, new Vertex(Network.GetVertexFromString(vertex))));
            }

        }

        public void RemoveEdge(Edge edge)
        {
            this.Edges.Remove(edge);
        }

        public void Update(string name, string address, string contact, string role)
        {
            this.IName = name;
            this.IAddress = address;
            this.IContact = contact;
            this.IRole = role;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string VertexString()
        {
            return this.Name + "|" + this.Address + "|" + this.Contact + "|" + this.Role + "|" + this.CreationDate.ToFileTime() + "|" + this.Position.X + "-" + this.Position.Y;
        }

        public string EdgeString()
        {
            string edges = "";

            for (int i = 0; i < this.IEdges.Count; ++i)
            {
                if (i != IEdges.Count - 1)
                    edges += IEdges[i].Destination.VertexString() + "~" + IEdges[i].Distance + ",";
                else
                    edges += IEdges[i].Destination.VertexString() + "~" + IEdges[i].Distance;
            }

            return edges;
        }
    }

    //<--   Edge Class  -->

    public class Edge
    {
        double IDistance;
        Vertex IDestination;

        public Edge(double distance, Vertex destination)
        {
            this.IDistance = distance;
            this.IDestination = destination;
        }

        public double Distance
        {
            get { return this.IDistance; }
        }

        public Vertex Destination
        {
            get { return this.IDestination; }
        }

        public override string ToString()
        {
            return this.IDestination.Name;
        }
    }

    //<--   User Class    -->

    public class User
    {
        readonly string IUsername;
        readonly string IPassword;
        readonly string IName;
        readonly string IRole;
        readonly string IUserFolderPath;
        Network IDeliveryNetwork;

        public User(string userName, string password, string name, string role)
        {
            this.IUsername = userName;
            this.IPassword = password;
            this.IName = name;
            this.IRole = role;
            this.IDeliveryNetwork = new Network();

            Directory.CreateDirectory("../../../users/" + this.Username);
            this.IUserFolderPath = "../../../users/" + this.Username + "/";
        }

        public User(User otherUser)
        {
            this.IUsername = otherUser.Username;
            this.IPassword = otherUser.Password;
            this.IName = otherUser.Name;
            this.IRole = otherUser.Role;
            this.IDeliveryNetwork = otherUser.DeliveryNetwork;
            this.IUserFolderPath = otherUser.UserFolderPath;
        }

        public User(string user)
        {
            this.IUsername = user.Split('|')[0];
            this.IPassword = user.Split('|')[1];
            this.IName = user.Split('|')[2];
            this.IRole = user.Split('|')[3];
            this.IDeliveryNetwork = new Network();

            Directory.CreateDirectory("../../../users/" + this.Username);
            this.IUserFolderPath = "../../../users/" + this.Username + "/";
        }

        public override string ToString()
        {
            return this.Username + '|' + this.Password + '|' + this.Name + '|' + this.Role;
        }

        public string Name
        {
            get { return this.IName; }
        }

        public string Username
        {
            get { return this.IUsername; }
        }

        public string Password
        {
            get { return this.IPassword; }
        }

        public string Role
        {
            get { return this.IRole; }
        }

        public string UserFolderPath
        {
            get { return this.IUserFolderPath; }
        }

        public Network DeliveryNetwork
        {
            get { return this.IDeliveryNetwork; }
        }
    }

    //<--   Class Authentication    -->

    public static class Authentication
    {
        public static string EncryptUser(User user)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                   using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(user.ToString());
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptUser(string encryptedUser)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedUser);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string DecryptNetworkCredentials()
        {
            string networkCredentials = "";

            foreach (string line in File.ReadLines($"../../../data/mail.secure"))
            {
                networkCredentials = line;
            }

            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(networkCredentials);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("215463279snvc00b14ca58bsbce2ea16");
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

    //<--   Class SMTP    -->

    public static class SMTP
    {
        public static void SendEmail(string email, string subject, string body, string routePath)
        {
            string credentials = Authentication.DecryptNetworkCredentials();
            NetworkCredential NetCredential = new NetworkCredential(credentials.Split('|')[0], credentials.Split('|')[1]);

            MailMessage mail = new MailMessage(NetCredential.UserName, email, subject, body)
            {
                IsBodyHtml = true
            };
            mail.Attachments.Add(new Attachment(routePath));

            Console.WriteLine(File.Exists(routePath));

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = NetCredential
            };

            client.Send(mail);
        }
    }
}
