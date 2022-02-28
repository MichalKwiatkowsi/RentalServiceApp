using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalServiceApp.FrontEnd;

namespace RentalServiceApp.BackEnd
{
    internal class RentalServiceClients
    {
        public RentalServiceClients()
        {
            CreateClients();
        }
        public List<Client> Clients { get; set; } = new List<Client>();
        private void CreateClients()
        {
            Clients.Add(new Client(1, "Jan Nowak", new DateTime(2021, 03, 04)));
            Clients.Add(new Client(2, "Agnieszka Kowalska", new DateTime(1999, 01, 15)));
            Clients.Add(new Client(3, "Robert Lewandowski", new DateTime(2010, 12, 18)));
            Clients.Add(new Client(4, "Zofia Plucińska", new DateTime(2020, 04, 29)));
            Clients.Add(new Client(5, "Grzegorz Braun", new DateTime(2015, 07, 12)));
        }
        public Client GetClientById(int id)
        {
            foreach (var client in this.Clients)
            {
                if (id == client.ClientId)
                    return client;
            }
            return null;
        }
    }
}
